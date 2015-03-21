using SE.Common.Types;
using SE.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    public class OrderListModel : ITranslatable<OrderHead, OrderListModel>
    {
        public string ShopName { get; set; }
        public int ShopId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime? RecipientDateTime { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DeviceType FromDeviceType { get; set; }
        public string ShopAddress { get; set; }
        public string TelNumber { get; set; }
        public string MobleNumber { get; set; }
        public int CountyId { get; set; }
        public int CommunityId { get; set; }
        public string CommunityName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PayStyle { get; set; }
        public int SendPrice { get; set; }
        public string Remarks { get; set; }
        public string TrueRecipientTime { get; set; }
        public string ClientTransactionDateTime { get; set; }
        public GenderType Gender { get; set; }
        public SkuItem[] SkuItems { get; set; }
        public OrderListModel Translate(OrderHead from)
        {
            this.ShopName = from.Shop.Name;
            this.ShopId = from.Shop.Id;
            this.CountyId = from.Shop.ChinaCounty.Id;
            this.CommunityId = from.Recipient.CommunityId;
            this.CommunityName = from.Recipient.Community.Name;
            this.OrderNumber = from.OrderNumber;
            this.TransactionDateTime = from.TransactionDateTime;
            this.RecipientDateTime = from.RecipientDateTime;
            this.Status = from.Status;
            this.TrueRecipientTime = from.ClientRecipientTime;
            this.FromDeviceType = from.FromDeviceType;
            this.ShopAddress = string.Format("{0}{1}", from.Shop.ChinaCounty.Name, from.Shop.DetailAddress);
            this.TelNumber = from.Shop.TelePhoneNumber;
            this.MobleNumber = from.Shop.MobilePhoneNumber;
            this.CustomerName = from.Recipient.Name;
            this.CustomerAddress = string.Format("{0}{1}", from.Recipient.Community.Name, from.Recipient.DetailAddress);
            this.PayStyle = "货到付款";
            this.Remarks = from.Remarks;
            this.Gender = from.Recipient.Gender;
            this.SendPrice = from.Shop.DeliveryRate;
            this.ClientTransactionDateTime = from.ClientTransactionDateTime;
            this.SkuItems = new SkuItem[from.OrderBodies.Count];
           // decimal allPrice = 0;
            var i = 0;
            foreach (var item in from.OrderBodies)
            {
                this.SkuItems[i] = new SkuItem().Translate(item);
                this.TotalPrice += item.Price * item.Quantity;
                i++;
            }
            var deliveryRate =  from.Recipient.DeliveryRate;
            //this.TotalPrice = allPrice + deliveryRate;
            return this;
        }
    }
    public class SkuItem
    {
        public string SkuName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Num { get; set; }
        public string Specification { get; set; }
        public int SkuTypeId { get; set; }
        public int SkuId { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Unit { get; set; }
        public SkuItem Translate(OrderBody from)
        {
            this.BrandName = from.Sku.Brand.Name;
            this.SkuName = from.Sku.Name;
            this.Num = from.Quantity;
            this.Price = from.Price;
            this.Specification = from.Sku.Specification;
            this.SkuTypeId = from.Sku.SkuType.Id;
            this.SkuId = from.Sku.Id;
            this.DiscountPrice = from.Sku.DiscountPrice;
            this.Unit = from.Sku.SkuUnit.Name;
            return this;
        }
    }
    public enum OrderListModelStatus
    {
        Success,
        [DisplayText("无效的用户")]
        InvalidUserId,
    }
}