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
    public class YearModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = bindingContext.ValueProvider.GetValue("Date");
            if (obj == null)
            {
                return DateTime.Now.Year;
            }
            var val = obj.AttemptedValue;
            var items = val.Split('-');
            if (items.Length == 0)
            {
                return null;
            }
            int result;
            if (!int.TryParse(items[0], out result))
            {
                return null;
            }
            return result;
        }
    }
    public class MonthModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = bindingContext.ValueProvider.GetValue("Date");
            if (obj == null)
            {
                return DateTime.Now.Year;
            }
            var val = obj.AttemptedValue;
            var items = val.Split('-');
            if (items.Length < 2)
            {
                return null;
            }
            int result;
            if (!int.TryParse(items[1], out result))
            {
                return null;
            }
            return result;
        }
    }
    [Authorize]
    public class ReportController : Controller
    {
        private BussinessLogicBase<RtMonthTime> _bllGap;
        private BussinessLogicBase<RtMonthData> _bllMonthData;
        public ReportController(BussinessLogicBase<RtMonthTime> bllGap, BussinessLogicBase<RtMonthData> bllMonthData)
        {
            _bllGap = bllGap;
            _bllMonthData = bllMonthData;
        }

        public ActionResult EconomicIndex([ModelBinder(typeof(YearModelBinder))]int year, [ModelBinder(typeof(MonthModelBinder))]int month)
        {
            var entities = _bllMonthData.Where(i => i.Year == year && i.Month == month);
            var items = entities.ToDictionary(i => i.RtPoint.PointName, i => i.Value);
            var model = new EconomicPageModel(items);
            model.Year = year;
            model.Month = month;
            return View(model);
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
