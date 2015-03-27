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
    public class SmsController : Controller
    {
        private SmsBussinessLogic _bllSms;
        //private PersonBussinessLogic _personBll;
        //public AccountController(ShopBussinessLogic shopBll, AccountBussinessLogic accountBll, PersonBussinessLogic personBll)
        //{
        //    _shopBll = shopBll;
        //    _accountBll = accountBll;
        //    _personBll = personBll;
        //}

        public SmsController(SmsBussinessLogic bllSms)
        {
            _bllSms = bllSms;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Recipient
        public ActionResult RecipientIndex()
        {
            return null;
        }

        public ActionResult RecipientList()
        {
            return null;
        }

        public JsonResult RecipientAdd()
        {
            return null;
        }

        public JsonResult RecipientUpdate()
        {
            return null;
        }

        public JsonResult RecipientDelete()
        {
            return null;
        }
        #endregion

        #region Group
        public ActionResult GroupIndex()
        {
            var model = new SmsGroupListPageModel();
            model.Title = "人员组列表";
            model.RequestListUrl = "/Sms/GroupList";
            model.AddItemUrl = "/Sms/GroupAdd";
            return View(model);
        }

        public PartialViewResult GroupList()
        {
            var groups = _bllSms.SmsGroupGetAll();

            var items = new List<SmsGroupListItemModel>();
            foreach (var item in groups)
            {
                items.Add(new SmsGroupListItemModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            var model = new PagedModel<SmsGroupListItemModel>();
            model.Items = items.ToArray();
            return PartialView("_CommonList", model);
        }

        public JsonResult GroupAdd(SmsGroupAddModel model)
        {
            var entity = new SmsGroup() { Name = model.Name };
            _bllSms.Insert(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult GroupUpdate()
        {
            return null;
        }

        public JsonResult GroupDelete()
        {
            return null;
        }
        #endregion
    }

    public class SmsGroupListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }
}
