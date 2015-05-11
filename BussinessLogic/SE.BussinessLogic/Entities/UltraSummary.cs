using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class UltraSummary
    {
        public int PartId { get; set; }

        public string PartName { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; }

        public string MonitorTypeName { get; set; }

        public decimal L1 { get; set; }

        public decimal H1 { get; set; }

        public int Duty { get; set; }

        public int Times { get; set; }

        public int Duration { get; set; }

        public string MajorName { get; set; }

        public string Remarks { get; set; }
    }
}
