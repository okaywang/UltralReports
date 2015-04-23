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
using Website.Models;

namespace Website.Controllers
{
    public class UltraRecordController : Controller
    {
        private UltraReportBussinessLogic _bllUltraRecord;

        public UltraRecordController(UltraReportBussinessLogic bllUltraRecord)
        {
            _bllUltraRecord = bllUltraRecord;
        }

        public ActionResult SummaryIndex()
        {
            var model = new UltraSummaryListPageModel();
            model.Title = "常规超限统计汇总列表";
            model.RequestListUrl = "/UltraRecord/SummaryList";
            //model.AddItemUrl = "/Equipment/Add";
            return View(model);
        }

        public ActionResult SummaryList(UltraSummarySearchCriteria criteria)
        {
            var entities = _bllUltraRecord.SearchSummary(criteria);
            var items = Mapper.Map<PagedList<UltraSummary>, UltraSummaryListItemModel[]>(entities);
            var model = new PagedModel<UltraSummaryListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        public ActionResult ProSummaryIndex()
        {
            var model = new ProUltraSummaryListPageModel();
            model.Title = "专业超限统计汇总列表";
            model.RequestListUrl = "/UltraRecord/ProSummaryList";
            //model.AddItemUrl = "/Equipment/Add";
            return View(model);
        }

        public ActionResult ProSummaryList(UltraSummarySearchCriteria criteria)
        {
            criteria.SearchProRecord = true;
            var entities = _bllUltraRecord.SearchSummary(criteria);
            var items = Mapper.Map<PagedList<UltraSummary>, ProUltraSummaryListItemModel[]>(entities);
            var model = new PagedModel<ProUltraSummaryListItemModel>();
            model.Items = items;
            model.PagingResult = entities.PagingResult;
            return PartialView("_CommonList", model);
        }

        public ActionResult Index()
        {
            var model = new UltraRecordListPageModel();
            model.Title = "超限统计明细列表";
            model.RequestListUrl = "/UltraRecord/List";
            return View(model);
        }

        public ActionResult List(UltraRecordSearchCriteria criteria)
        {
            var entities = _bllUltraRecord.Search(criteria);
            var items = Mapper.Map<List<UltraRecord>, UltraRecordListItemModel[]>(entities);
            var model = new PagedModel<UltraRecordListItemModel>();
            model.PagingResult = entities.PagingResult;
            model.Items = items;
            return PartialView("_CommonList", model);
        }
    }
}
