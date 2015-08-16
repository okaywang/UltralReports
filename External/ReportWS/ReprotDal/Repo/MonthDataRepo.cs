using Rinch.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprotDal.Repo
{
    public class MonthDataRepo
    {
        private readonly Database dataBase = new Database(Config.DbConnectionString);
        public void Insert(int pointId, double value, int year,int month)
        {
            string sql = @"Delete RtMonthData where Year = @pyear and Month = @pmonth and PointId = @ppointID;
                        INSERT INTO RtMonthData(Year,Month,PointId,Value) VALUES (@pyear,@pmonth,@ppointID,@pvalue)";
            dataBase.ExecuteNonQuery(sql, new { ppointID = pointId, pyear = year, pmonth = month, pvalue = value });
        }
    }
}
