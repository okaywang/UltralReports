using AutoMapper;
using BussinessLogic;
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
    public class SmsLogController : Controller
    {
        private SmsLogBussinessLogic _bllSms;

        public SmsLogController(SmsLogBussinessLogic bllSms)
        {
            _bllSms = bllSms;
        }

        public ActionResult Index()
        {
            var model = new SmsLogListPageModel();
            model.Title = "人员组列表";
            model.RequestListUrl = "/SmsLog/List"; 
            return View(model);
        }

        public PartialViewResult List(SmsLogSearchCriteria criteria)
        {
            var entities = _bllSms.Search(criteria);
            var items = Mapper.Map<PagedList<SmsLog>, SmsLogListItemModel[]>(entities);
            var model = new PagedModel<SmsLogListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }
    }
}
