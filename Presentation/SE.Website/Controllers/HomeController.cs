using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{ 
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Table1()
        {
            var model = new Table1Model();
            model.A1 = 10;
            model.C1 = 20;

            model.D2 = 3;
            return PartialView("_Table1Partial", model);
        }
    }
}
