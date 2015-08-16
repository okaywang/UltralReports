using ReprotDal.Model;
using Rinch.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprotDal.Repo
{
    public class MonthTimeRepo
    {
        private readonly Database dataBase = new Database(Config.DbConnectionString);

        public IEnumerable<MonthTime> GetTimes(int year,int month)
        {
            string sql = @"SELECT [Year],[Month],[StartTime],[EndTime] FROM [RtMonthTime] where [Year] = @pyear AND [Month] = @pmonth ";
            IEnumerable<MonthTime> monthTimeList = dataBase.ExecuteDataReader<MonthTime>(sql, new { pyear = year, pmonth = month }, dr => { return GetByDataReader(dr); }
            );
            return monthTimeList;
        }
        private MonthTime GetByDataReader(DbDataReader dr)
        {
            try
            {
                return new MonthTime
                {
                    Year = (int)dr["Year"],
                    Month = (int)dr["Month"],
                    StartTime = (DateTime)dr["StartTime"],
                    EndTime = (DateTime)dr["EndTime"]
                };
            }
            catch
            {

            }
            return null;
        }
    }
}
