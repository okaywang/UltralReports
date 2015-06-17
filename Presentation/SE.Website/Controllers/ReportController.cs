﻿using AutoMapper;
using BussinessLogic;
using BussinessLogic.Entities;
using Common.Types;
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
                return DateTime.Now.Month;
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
        private Dictionary<int, string[]> _colPoints = new Dictionary<int, string[]>();

        private BussinessLogicBase<RtMonthTime> _bllGap;
        private BussinessLogicBase<RtMonthData> _bllMonthData;
        private BussinessLogicBase<RtDayData> _bllDayData;
        public ReportController(BussinessLogicBase<RtMonthTime> bllGap, BussinessLogicBase<RtMonthData> bllMonthData, BussinessLogicBase<RtDayData> bllDayData)
        {
            _bllGap = bllGap;
            _bllMonthData = bllMonthData;
            _bllDayData = bllDayData;

            _colPoints.Add(0, new[] { "Fysis.U1DCSAI.G1308", "Fysis.U2DCSAI.G1308" });
            _colPoints.Add(1, new[] { "Fysis.U1DCSAI.G1310", "Fysis.U2DCSAI.G1310" });
            _colPoints.Add(2, new[] { "Fysis.CALC.C1002", "Fysis.CALC.C2002" });
            _colPoints.Add(3, new[] { "Fysis.TLOPCRTS.TLAIO536", "Fysis.TLOPCRTS.TLAIO538" });
            _colPoints.Add(4, new[] { "Fysis.TLOPCRTS.TLAIO535", "Fysis.TLOPCRTS.TLAIO539" });
            _colPoints.Add(5, new[] { "Fysis.TLOPCRTS.TLAIO537", "Fysis.TLOPCRTS.TLAIO540" });
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

        public ActionResult EnvironmentalIndex([ModelBinder(typeof(YearModelBinder))]int year, [ModelBinder(typeof(MonthModelBinder))]int month, MachineSetType machineSet = MachineSetType.MachineSet1)
        {
            var entiteis = _bllDayData.Where(i => i.RtPoint.MachNO == (int)machineSet && i.DayTime.Year == year && i.DayTime.Month == month).ToList();
            var model = new EnvironmentalPageModel();
            model.Year = year;
            model.Month = month;
            model.MachineSet = machineSet;
            var days = DateTime.DaysInMonth(year, month);
            model.Items = new EnvironmentalListItemModel[days];
            for (int i = 1; i <= days; i++)
            {
                var item = new EnvironmentalListItemModel();
                item.Day = i;
                var dayEntities = entiteis.Where(p => p.DayTime.Day == i).ToList();
                if (dayEntities.Any())
                {
                    var machNo = (int)machineSet - 1;
                    var tmp1 = dayEntities.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[0][machNo]);
                    if (tmp1 != null)
                    {
                        item.Col_1A脱硝率 = tmp1.Value;
                    }
                    var tmp2 = dayEntities.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[1][machNo]);
                    if (tmp2 != null)
                    {
                        item.Col_1B脱硝率 = tmp2.Value;
                    }
                    var tmp3 = dayEntities.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[2][machNo]);
                    if (tmp3 != null)
                    {
                        item.Col_1机综合脱硝率 = tmp3.Value;
                    }
                    var tmp4 = dayEntities.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[3][machNo]);
                    if (tmp4 != null)
                    {
                        item.Col_1机NOx排放 = tmp4.Value;
                    }
                    var tmp5 = entiteis.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[4][machNo]);
                    if (tmp5 != null)
                    {
                        item.Col_1机SO2排放 = tmp5.Value;
                    }
                    var tmp6 = dayEntities.SingleOrDefault(p => p.RtPoint.PointName == _colPoints[5][machNo]);
                    if (tmp6 != null)
                    {
                        item.Col_1机粉尘排放 = tmp6.Value;
                    }
                }

                model.Items[i - 1] = item;
            }
            return View(model);
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
