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

        public ActionResult Index()
        {
            return View();
        }


        #region Group
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

            var items = new List<MonitorTypeListItemModel>();
            foreach (var item in entities)
            {
                items.Add(new MonitorTypeListItemModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

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
    }
}
