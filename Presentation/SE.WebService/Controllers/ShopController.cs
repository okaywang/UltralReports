using SE.BussinessLogic;
using SE.Common.Types;
using SE.DataAccess;
using SE.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebExpress.Core;

namespace SE.WebService.Controllers
{
    public class ShopController : ApiController
    {
        private ShopBussinessLogic _shopBll;
        private CommunityBussinessLogic _communityBll;
        private CustomerBussinessLogic _customerBll;
        public ShopController(ShopBussinessLogic shopBll, CommunityBussinessLogic communityBll,CustomerBussinessLogic customerBll)
        {
            _shopBll = shopBll;
            _communityBll = communityBll;
            _customerBll = customerBll;
        }

        /// <summary>
        /// 根据楼宇获取正在营业的超市
        /// </summary>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<GetShopsModel[]> GetShops(int communityId)
        {
            if (_communityBll.Get(communityId) == null)
            {
                return ResultModel<GetShopsModel[]>.Conclude(ShopModelStatus.InvalidCommunity);
            }
            var criteria = new ShopSearchCriteria();
            criteria.ServedCommunityId = communityId;
            criteria.CooperationStatus = ShopCooperationStatus.OpenShop;
            var pageShops = _shopBll.Search(criteria);
            var result = BatchTranslator<Shop, GetShopsModel>.Translate(pageShops.ToList());
            result = result.OrderByDescending(i => i.IsBussinessing).ToList();
            return ResultModel<GetShopsModel[]>.Conclude(ShopModelStatus.Success, result.ToArray());
        }
        /// <summary>
        /// 获取单个超市
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<GetShopsModel> GetShop(int ShopId)
        {
            var shop = _shopBll.Get(ShopId);
            if (shop == null)
            {
                return ResultModel<GetShopsModel>.Conclude(ShopModelStatus.InvalidShop);
            }
            var result = new GetShopsModel
            {
                Id = shop.Id,
                ShopName = shop.Name,
                Adress = string.Format("{0}{1}", shop.ChinaCounty.Name, shop.DetailAddress),
                DeliveryMinAmount = shop.DeliveryMinAmount,
                DeliveryRate = shop.DeliveryRate,
                DailyOpeningTime = shop.DailyOpeningTime,
                DailyClosingTime = shop.DailyClosingTime,
                Telephone = shop.TelePhoneNumber,
                MobilePhone = shop.MobilePhoneNumber
                //image

            };
            return ResultModel<GetShopsModel>.Conclude(ShopModelStatus.Success, result);
        }


        [ActionStatus(typeof(RecommendShopStatus))]
        [HttpGet]
        public ResultModel<bool> RecommendShop(string ShopName, string ShopNumber, string ShopAddress, int CustomerId, int CommunityId)
        {           
            if(string.IsNullOrEmpty(ShopName))
            {
                return ResultModel<bool>.Conclude(RecommendShopStatus.InvalidShopName);
            }
            if (string.IsNullOrEmpty(ShopNumber))
            {
                return ResultModel<bool>.Conclude(RecommendShopStatus.InvalidNumber);
            }
            if (string.IsNullOrEmpty(ShopAddress))
            {
                return ResultModel<bool>.Conclude(RecommendShopStatus.InvalidAddress);
            }
            if (CustomerId==null)
            {
                return ResultModel<bool>.Conclude(RecommendShopStatus.InvalidCustomerId);
            }
            if (CommunityId == null)
            {
                return ResultModel<bool>.Conclude(RecommendShopStatus.InvalidCommunityid);
            }
            var customer = _customerBll.Get(CustomerId);
            var shop = new RecommendShop()
            {
                CustomerId = customer.Id,
                ContactName = ShopName,
                ContactPhoneNumber = ShopNumber,
                ShopAddress = ShopAddress,
                AddTime = DateTime.Now,
                IsRecharge = false,
                CommunityId = CommunityId
            };
            _shopBll.AddRecommenShop(shop);
            return ResultModel<bool>.Conclude(RecommendShopStatus.Success,true);
        }

        public enum RecommendShopStatus
        {
            Success,
            [DisplayText("名字不能为空")]
            InvalidShopName,
            [DisplayText("联系电话不能为空")]
            InvalidNumber,
            [DisplayText("地址不能为空")]
            InvalidAddress,
            [DisplayText("用户Id不能为空")]
            InvalidCustomerId,
            [DisplayText("社区ID不能为空")]
            InvalidCommunityid
        }

    }
}