using AutoMapper;
using BussinessLogic;
using Common.Types;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Common;
using Website.Models;

namespace Website.Controllers
{
    public class UltraRecordController : Controller
    {
        private UltraReportBussinessLogic _bllUltraRecord;

        public UltraRecordController(UltraReportBussinessLogic bllUltraRecord)
        {
            _bllUltraRecord = bllUltraRecord;
        }

        public ActionResult Index()
        {
            var model = new UltraRecordListPageModel();
            model.Title = "超限统计列表";
            model.RequestListUrl = "/UltraRecord/List";
            //model.AddItemUrl = "/Equipment/Add";
            return View(model);
        }

        public ActionResult List(UltraSummarySearchCriteria criteria)
        {
            var entities = _bllUltraRecord.SearchSummary(criteria);
            var items = Mapper.Map<List<UltraSummary>, UltraSummaryListItemModel[]>(entities);
            var model = new PagedModel<UltraSummaryListItemModel>();
            model.Items = items;
            return PartialView("_CommonList", model);
        }

    }
}
