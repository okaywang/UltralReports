using Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class DutyIndexModel
    {
        public DutyTimeModel[] DutyTimes { get; set; }

        public DutyModel[] Duties { get; set; }
    }


    public class DutyTimeModel
    {
        public DutyTimeType Id { get; set; }

        public System.TimeSpan StartTime { get; set; }

        public System.TimeSpan EndTime { get; set; }
    }

    public class DutyModel
    {
        public int DayId { get; set; }

        public int TimeId { get; set; }

        public DutyType DutyValue { get; set; }
    }
}