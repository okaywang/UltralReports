using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class EconomicPageModel
    {

        private Dictionary<string, decimal?> Items { get; set; }
        public EconomicPageModel(Dictionary<string, decimal?> items)
        {
            Items = items;
        }

        public int Year { get; set; }

        public int Month { get; set; }

        public decimal? this[string key]
        {
            get
            {
                decimal? v;
                if (this.Items.TryGetValue(key, out v))
                {
                    return v;
                }
                return null;
            }
        }
    }
}