using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Common.Types
{
    public enum DutyTimeType
    {
        [DisplayText("夜班")]
        NightShift = 1,

        [DisplayText("白班")]
        DayShift = 2,

        [DisplayText("中班")]
        MiddleShift = 3
    }
}
