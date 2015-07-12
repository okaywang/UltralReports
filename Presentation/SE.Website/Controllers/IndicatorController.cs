using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class IndicatorController : Controller
    {
        //
        // GET: /Indicator/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weight()
        {
            var IndicatorNames = new[] { "#1机主汽温越限", "#1机再热汽温越限", "#1机主汽温限内偏差", "#1机再热汽温限内偏差", "#1机排烟损失", "#1机管壁超温", "#1机氨单耗", "综合厂用电率", "#1负荷完成率", "全厂负荷完成率" };
            var model = new IndicatorItemModel[10];
            for (int i = 0; i < model.Length; i++)
            {
                model[i] = new IndicatorItemModel
                {
                    Name = IndicatorNames[i],
                    EffectiveTime = DateTime.Now.AddMonths(1),
                    Weight = 3
                };

            }
            return View(model);
        }
    }
}
