using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using Website.Models;

namespace Website.Controllers
{
    public class CommaSeparatedModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var val = bindingContext.ValueProvider.GetValue("val");
            return val.AttemptedValue.Split(',').Select(i => int.Parse(i)).ToArray();
        }
    }

    public class SmsController : Controller
    {
        private SmsBussinessLogic _bllSms;
        private AccountBussinessLogic _bllAccount;

        public SmsController(SmsBussinessLogic bllSms, AccountBussinessLogic bllAccount)
        {
            _bllSms = bllSms;
            _bllAccount = bllAccount;
        }

        public string Test([ModelBinder(typeof(CommaSeparatedModelBinder))]int[] ids)
        {
            return string.Join("___", ids);
        }


        public ActionResult Index()
        {
            return View();
        }

        //#region Recipient
        //public ActionResult RecipientIndex()
        //{
        //    var model = new SmsRecipientListPageModel();
        //    model.Title = "人员组列表";
        //    model.RequestListUrl = "/Sms/RecipientList";
        //    model.AddItemUrl = "/Sms/RecipientAdd";
        //    return View(model);
        //}

        //public PartialViewResult RecipientList()
        //{
        //    var groups = _bllSms.GetAll();

        //    var items = new List<SmsRecipientListItemModel>();
        //    foreach (var item in groups)
        //    {
        //        items.Add(new SmsRecipientListItemModel()
        //        {
        //            Id = item.Id,
        //            Name = item.Name,
        //            PhoneNumber = item.PhoneNumber
        //        });
        //    }

        //    var model = new PagedModel<SmsRecipientListItemModel>();
        //    model.Items = items.ToArray();
        //    return PartialView("_CommonList", model);
        //}

        //public JsonResult RecipientAdd(SmsRecipientAddModel model)
        //{
        //    var entity = new SmsRecipient()
        //    {
        //        Name = model.Name,
        //        PhoneNumber = model.PhoneNumber
        //    };
        //    foreach (var item in model.GroupIds)
        //    {
        //        var groupEntity = _bllSms.SmsGroupGet(item);
        //        entity.SmsGroups.Add(groupEntity);
        //    }

        //    _bllSms.Insert(entity);
        //    return Json(new ResultModel(true));
        //}

        //public JsonResult RecipientUpdate(SmsRecipientUpdateModel model)
        //{
        //    var entity = _bllSms.Get(model.Id);
        //    entity.Name = model.Name;
        //    entity.PhoneNumber = model.PhoneNumber;
        //    _bllSms.Update(entity);
        //    return Json(new ResultModel(true));
        //}

        //public JsonResult RecipientDelete(int id)
        //{
        //    var entity = _bllSms.Get(id);
        //    _bllSms.Delete(entity);
        //    return Json(new ResultModel(true));
        //}
        //#endregion

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
                var m = new SmsGroupListItemModel();
                m.Id = item.Id;
                m.Name = item.Name;
                m.Recipients = item.SmsGroupAccounts.Select(i => AutoMapper.Mapper.Map<Account, NameValuePair>(i.Account)).ToArray();
                items.Add(m);
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

        public JsonResult GroupUpdate(SmsGroupUpdateModel model)
        {
            var entity = _bllSms.SmsGroupGet(model.Id);
            entity.Name = model.Name;
            _bllSms.SmsGroupUpdate(entity);
            return Json(new ResultModel(true));
        }

        public JsonResult GroupDelete(int id)
        {
            var entity = _bllSms.SmsGroupGet(id);
            _bllSms.SmsGroupDelete(entity);
            return Json(new ResultModel(true));
        }
        #endregion

        public JsonResult AssociateAccount(int groupId, int accountId)
        {
            _bllSms.Insert(new SmsGroupAccount { GroupId = groupId, AccountId = accountId, FADateTime = DateTime.Now });
            return Json(new ResultModel(true));
        }

        public JsonResult UnassociateAccount(int groupId, int accountId)
        {
            var entity = _bllSms.Get(groupId, accountId);
            _bllSms.Delete(entity);
            return Json(new ResultModel(true));
        }
        
        public JsonResult UnassociatedAccounts(int groupId)
        {
            var entities = _bllAccount.Where(i => i.SmsGroupAccounts.All(p => p.GroupId != groupId)).ToList();
            var pairs = AutoMapper.Mapper.Map<List<Account>, NameValuePair[]>(entities);
            return Json(new ResultModel(true, "success", pairs), JsonRequestBehavior.AllowGet);
        }
    }
}
