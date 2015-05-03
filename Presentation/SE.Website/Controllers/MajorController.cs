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
    [Authorize]
    public class MajorController : Controller
    {
        private MajorBussinessLogic _bllMajor;

        public MajorController(MajorBussinessLogic bllMajor)
        {
            _bllMajor = bllMajor;
        }

        public ActionResult Index()
        {
            var model = new MajorListPageModel();
            model.Title = "专业管理";
            model.RequestListUrl = "/Major/List";
            model.AddItemUrl = "/Major/Add";
            return View(model);
        }

        public PartialViewResult List()
        {
            var entities = _bllMajor.GetAll();

            var items = Mapper.Map<List<Major>, List<MajorListItemModel>>(entities);
            var model = new PagedModel<MajorListItemModel>();
            model.Items = items.ToArray();
            return PartialView("_CommonList", model);
        }

        public JsonResult Add(MajorAddModel model)
        {
            var entity = new Major() { Name = model.Name };
            _bllMajor.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Update(SmsGroupUpdateModel model)
        {
            var entity = _bllMajor.Get(model.Id);
            entity.Name = model.Name;
            _bllMajor.Update(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Delete(int id)
        {
            var entity = _bllMajor.Get(id);
            _bllMajor.Delete(entity);
            return Json(new ResultModel(true));
        }
    }
}
