using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class SmsLogSearchCriteria : SearchCriteria<SmsLog>
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }

    public class SmsLogItem
    {
        public DateTime FADateTime { get; set; }
        public string GroupName { get; set; }
        public string Content { get; set; }
        public int SmsType { get; set; }
    }
}
