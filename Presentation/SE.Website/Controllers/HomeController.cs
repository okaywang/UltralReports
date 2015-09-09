using ReportWS;
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

        private CalcMonthReport instance = new ReportWS.CalcMonthReport();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Table1()
        {
            var model = new Table1Model();
            model.A1 = instance.GetValue("FYSIS.U1DCSAI.D1020");
            model.B1 = instance.GetValue("Fysis.CALC.A1003");
            model.C1 = instance.GetValue("Fysis.CALC.A1007");
            model.D1 = instance.GetValue("Fysis.CALC.A1012");
            model.E1 = instance.GetValue("Fysis.CALC.A1015");
            model.F1 = instance.GetValue("Fysis.CALC.A1016");
            model.G1 = instance.GetValue("Fysis.TLOPCRTS.TLAIO535");
            model.H1 = instance.GetValue("Fysis.CALC.C0002");

            model.A2 = instance.GetValue("FYSIS.U2DCSAI.D1020");
            model.B2 = instance.GetValue("Fysis.CALC.A2003");
            model.C2 = instance.GetValue("Fysis.CALC.A2007");
            model.D2 = instance.GetValue("Fysis.CALC.A2012");
            model.E2 = instance.GetValue("Fysis.CALC.A2015");
            model.F2 = instance.GetValue("Fysis.CALC.A2016");
            model.G2 = instance.GetValue("Fysis.TLOPCRTS.TLAIO538");

            return PartialView("_Table1Partial", model);
        }
    }
}
