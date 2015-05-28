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
    public class ReportController : Controller
    {
        public ActionResult EconomicIndex()
        {
            return View();
        }

        public ActionResult EnvironmentalIndex()
        {
            return View();
        }
    }
}
