using AutoMapper;
using BussinessLogic;
using BussinessLogic.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using Website.Filters;
using Website.Models;

namespace Website.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private BussinessLogicBase<RtMonthTime> _bllGap;
        public ReportController(BussinessLogicBase<RtMonthTime> bllGap)
        {
            _bllGap = bllGap;
        }
        public ActionResult EconomicIndex()
        {
            return View();
        }

        public ActionResult EnvironmentalIndex()
        {
            return View();
        }

        public ActionResult GapIndex()
        {
            var model = new GapListPageModel();
            model.Title = "停机时间设置";
            model.RequestListUrl = "/Report/GapList";
            return View(model);
        }

        public PartialViewResult GapList(GapSearchCriteria criteria)
        {
            var entities = _bllGap.Where(i => i.Year == criteria.Year && i.Month == criteria.Month).ToList();
            var items = AutoMapper.Mapper.Map<List<RtMonthTime>, GapListItemModel[]>(entities);
            var model = new PagedModel<GapListItemModel>() { Items = items };
            return PartialView("_CommonList", model);
        }

        public JsonResult GapAdd(GapAddModel model)
        {
            var entity = new RtMonthTime();
            entity.StartTime = model.StartTime;
            entity.EndTime = model.EndTime;
            entity.Year = model.StartTime.Year;
            entity.Month = model.StartTime.Month;
            _bllGap.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult GapUpdate(GapUpdateModel model)
        {
            var entity = _bllGap.Get(model.Id);
            entity.StartTime = model.StartTime;
            entity.EndTime = model.EndTime; 
            _bllGap.Update(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult GapRemove(int id)
        {
            var entity = _bllGap.Get(id);
            _bllGap.Delete(entity);
            return Json(new ResultModel(true));
        }

    }
}
