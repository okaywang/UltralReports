using BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class KPIListPageModel
    {
        public KPIWeightItem[] Weights { get; set; }

        public KPIDataItem[] Data { get; set; }
    }

    public class IndicatorItemModel
    {
        public int ItemType { get; set; }

        public string Name { get; set; }

        [DisplayName("权重")]
        public int Weight { get; set; }

        [DisplayName("生效时间")]
        public DateTime BeginDate { get; set; }
    }

    public class KpiGroupInfo
    {
        public decimal Max { get; set; }

        public decimal Delta { get; set; }

        public decimal Addition { get; set; }
    }
}