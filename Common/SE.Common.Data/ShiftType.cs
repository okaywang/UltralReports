using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Common.Types
{
    public enum ShiftType
    {
        [DisplayText("白班")]
        DayShift = 1,

        [DisplayText("中班")]
        MiddleShift = 2,

        [DisplayText("夜班")]
        NightShift = 3
    }
}
