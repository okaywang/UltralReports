﻿using AutoMapper;
using BussinessLogic;
using Common.Types;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using Website.Common;
using Website.Filters;
using Website.Models;

namespace Website.Controllers
{
    public class UltraRecordController : Controller
    {
        private UltraReportBussinessLogic _bllUltraRecord;
        private EquipmentBussinessLogic _bllEquipment;
        private MajorBussinessLogic _bllMajor;

        public UltraRecordController(UltraReportBussinessLogic bllUltraRecord, EquipmentBussinessLogic bllEquipment, MajorBussinessLogic bllMajor)
        {
            _bllUltraRecord = bllUltraRecord;
            _bllEquipment = bllEquipment;
            _bllMajor = bllMajor;
        }

        [RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult SummaryIndex()
        {
            var model = new UltraSummaryListPageModel();
            model.Title = "常规超限统计汇总列表";
            model.RequestListUrl = "/UltraRecord/SummaryList";
            var types = _bllEquipment.MonitorTypeGetAll();
            model.MonitorTypes = Mapper.Map<List<MonitorType>, NameValuePair[]>(types);
            return View(model);
        }

        [RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult SummaryList(UltraSummarySearchCriteria criteria)
        {
            var entities = _bllUltraRecord.SearchSummary(criteria);
            var items = Mapper.Map<PagedList<UltraSummary>, UltraSummaryListItemModel[]>(entities);
            var model = new PagedModel<UltraSummaryListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        [RequireAuthority(AuthorityNames.NormalUltraReport)]
        public ActionResult List(UltraRecordSearchCriteria criteria)
        {
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<List<UltraRecord>, UltraRecordListItemModel[]>(entities);
            var model = new UltraRecordListPageModel();
            model.Records = new PagedModel<UltraRecordListItemModel>();
            if (criteria.PartId.HasValue)
            {
                var part = _bllEquipment.PartGet(criteria.PartId.Value);
                model.PartName = part.Name;
                model.EquipmentName = part.Equipment.Name;
                model.Records.PagingResult = entities.PagingResult;
                model.Records.Items = items;

            }
            return PartialView(model);
        }

        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public ActionResult ProUltraRecordIndex()
        {
            var model = new ProUltraRecordListPageModel();
            model.Title = "专业超限统计查询";
            model.RequestListUrl = "/UltraRecord/ProUltraRecordList";

            var majors = _bllMajor.GetAll();
            model.Majors = Mapper.Map<List<Major>, NameValuePair[]>(majors);
            return View(model);
        }

        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public ActionResult ProUltraRecordList(UltraRecordSearchCriteria criteria)
        {
            criteria.SearchProRecord = true;
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<PagedList<UltraRecord>, ProUltraRecordListItemModel[]>(entities);
            var model = new PagedModel<ProUltraRecordListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        [HttpPost]
        [RequireAuthority(AuthorityNames.ProUltraReport)]
        public JsonResult Reason(UltroReasonModel model)
        {
            //UserContext.Current.MajorId 
            var record = _bllUltraRecord.Get(model.Id);
            if (!UserContext.Current.MajorId.HasValue || UserContext.Current.MajorId != record.Part.MajorId)
            {
                return Json(new ResultModel(false, "对不起，您无权限填报！"));
            }
            record.Remarks = model.Reason;
            _bllUltraRecord.Update(record);
            return Json(new ResultModel(true));
        }
    }
}
