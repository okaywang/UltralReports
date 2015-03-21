using SE.BussinessLogic;
using SE.Common.Helpers;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    public class GetShopsModel : ITranslatable<Shop, GetShopsModel>
    {
        /// <summary>
        ///超市ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 超市名字
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 超市地址
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// 起送价格
        /// </summary>
        public int? DeliveryMinAmount { get; set; }

        /// <summary>
        /// 运送费
        /// </summary>
        public int? DeliveryRate { get; set; }

        /// <summary>
        /// 开始营业时间
        /// </summary>
        public TimeSpan? DailyOpeningTime { get; set; }

        /// <summary>
        /// 结束营业时间
        /// </summary>
        public TimeSpan? DailyClosingTime { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageFileNameUrl { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 是否营业
        /// </summary>
        public bool IsBussinessing { get; set; }

        public GetShopsModel Translate(Shop from)
        {
            this.Id = from.Id;
            this.ShopName = from.Name;
            this.Adress = string.Format("{0}{1}", from.ChinaCounty.Name, from.DetailAddress);
            this.DeliveryMinAmount = from.DeliveryMinAmount;
            this.DeliveryRate = from.DeliveryRate;
            this.DailyOpeningTime = from.DailyOpeningTime;
            this.DailyClosingTime = from.DailyClosingTime;
            this.Telephone = from.TelePhoneNumber;
            this.MobilePhone = from.MobilePhoneNumber;
            var imagePath = string.Format("{0}/{1}", ShopUploader.Instance.RelativePath, from.ClientImageFileName);
            this.ImageFileNameUrl = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + imagePath;
            this.IsBussinessing = ShopBussinessLogic.IsBussinessing(from);
            return this;
        }
    }
    public enum ShopModelStatus
    {
        Success,
        [DisplayText("无效的商铺")]
        InvalidShop,
        [DisplayText("无效的社区")]
        InvalidCommunity,
    }

    //public class GetShopsModelTranslator : TranslatorBase<Shop, GetShopsModel>
    //{
    //    public static readonly GetShopsModelTranslator Instance = new GetShopsModelTranslator();

    //    public override GetShopsModel Translate(Shop from)
    //    {
    //        var to = new GetShopsModel();
    //        to.Id = from.Id;
    //        to.ShopName = from.Name;
    //        to.Adress = string.Format("{0} {2}", from.ChinaCounty.Name, from.DetailAddress);
    //        to.DeliveryMinAmount = from.DeliveryMinAmount;
    //        to.DeliveryRate = from.DeliveryRate;
    //        to.ShopOpenDateTime = from.ShopOpenDateTime;
    //        to.DailyClosingTime = from.DailyOpeningTime;
    //        to.Telephone = from.TelePhoneNumber;
    //        to.MobilePhone = from.MobilePhoneNumber;
    //        //to.ImageFileNameUrl
    //        return to;
    //    }

    //    public override Shop Translate(GetShopsModel from)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}