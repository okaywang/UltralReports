using SE.Common.Helpers;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    public class SkuListModel
    {
        public int SkuTypeId { get; set; }
        public string SkuTypeName { get; set; }
        public GoodListItem[] goods { get; set; }

    }
    public class GoodListItem : ITranslatable<Sku, GoodListItem>
    {
        public int SkuId { get; set; }
        public string SkuName { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Specification { get; set; }
        public string Unit { get; set; }
        public string ImageFileName { get; set; }
        public int SkuTypeId { get; set; }
        public string BrandName { get; set; }
        public GoodListItem Translate(Sku from)
        {
            this.SkuId = from.Id;
            this.SkuName = from.Brand.Name + from.Name;
            this.Price = from.Price;
            this.DiscountPrice = from.DiscountPrice.HasValue ? from.DiscountPrice : 0;
            this.Specification = from.Specification;
            this.Unit = from.SkuUnit.Name;
            this.SkuTypeId = from.SkuTypeId;
            this.BrandName = from.Brand.Name;
            var imagePath = string.Format("{0}/{1}/{2}", GoodsUploader.Instance.RelativePath, from.ShopId, from.ImageFileName);
            this.ImageFileName = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + imagePath;
            return this;
        }
    }
    //public enum SkuListModelStatus
    //{
    //    Success,
    //    [DisplayText("无效的商店")]
    //    InvalidShopId,
    //}
}