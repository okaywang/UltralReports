using AutoMapper;
using BussinessLogic;
using Common.Types;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using Website.Common;
using Website.Filters;
using Website.Models;

namespace Website.Controllers
{
    public class UltraRecordController : Controller
    {
        private UltraReportBussinessLogic _bllUltraRecord;
        private EquipmentBussinessLogic _bllEquipment;
        private MajorBussinessLogic _bllMajor;

        public UltraRecordController(UltraReportBussinessLogic bllUltraRecord, EquipmentBussinessLogic bllEquipment, MajorBussinessLogic bllMajor)
        {
            _bllUltraRecord = bllUltraRecord;
            _bllEquipment = bllEquipment;
            _bllMajor = bllMajor;
        }

        public JsonResult Pie()
        {
            var model = new PieModel();
            var startDate = DateTime.Now.AddDays(-1);
            var records = _bllUltraRecord.Where(i => i.IsProRecord == false && i.StartTime >= startDate).ToList();
            model.Pie1.总报警次数 = records.Count;
            model.Pie1.高I限报警次数 = records.Where(i => i.UltraType == "H1").Count();
            model.Pie1.高II限报警次数 = records.Where(i => i.UltraType == "H2").Count();
            model.Pie1.高III限报警次数 = records.Where(i => i.UltraType == "H3").Count();
            model.Pie1.低I限报警次数 = records.Where(i => i.UltraType == "L1").Count();
            model.Pie1.低II限报警次数 = records.Where(i => i.UltraType == "L2").Count();
            model.Pie1.低III限报警次数 = records.Where(i => i.UltraType == "L3").Count();

            var proRecords = _bllUltraRecord.Where(i => i.IsProRecord == true && i.StartTime >= startDate).ToList();
            model.Pie2.专业报警次数 = proRecords.Count;
            model.Pie2.已处理 = proRecords.Where(i => i.HasRemarks).Count();
            model.Pie2.未处理 = proRecords.Where(i => !i.HasRemarks).Count();
            return Json(model);
        }

        //[RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult SummaryIndex()
        {
            var model = new UltraSummaryListPageModel();
            model.Title = "常规超限统计汇总列表";
            model.RequestListUrl = "/UltraRecord/SummaryList";
            var types = _bllEquipment.MonitorTypeGetAll();
            model.MonitorTypes = Mapper.Map<List<MonitorType>, NameValuePair[]>(types);
            var majors = _bllMajor.GetAll();
            model.Majors = Mapper.Map<List<Major>, NameValuePair[]>(majors);
            return View(model);
        }

        public FileResult ExportExcelSummary(UltraSummarySearchCriteria criteria)
        {
            var entities = _bllUltraRecord.SearchSummaryBySql(criteria);
            var items = Mapper.Map<PagedList<UltraSummary>, UltraSummaryListItemModelExcel[]>(entities);

            var model = new PagedModel<UltraSummaryListItemModelExcel>();
            model.Items = items;
            model.Items.Each(i => i.RatedRange = "&nbsp;" + i.RatedRange);
            this.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(this.ControllerContext, "_CommonListExcel");
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                var html = sw.GetStringBuilder().ToString();
                byte[] fileContents = Encoding.UTF8.GetBytes(html);
                return File(fileContents, "application/ms-excel", "常规超限统计.xls");
            }
        }

        //[RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult SummaryList(UltraSummarySearchCriteria criteria)
        {
            var entities = _bllUltraRecord.SearchSummaryBySql(criteria);
            var items = Mapper.Map<PagedList<UltraSummary>, UltraSummaryListItemModel[]>(entities);
            var model = new PagedModel<UltraSummaryListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        public ActionResult ExportExcelList(UltraRecordSearchCriteria criteria)
        {
            criteria.PagingRequest = null;
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<List<UltraRecord>, UltraRecordListItemModel[]>(entities);

            var model = new PagedModel<UltraRecordListItemModel>();
            model.Items = items;

            this.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(this.ControllerContext, "_CommonListExcel");
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                var html = sw.GetStringBuilder().ToString();
                byte[] fileContents = Encoding.UTF8.GetBytes(html);
                return File(fileContents, "application/ms-excel", "超限统计详情.xls");
            }
        }

        //[RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult List(UltraRecordSearchCriteria criteria)
        {
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<List<UltraRecord>, UltraRecordListItemModel[]>(entities);
            var model = new UltraRecordListPageModel();
            model.Records = new PagedModel<UltraRecordListItemModel>();
            if (criteria.PartId.HasValue)
            {
                var part = _bllEquipment.PartGet(criteria.PartId.Value);
                model.PartName = part.Name;
                model.EquipmentName = part.Equipment.Name;
            }
            model.Records.PagingResult = entities.PagingResult;
            model.Records.Items = items;
            return PartialView(model);
        }

        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public ActionResult ProUltraRecordIndex()
        {
            var model = new ProUltraRecordListPageModel();
            model.Title = "专业超限统计查询";
            model.RequestListUrl = "/UltraRecord/ProUltraRecordList";

            var majors = _bllMajor.GetAll();
            model.Majors = Mapper.Map<List<Major>, NameValuePair[]>(majors);
            return View(model);
        }

        public ActionResult ExportExcelProUltraRecordList(UltraRecordSearchCriteria criteria)
        {
            criteria.SearchProRecord = true;

            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<PagedList<UltraRecord>, ProUltraRecordListItemModel[]>(entities);

            var model = new PagedModel<ProUltraRecordListItemModel>();
            model.Items = items;


            this.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(this.ControllerContext, "_CommonListExcel");
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                var html = sw.GetStringBuilder().ToString();
                byte[] fileContents = Encoding.UTF8.GetBytes(html);
                return File(fileContents, "application/ms-excel", "专业超限统计.xls");
            }
        }

        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public ActionResult ProUltraRecordList(UltraRecordSearchCriteria criteria)
        {
            criteria.SearchProRecord = true;
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<PagedList<UltraRecord>, ProUltraRecordListItemModel[]>(entities);
            var model = new PagedModel<ProUltraRecordListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        [HttpPost]
        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public JsonResult Reason(UltroReasonModel model)
        {
            //UserContext.Current.MajorId 
            var record = _bllUltraRecord.Get(model.Id);
            if (!UserContext.Current.MajorId.HasValue || UserContext.Current.MajorId != record.Part.MajorId)
            {
                return Json(new ResultModel(false, "对不起，您无权限填报！"));
            }
            record.Remarks = model.Reason;
            _bllUltraRecord.Update(record);
            return Json(new ResultModel(true));
        }
    }
}
