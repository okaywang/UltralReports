using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{ 
    public class IndicatorItemModel
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public DateTime EffectiveTime { get; set; }
    }
}