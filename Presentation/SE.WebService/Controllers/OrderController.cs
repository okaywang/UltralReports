using Art.WebService.Models;
using SE.BussinessLogic;
using SE.Common.Types;
using SE.DataAccess;
using SE.WebService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExpress.Core;

namespace SE.WebService.Controllers
{
    public class OrderController : ApiController
    {
        private OrderBussinessLogic _orderBll;
        private CustomerBussinessLogic _customerBll;
        private RecipientBussinessLogic _recipientBll;
        private GoodsBussinessLogic _skuBll;
        private CommunityBussinessLogic _communityBll;
        private ChinaAreaBussinessLogic _areaBll;
        private ShopBussinessLogic _shopBll;
        private OrderNumberSeedBussinessLogic _orderSeedBll;
        public OrderController(OrderBussinessLogic orderBll, CustomerBussinessLogic customerBll, RecipientBussinessLogic recipientBll,
            GoodsBussinessLogic skuBll, CommunityBussinessLogic communityBll, ChinaAreaBussinessLogic areaBll,
            ShopBussinessLogic shopBll, OrderNumberSeedBussinessLogic orderSeedBll)
        {
            _orderBll = orderBll;
            _customerBll = customerBll;
            _recipientBll = recipientBll;
            _skuBll = skuBll;
            _communityBll = communityBll;
            _areaBll = areaBll;
            _shopBll = shopBll;
            _orderSeedBll = orderSeedBll;
        }
        /// <summary>
        /// 下订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionStatus(typeof(OrderModelStatus))]
        [HttpPost]
        public ResultModel<NewOrderResult> Add(NewOrderModel model)
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(model);

