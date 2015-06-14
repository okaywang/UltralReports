using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
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

        //SELECT distinct SenderTime FADateTime,FlowID GroupName,TaskID SmsType,Context Content
        //FROM Message 
        //WHERE  SenderID = '超限报警' 
        //      and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-01'
        //      and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-02'
        //order by SenderTime asc;

        public PagedList<SmsLogItem> Search(SmsLogSearchCriteria criteria)
        {
            var sb = new StringBuilder();
            sb.AppendLine("select rownum RowIndex,FADateTime,GroupName,SmsType,Content from");
            sb.AppendLine("(");
            sb.AppendLine(@"SELECT distinct SenderTime FADateTime,FlowID GroupName,TaskID SmsType,Context Content
                            FROM Message 
                            WHERE  SenderID = '超限报警' ");
            sb.AppendLine("and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-01'");
            sb.AppendLine("and to_char(SenderTime,'yyyy-mm-dd')>='2015-06-02'");
            sb.AppendLine("order by SenderTime asc");
            sb.Append(")a");
            var sql = sb.ToString();

            var sb1 = new StringBuilder("with tmpTable as");
            sb1.AppendLine("(");
            sb1.AppendLine(sql);
            sb1.AppendLine(")");
            sb1.AppendFormat("select * from tmpTable where RowIndex between {0} and {1}", criteria.PagingRequest.PageIndex * criteria.PagingRequest.PageSize + 1, (criteria.PagingRequest.PageIndex + 1) * criteria.PagingRequest.PageSize);

            var sql1 = sb1.ToString();

            var sb2 = new StringBuilder("with tmpTable2 as");
            sb2.AppendLine("(");
            sb2.AppendLine(sql);
            sb2.AppendLine(")");
            sb2.AppendLine("select COUNT(*) from tmpTable2");

            var sql2 = sb2.ToString();

            var result = new PagedList<SmsLogItem>();
            result.PagingResult = new WebExpress.Core.Paging.PagingResult(criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);


            string cnstr = @"Data Source=mas;User Id=foaapp;Password=foaapp;";
            using (var cn = new OracleConnection(cnstr))
            { 
                using (var cm = new OracleCommand(string.Empty, cn))
                {
                    cm.CommandText = sql1;
                    var reader = cm.ExecuteReader();
                    var items = new List<SmsLogItem>();
                    while (reader.Read())
                    {
                        var item = new SmsLogItem();
                        item.Content = reader["Content"].ToString();
                        item.FADateTime = Convert.ToDateTime(reader["FADateTime"]);
                        item.GroupName = reader["GroupName"].ToString();
                        item.SmsType = Convert.ToInt32(reader["SmsType"]); 
                        items.Add(item);
                    }
                    result.AddRange(items);

                    cm.CommandText = sql2;
                    result.PagingResult.TotalCount = Convert.ToInt32(cm.ExecuteScalar());
                }
            }
            return result;
        }

        public PagedList<SmsLog> Search2(SmsLogSearchCriteria criteria)
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
