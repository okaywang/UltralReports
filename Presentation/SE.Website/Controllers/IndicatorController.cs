using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class IndicatorController : Controller
    {
        private KPIBussinessLogic _bllKpi;
        private BussinessLogicBase<KPIWeight> _bllWeight;
        public IndicatorController(BussinessLogicBase<KPIWeight> bllWeight, KPIBussinessLogic bllKpi)
        {
            _bllWeight = bllWeight;
            _bllKpi = bllKpi;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(DateTime? beginDate, DateTime? endDate)
        {
            var model = new KPIListPageModel();
            model.Weights = _bllKpi.GetLastestWeight(endDate.HasValue ? endDate.Value : DateTime.Now);
            model.Data = _bllKpi.Search(beginDate, endDate);
            return View(model);
        }

        [HttpPost]
        public JsonResult SetWeight(IndicatorItemModel[] model)
        {
            foreach (var item in model)
            {
                var entity = _bllWeight.Where(i => i.ItemType == item.ItemType && i.BeginDate == item.BeginDate).FirstOrDefault();
                if (entity == null)
                {
                    entity = new KPIWeight
                    {
                        ItemType = item.ItemType,
                        Weight = item.Weight,
                        BeginDate = item.BeginDate
                    };
                    _bllWeight.Insert(entity);
                }
                else
                {
                    entity.Weight = item.Weight;
                    _bllWeight.Update(entity);
                }
            }
            return Json(new ResultModel(true));
        }

        public ActionResult Weight()
        {
            var indicatorNames = new[] { "#1机主汽温越限", "#1机再热汽温越限", "#1机主汽温限内偏差", "#1机再热汽温限内偏差", "#1机排烟损失", "#1机管壁超温", "#1机氨单耗", "综合厂用电率", "#1负荷完成率", "全厂负荷完成率" };
            var indicatorIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var model = new IndicatorItemModel[10];
            for (int i = 0; i < model.Length; i++)
            {
                model[i] = new IndicatorItemModel
                {
                    ItemType = indicatorIds[i],
                    Name = indicatorNames[i]
                };

            }
            return View(model);
        }
    }
}
