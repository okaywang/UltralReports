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
        [DisplayText("机组1")]
        MachineSet1 = 1,

        [DisplayText("机组2")]
        MachineSet2 = 2
    }
}
