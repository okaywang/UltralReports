using Common.Types;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class PartSearchCriteria : SearchCriteria<Part>
    { 
        public MachineSetType? MachineSet { get; set; }

        public string EquipmentName { get; set; }

        public string PartName { get; set; }
         
        public string UserName { get; set; } 
    }
}
