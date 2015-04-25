using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
using Common.Types;

namespace BussinessLogic
{
    public class UltraSummarySearchCriteria : SearchCriteria<UltraSummary>
    {
        public bool SearchProRecord { get; set; }

        public MachineSetType? MachineSet { get; set; }

        public int? Duty { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string EquipmentNamePart { get; set; }

        public int? MonitorTypeId { get; set; }
    }

    public class UltraRecordSearchCriteria : SearchCriteria<UltraRecord>
    {
        public bool SearchProRecord { get; set; }
         
        public int? PartId { get; set; } 

        public int? Duty { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? MonitorTypeId { get; set; }
    }
}
