using SE.BussinessLogic;
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
    public class SkuController : ApiController
    {
        private OrderBussinessLogic _orderBll;
        private CustomerBussinessLogic _customerBll;
        private RecipientBussinessLogic _recipientBll;
        private GoodsBussinessLogic _skuBll;
        private ShopBussinessLogic _shopBll;
        private GoodsBussinessLogic _GoodBll;
        public SkuController(OrderBussinessLogic orderBll, CustomerBussinessLogic customerBll, RecipientBussinessLogic recipientBll, GoodsBussinessLogic skuBll, ShopBussinessLogic shopBll, GoodsBussinessLogic goodBll)
        {
            _orderBll = orderBll;
            _customerBll = customerBll;
            _recipientBll = recipientBll;
            _skuBll = skuBll;
            _shopBll = shopBll;
            _GoodBll = goodBll;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<SkuListModel[]> GetSkuList(int shopId, int? pageSize, int? pageIndex)
        {
            var skus = SearchSku(shopId, null, pageSize, pageIndex);

            var groupedSkus = skus.GroupBy(i => i.SkuTypeId);
            var result = new List<SkuListModel>();
            foreach (var groupItem in groupedSkus)
            {
                var item = new SkuListModel();
                item.SkuTypeId = groupItem.Key;
                item.SkuTypeName = _skuBll.GetSkuType(item.SkuTypeId).Name;
                item.goods = BatchTranslator<Sku, GoodListItem>.Translate(groupItem.ToList()).ToArray();
                result.Add(item);
            }
            return ResultModel<SkuListModel[]>.Conclude(StandaloneStatus.Success, result.ToArray());
        }

        /// <summary>
        /// 获取超市下的商品类型
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<SkuTypeModel[]> GetShopTypeList(int shopId)
        {
            var skus = SearchSku(shopId);
            var groupedSkus = skus.GroupBy(i => i.SkuTypeId);
            var result = new List<SkuTypeModel>();
            foreach (var groupItem in groupedSkus)
            {
                var type = new SkuTypeModel()
                {
                    SkuTypeId = groupItem.Key,
                    SkuTypeName = _skuBll.GetSkuType(groupItem.Key).Name
                };
                result.Add(type);
            }

            return ResultModel<SkuTypeModel[]>.Conclude(StandaloneStatus.Success, result.ToArray());
        }

        /// <summary>
        /// 获取商品类型下的所有商品
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="skuTypeId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<SkuListModel> GetShopTypeSkus(int shopId, int skuTypeId)
        {
            var skus = SearchSku(shopId, skuTypeId);
            var result = new SkuListModel();
            result.SkuTypeId = skuTypeId;
            result.SkuTypeName = _skuBll.GetSkuType(skuTypeId).Name;
            result.goods = BatchTranslator<Sku, GoodListItem>.Translate(skus.ToList()).ToArray();
            return ResultModel<SkuListModel>.Conclude(StandaloneStatus.Success, result);
        }

        private PagedList<Sku> SearchSku(int? shopId, int? skuTypeId = null, int? pageSize = null, int? pageIndex = null)
        {
            var paging = new PagingRequest(pageIndex ?? 0, pageSize ?? int.MaxValue);
            var criteria = new SkuSearchCriteria()
            {
                IsPublic = true,
                ShopId = shopId,
                SkuTypeId = skuTypeId,
                OrderByFields = new List<OrderByField<Sku>>() 
                {
                    new OrderByField<Sku>(i => i.SkuType.Order, System.Data.SqlClient.SortOrder.Ascending),
                    new OrderByField<Sku>(i => i.Id, System.Data.SqlClient.SortOrder.Descending) 
                }
            };
            var skus = _GoodBll.Search(criteria);
            return skus;
        }

    }
}