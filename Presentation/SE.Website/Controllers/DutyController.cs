using Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic;
using DataAccess;
using Website.Models;
using AutoMapper;

namespace Website.Controllers
{
    public class DutyController : Controller
    {
        private DutyBussinessLogic _bllDuty;
        public DutyController(DutyBussinessLogic bllDuty)
        {
            _bllDuty = bllDuty;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DutyTimeIndex()
        {
            var times = _bllDuty.DutyTimeGetAll();
            var duties = _bllDuty.GetAll();
            var model = new DutyIndexModel();
            model.DutyTimes = Mapper.Map<List<DutyTime>, DutyTimeModel[]>(times);
            model.Duties = Mapper.Map<List<Duty>, DutyModel[]>(duties);
            return View(model);
        }

        public JsonResult DutyTimeUpdate(DutyTimeModel[] model)
        {
            foreach (var item in model)
            {
                var entity = _bllDuty.DutyTimeGet(item.Id);
                entity.StartTime = item.StartTime;
                entity.EndTime = item.EndTime;
                _bllDuty.DutyTimeUpdate(entity);
            }
            return Json(new ResultModel(true));
        }

        public JsonResult DutyUpdate(DutyModel[] model)
        {
            var entities = new List<Duty>();
            foreach (var item in model)
            {
                var entity = _bllDuty.Get(item.DayId, item.TimeId);
                entity.DutyValue = item.DutyValue;
                entities.Add(entity);
            }
            _bllDuty.Update(entities);
            return Json(new ResultModel(true));
        }
    }
}
