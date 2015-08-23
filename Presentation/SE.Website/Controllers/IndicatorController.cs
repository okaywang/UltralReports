using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //model.Weights = _bllKpi.GetLastestWeight(endDate.HasValue ? endDate.Value : DateTime.Now);
            model.Data = _bllKpi.Search(beginDate, endDate);
            return View(model);
        }

        public FileResult ExportExcel(DateTime? beginDate, DateTime? endDate)
        {
            var model = new KPIListPageModel();
            //model.Weights = _bllKpi.GetLastestWeight(endDate.HasValue ? endDate.Value : DateTime.Now);
            model.Data = _bllKpi.Search(beginDate, endDate);

            this.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(this.ControllerContext, "_ExcelTemplate");
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                var html = sw.GetStringBuilder().ToString();
                byte[] fileContents = Encoding.UTF8.GetBytes(html);
                return File(fileContents, "application/ms-excel", "指标竞赛.xls"); 
            }
        }

        public FileResult ExportExcel1()
        {
            var sbHtml = new StringBuilder();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            var lstTitle = new List<string> { "编号", "姓名", "年龄", "创建时间" };
            foreach (var item in lstTitle)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
            }
            sbHtml.Append("</tr>");

            for (int i = 0; i < 1000; i++)
            {
                sbHtml.Append("<tr>");
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>屌丝{0}号</td>", i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", new Random().Next(20, 30) + i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", DateTime.Now);
                sbHtml.Append("</tr>");
            }
            sbHtml.Append("</table>");

            //第一种:使用FileContentResult
            byte[] fileContents = Encoding.Default.GetBytes(sbHtml.ToString());
            return File(fileContents, "application/ms-excel", "fileContents.xls"); 
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
