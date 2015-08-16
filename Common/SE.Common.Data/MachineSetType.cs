using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Common.Types
{
    public enum MachineSetType
    {
        [DisplayText("1号机组")]
        MachineSet1 = 1,

        [DisplayText("2号机组")]
        MachineSet2 = 2,

        [DisplayText("公用系统")]
        MachineSet3 = 3,
    }

    public enum SimpleMachineSetType
    {
        [DisplayText("1号机组")]
        MachineSet1 = 1,

        [DisplayText("2号机组")]
        MachineSet2 = 2
    }
}
