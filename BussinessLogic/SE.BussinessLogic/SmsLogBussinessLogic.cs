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
            //string conn = @"Data Source=mas;User Id=foaapp;Password=foaapp;";
            //OracleConnection oc = new OracleConnection(conn);

            //try
            //{
            //    oc.Open();
            //    //OracleCommand 被标注为已过时
            //    OracleCommand cmd = oc.CreateCommand();
            //    cmd.CommandText = "select * from message where to_char(sendertime,'yyyy-mm-dd')= to_char(sysdate,'yyyy-mm-dd')";
            //    OracleDataReader odr = cmd.ExecuteReader();
            //    while (odr.Read())
            //    {
            //        Console.WriteLine(odr.GetOracleDateTime(0).ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    oc.Close();
            //}

        }

//SELECT distinct SenderTime FADateTime,FlowID GroupName,TaskID SmsType,Context Content
//FROM Message 
//WHERE  SenderID = '超限报警' 
//      and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-01'
//      and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-02'
//order by SenderTime asc;

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
