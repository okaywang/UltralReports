using SE.Common.Types;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    public class NewOrderModel
    {
        public int UserId { get; set; }
        public ICollection<SkuOrder> SkuItems { get; set; }
        public string Address { get; set; }
        public int CountyId { get; set; }
        public int CommunityId { get; set; }
        public int ShopId { get; set; }
        public string Remarks { get; set; }
        public GenderType Gender { get; set; }
        public DeviceType FromDeviceType { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string UserName { get; set; }
        public string TrueTime { get; set; }
    }
    public class SkuOrder
    {
        public int Id { get; set; }
        public int Num { get; set; }
    }

    public class NewOrderResult
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string ClientTransactionDateTime { get; set; }
    }
    public enum OrderModelStatus
    {
        Success,

        [DisplayText("参数无效")]
        ArgumentNull,

        [DisplayText("无效的用户")]
        InvalidUserId,

        [DisplayText("无效的设备")]
        InvalidDeviceType,

        [DisplayText("无效的区县")]
        InvalidCounty,

        [DisplayText("无效的社区")]
        InvalidCommunity,

        [DisplayText("无效的商铺")]
        InvalidShop,

        [DisplayText("商铺不在营业中")]
        ShopStopBussinessing,

        [DisplayText("您的{0}商品已经下架")]
        SkuIsNotPublic,
    }
    public enum ConfirmReceiptStatus
    {
        Success,
        [DisplayText("无效用户")]
        UserNull,
        [DisplayText("无效的订单")]
        OrderNull,
        [DisplayText("已完成的订单")]
        OrderReady
    }
    public enum NotReceiptStatus
    {
        Success,
        [DisplayText("无效用户")]
        UserNull,
        [DisplayText("无效的订单")]
        OrderNull,
    }
    public class NewOrderModelTranslator : TranslatorBase<OrderHead, NewOrderModel>
    {
        public static readonly NewOrderModelTranslator Instance = new NewOrderModelTranslator();

        public override NewOrderModel Translate(OrderHead from)
        {
            throw new NotImplementedException();
        }

        public override OrderHead Translate(NewOrderModel from)
        {
            var to = new OrderHead();
            to.CustomerId = from.UserId;
            to.Remarks = from.Remarks;
            to.ShopId = from.ShopId;
            to.TransactionDateTime = DateTime.Now;
            to.ClientTransactionDateTime = from.TrueTime;
            to.FromDeviceType = from.FromDeviceType;
            to.Status = OrderStatus.生成中;
            return to;
        }
    }
}