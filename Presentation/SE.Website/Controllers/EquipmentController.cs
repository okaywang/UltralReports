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
    public class EquipmentController : Controller
    {
        private EquipmentBussinessLogic _bllEquipment;
        //private PersonBussinessLogic _personBll;
        //public AccountController(ShopBussinessLogic shopBll, AccountBussinessLogic accountBll, PersonBussinessLogic personBll)
        //{
        //    _shopBll = shopBll;
        //    _accountBll = accountBll;
        //    _personBll = personBll;
        //}

        public EquipmentController(EquipmentBussinessLogic bllEquipment)
        {
            _bllEquipment = bllEquipment;
        }
        //
        // GET: /Equipment/

        #region Equipment
        public ActionResult Index()
        {
            var model = new EquipmentListPageModel();
            model.Title = "设备列表";
            model.RequestListUrl = "/Equipment/List";
            model.AddItemUrl = "/Equipment/Add";
            return View(model);
        }

        public PartialViewResult List()
        {
            var entities = _bllEquipment.GetAll();

            var items = Mapper.Map<List<Equipment>, List<EquipmentListItemModel>>(entities);
            var model = new PagedModel<EquipmentListItemModel>();
            model.Items = items.ToArray();
            return PartialView("_CommonList", model);
        }

        public JsonResult Get(MachineSetType machineSet)
        {
            var pairs = new NameValuePair[0];
            if (Enum.IsDefined(typeof(MachineSetType), machineSet))
            {
                var entities = _bllEquipment.Where(i => i.MachineSet == machineSet).ToList();
                pairs = Mapper.Map<List<Equipment>, NameValuePair[]>(entities);
            }
            return Json(pairs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(EquipmentAddModel model)
        {
            var entity = Mapper.Map<EquipmentAddModel, Equipment>(model);
            _bllEquipment.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Update(EquipmentUpdateModel model)
        {
            var entity = _bllEquipment.Get(model.Id);
            entity.MachineSet = model.MachineSet;
            entity.MonitorTypeId = model.MonitorTypeId;
            entity.Name = model.Name;
            entity.Description = model.Description;
            _bllEquipment.Update(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult Delete(int id)
        {
            var entity = _bllEquipment.Get(id);
            _bllEquipment.Delete(entity);
            return Json(new ResultModel(true));
        }
        #endregion

        #region Monitor Type
        public ActionResult MonitorTypeIndex()
        {
            var model = new MonitorTypeListPageModel();
            model.Title = "监控类型列表";
            model.RequestListUrl = "/Equipment/MonitorTypeList";
            model.AddItemUrl = "/Equipment/MonitorTypeAdd";
            return View(model);
        }

        public PartialViewResult MonitorTypeList()
        {
            var entities = _bllEquipment.MonitorTypeGetAll();

            var items = Mapper.Map<List<MonitorType>, List<MonitorTypeListItemModel>>(entities);
            var model = new PagedModel<MonitorTypeListItemModel>();
            model.Items = items.ToArray();
            return PartialView("_CommonList", model);
        }

        public JsonResult MonitorTypeAdd(MonitorTypeAddModel model)
        {
            var entity = new MonitorType() { Name = model.Name };
            _bllEquipment.MonitorTypeAdd(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult MonitorTypeUpdate(SmsGroupUpdateModel model)
        {
            var entity = _bllEquipment.MonitorTypeGet(model.Id);
            entity.Name = model.Name;
            _bllEquipment.MonitorTypeUpdate(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult MonitorTypeDelete(int id)
        {
            var entity = _bllEquipment.MonitorTypeGet(id);
            _bllEquipment.MonitorTypeDelete(entity);
            return Json(new ResultModel(true));
        }
        #endregion

        #region Part
        public ActionResult PartIndex()
        {
            var model = new PartListPageModel();
            model.Title = "监控类型列表";
            model.RequestListUrl = "/Equipment/PartList";
            model.AddItemUrl = "/Equipment/PartAdd";
            return View(model);
        }

        public PartialViewResult PartList()
        {
            var entities = _bllEquipment.PartGetAll();

            var items = Mapper.Map<List<Part>, List<PartListItemModel>>(entities);
            var model = new PagedModel<PartListItemModel>();
            model.Items = items.ToArray();
            return PartialView("_CommonList", model);
        }

        public JsonResult PartAdd(PartAddModel model)
        {
            var entity = Mapper.Map<PartAddModel, Part>(model);
            _bllEquipment.PartAdd(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult PartUpdate(PartUpdateModel model)
        {
            var entity = _bllEquipment.PartGet(model.Id);
            entity.Name = model.Name;
            _bllEquipment.PartUpdate(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult PartDelete(int id)
        {
            var entity = _bllEquipment.PartGet(id);
            _bllEquipment.PartDelete(entity);
            return Json(new ResultModel(true));
        }
        #endregion
    }
}
