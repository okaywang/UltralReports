using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class SmsLogBussinessLogic : BussinessLogicBase<SmsLog>
    {
        public SmsLogBussinessLogic(EfRepository<SmsLog> repository)
            : base(repository)
        {
        }

        public PagedList<SmsLog> Search(SmsLogSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<SmsLog>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = PrimaryRepository.Table;
            if (criteria.StartTime.HasValue)
            {
                query = query.Where(i => i.FADateTime >= criteria.StartTime.Value);
            }
            if (criteria.EndTime.HasValue)
            {
                var end = criteria.EndTime.Value.AddDays(1);
                query = query.Where(i => i.FADateTime < end);
            }
            query = query.OrderBy<SmsLog>(criteria.OrderByFields);
            var result = new PagedList<SmsLog>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
    }
}