            if (model == null)
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.ArgumentNull);
            }
            if (!Enum.IsDefined(typeof(DeviceType), model.FromDeviceType))
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.InvalidDeviceType);
            }
            if (!_customerBll.Exist(model.UserId))
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.InvalidUserId);
            }
            if (_communityBll.Get(model.CommunityId) == null)
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.InvalidCommunity);
            }
            if (_areaBll.GetChinaCounty(model.CountyId) == null)
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.InvalidCounty);
            }
            var shop = _shopBll.Get(model.ShopId);
            if (shop == null)
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.InvalidShop);
            }
            if (!ShopBussinessLogic.IsBussinessing(shop))
            {
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.ShopStopBussinessing);
            }
            if (GetIsNotPublicSkus(model) != null)
            {
                string.Format(OrderModelStatus.SkuIsNotPublic.GetDisplayText(), GetIsNotPublicSkus(model));
                return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.SkuIsNotPublic);
            }

            var orderNew = NewOrderModelTranslator.Instance.Translate(model);
            orderNew.Recipient = GetRecioientId(model);

            OrderHead order;
            lock (this)
            {
                var seed = _orderSeedBll.FirstOrDefault();
                orderNew.OrderNumber = seed.OrderNumber;
                foreach (var item in model.SkuItems)
                {
                    var sku = _skuBll.Get(item.Id);
                    var price = sku.DiscountPrice ?? sku.Price;
                    var orderbody = new OrderBody()
                    {
                        SkuId = item.Id,
                        Quantity = item.Num,
                        Price = price
                    };
                    orderNew.OrderBodies.Add(orderbody);
                }
                order = _orderBll.Insert(orderNew);
                _orderSeedBll.Delete(seed);
            }

            //订单是否可返现
            if (CanReturnCash(model.UserId, shop.Id, order.TransactionDateTime))
            {
                shop.TotalScore++;
                _shopBll.Update(shop);
            }

            var resultModel = new NewOrderResult()
            {
                OrderNumber = orderNew.OrderNumber,
                TransactionDateTime = orderNew.TransactionDateTime,
                ClientTransactionDateTime = orderNew.ClientTransactionDateTime
            };

            var reciepentPhoneNumber = shop.MobilePhoneNumber;
            //发短信通知
            Task.Factory.StartNew(() =>
            {
                var bll = GlobalConfiguration.Configuration.DependencyResolver.BeginScope().GetService(typeof(OrderBussinessLogic)) as OrderBussinessLogic;
                var message = bll.GetSmsContentByOrderNumber(orderNew.OrderNumber);
                var result = SendSMS(message, reciepentPhoneNumber);
                var theOrder = bll.Get(order.Id);
                theOrder.SmsStatus = result == "发送成功" ? SmsStatus.Success : SmsStatus.Failure;
                theOrder.SmsDateTime = DateTime.Now;
                bll.Update(order);
            });
            return ResultModel<NewOrderResult>.Conclude(OrderModelStatus.Success, resultModel);
        }
        /// <summary>
        /// 检测是否有下架商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string GetIsNotPublicSkus(NewOrderModel model)
        {
            var skus = model.SkuItems;
            var result = string.Empty;
            foreach (var sku in skus)
            {
                var good = _skuBll.Get(sku.Id);
                if (good.IsPublic == false)
                {
                    result += good.Name + " ";
                }
            }
            if (!string.IsNullOrEmpty(result))
            {
                return result.ToString();
            }
            return null;
        }

        /// <summary>
        /// 发送订单短信
        /// </summary>
        /// <param name="orderNumber"></param>
        [HttpGet]
        public ResultModel<string> SendOrderMsg(string orderNumber)
        {
            var message = _orderBll.GetSmsContentByOrderNumber(orderNumber);
            var orderHead = _orderBll.GetOrderByOrderNumber(orderNumber);
            if (orderHead == null)
            {
                return ResultModel<string>.Conclude(SendSmsStatus.Failure, "发送失败");
            }
            var phoneNumber = orderHead.Shop.MobilePhoneNumber;
            var ret = SendSMS(message, phoneNumber);            
            if (ret == "发送成功")
            {
                orderHead.SmsStatus = SmsStatus.Success;
                orderHead.SmsDateTime = DateTime.Now;
                _orderBll.Update(orderHead);
                return ResultModel<string>.Conclude(SendSmsStatus.Success, "发送成功");
            }
            else
            {
                orderHead.SmsStatus = SmsStatus.Failure;
                orderHead.SmsDateTime = DateTime.Now;
                _orderBll.Update(orderHead);
                return ResultModel<string>.Conclude(SendSmsStatus.Failure, "发送失败");
            }
        }

        private string SendSMS(string message, string phoneNumber)
        {
            var sms = new WebReference.SmsSoapClient();
            var msg = string.Format(SEApiConfig.Instance.SmsContentShop, message);
            var ret = sms.SendSmsSaveLog(phoneNumber, msg, 2, "ShopWebApi");
            return ret;
        }

        /// <summary>
        /// 插入最新收货信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Recipient GetRecioientId(NewOrderModel model)
        {
            var recipient = new Recipient()
            {
                Name = model.UserName,
                Gender = model.Gender,
                DetailAddress = model.Address,
                CustomerId = model.UserId,
                CommunityId = model.CommunityId,
                DeliveryRate = _shopBll.Get(model.ShopId).DeliveryRate
            };
            var result = _recipientBll.Insert(recipient);
            var customer = _customerBll.Get(model.UserId);
            customer.DefaultRecipientId = result.Id;
            _customerBll.Update(customer);
            return result;
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionStatus(typeof(ConfirmReceiptStatus))]
        [HttpGet]
        public ResultModel<int> ConfirmReceipt(int userId, string orderNumber, string Time)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<int>.Conclude(ConfirmReceiptStatus.UserNull);
            }
            if (_orderBll.GetOrderByOrderNumber(orderNumber) == null)
            {
                return ResultModel<int>.Conclude(ConfirmReceiptStatus.OrderNull);
            }
            else
            {
                var orderHeadFirst = _orderBll.GetOrderByOrderNumber(orderNumber);
                if (orderHeadFirst.Status == OrderStatus.已完成)
                {
                    return ResultModel<int>.Conclude(ConfirmReceiptStatus.OrderReady);
                }
            }

            var orderHead = _orderBll.GetOrderByOrderNumber(orderNumber);
            orderHead.RecipientDateTime = DateTime.Now;
            orderHead.ClientRecipientTime = Time;
            orderHead.Status = Common.Types.OrderStatus.已完成;
            _orderBll.Update(orderHead);
            System.DateTime time1 = orderHead.TransactionDateTime;

            //System.DateTime time2 = orderHead.ReceiptDateTime.Value;
            //var seconds = GetSeconds(time1,time2);
            //return ResultModel<int>.Conclude(ConfirmReceiptStatus.Success,seconds);
            System.DateTime time2 = orderHead.RecipientDateTime.Value;
            var seconds = GetSeconds(time1, time2);
            return ResultModel<int>.Conclude(ConfirmReceiptStatus.Success, seconds);
        }

        /// <summary>
        /// 判断当天当前用户是否增加返现金额
        /// </summary>
        /// <returns></returns>
        public bool CanReturnCash(int customerId, int shopId, DateTime orderDate)
        {
            var count = _orderBll.Where(i => i.CustomerId == customerId && i.ShopId == shopId && SqlFunctions.DateDiff("day", i.TransactionDateTime, orderDate) == 0).Count();
            return count <= 2;
        }

        /// <summary>
        /// 获取时间差的秒数
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        private int GetSeconds(System.DateTime time1, System.DateTime time2)
        {
            TimeSpan ts = time2 - time1;
            var seconds = ts.TotalSeconds;
            return Convert.ToInt32(seconds);
        }
        /// <summary>
        /// 未收到货
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        [ActionStatus(typeof(NotReceiptStatus))]
        [HttpGet]
        public ResultModel<bool> NotReceipt(int userId, string orderNumber)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<bool>.Conclude(NotReceiptStatus.UserNull);
            }
            if (_orderBll.GetOrderByOrderNumber(orderNumber) == null)
            {
                return ResultModel<bool>.Conclude(NotReceiptStatus.OrderNull);
            }
            var orderHead = _orderBll.GetOrderByOrderNumber(orderNumber);
            orderHead.Status = Common.Types.OrderStatus.未收到货;
            _orderBll.Update(orderHead);
            return ResultModel<bool>.Conclude(ConfirmReceiptStatus.Success, false);

        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(NotReceiptStatus))]
        [HttpGet]
        public ResultModel<OrderListModel[]> GetOrderList(int userId)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<OrderListModel[]>.Conclude(OrderListModelStatus.InvalidUserId);
            }
            var criteria = new OrderSearchCriteria()
            {
                CustomerId = userId
            };
            var orderHeads = _orderBll.Search(criteria);
            var models = BatchTranslator<OrderHead, OrderListModel>.Translate(orderHeads);
            return ResultModel<OrderListModel[]>.Conclude(OrderListModelStatus.Success, models.ToArray());

        }
        /// <summary>
        /// 未收货订单数量
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(NotReceiptStatus))]
        [HttpGet]
        public ResultModel<int> IsFasleOrder(int userId)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<int>.Conclude(OrderListModelStatus.InvalidUserId);
            }
            var orderHeads = _orderBll.IsFasleOrder(userId);
            return ResultModel<int>.Conclude(OrderListModelStatus.Success, orderHeads.Count());
        }
        /// <summary>
        /// 获取未收货订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(NotReceiptStatus))]
        [HttpGet]
        public ResultModel<OrderListModel[]> GetNotReceivingOrderList(int userId)
        {
            if (_customerBll.Get(userId) == null)
            {
                return ResultModel<OrderListModel[]>.Conclude(OrderListModelStatus.InvalidUserId);
            }
            var criteria = new OrderSearchCriteria()
            {
                CustomerId = userId,
                Status = OrderStatus.生成中
            };
            var orderHeads = _orderBll.Search(criteria);
            var models = BatchTranslator<OrderHead, OrderListModel>.Translate(orderHeads);
            return ResultModel<OrderListModel[]>.Conclude(OrderListModelStatus.Success, models.ToArray());

        }

    }
}