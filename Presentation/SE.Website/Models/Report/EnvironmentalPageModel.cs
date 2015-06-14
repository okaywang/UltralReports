﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Types;

namespace Website.Models
{
    public class EnvironmentalPageModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public MachineSetType MachineSet { get; set; }
        public EnvironmentalListItemModel[] Items { get; set; }
    }

    public class EnvironmentalListItemModel
    {
        public int Day { get; set; }

        public decimal? Col_1A脱硝率 { get; set; }

        public decimal? Col_1B脱硝率 { get; set; }

        public decimal? Col_1机综合脱硝率 { get; set; }

        public decimal? Col_1机NOx排放 { get; set; }

        public decimal? Col_1机SO2排放 { get; set; }

        public decimal? Col_1机粉尘排放 { get; set; }
    }
}