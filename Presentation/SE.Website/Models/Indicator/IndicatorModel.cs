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
        private static readonly KPIWeightItem[] _weights;
        static KPIListPageModel()
        {
            _weights = new KPIWeightItem[10];
            var weights = new[] {10, 10, 10, 10, 10, 20, 10, 20, 10, 10};
            var ranges = new[] { "3-10", "3-10", "3-10", "3-10", "3-10", "5-20", "3-10", "10-20", "3-10", "3-10"};
            for (int i = 1; i <= _weights.Length; i++)
            {
                _weights[i - 1] = new KPIWeightItem
                {
                    ItemType = i,
                    Weight = weights[i - 1],
                    Range = ranges[i - 1]
                };
            }

        }

        public KPIWeightItem[] Weights { get { return _weights; } }

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