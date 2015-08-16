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
    public class DayDataRepo
    {
        private readonly Database dataBase = new Database(Config.DbConnectionString);
        public void Insert(int pointId, double value, DateTime time)
        {
            string sql = @"Delete RtDayData where DayTime = @ptime and PointId = @ppointID;
                        INSERT INTO RtDayData(DayTime,PointId,Value) VALUES (@ptime,@ppointID,@pvalue)";
            dataBase.ExecuteNonQuery(sql, new { ppointID = pointId, ptime = time, pvalue = value });
        }
        /// <summary>
        /// 计算1A投入小时、1B投入小时、1A投入率、1B投入率
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public IEnumerable<PartTimespan> GetPartTimes(DateTime stime, DateTime etime)
        {
            string sql = @"select PartId,StartTime,EndTime from UltraRecord
                        where (PartId > 57 and PartId < 64)
                        and (StartTime between @pstime and @petime
                        or EndTime between @pstime and @petime
                        or (StartTime <= @pstime and (EndTime>= @petime or flag = 0))
                        ) ";
            IEnumerable<PartTimespan> partTimespanList = dataBase.ExecuteDataReader<PartTimespan>(sql, new { pstime = stime, petime = etime }, dr => { return GetByDataReader(dr); }
            );
            return partTimespanList;
        }
        private PartTimespan GetByDataReader(DbDataReader dr)
        {
            try
            {
                return new PartTimespan
                {
                    PartID = (int)dr["partid"],
                    StartTime = (DateTime)dr["StartTime"],
                    EndTime = String.IsNullOrEmpty(dr["EndTime"].ToString()) ? DateTime.Now.AddDays(1) : (DateTime)dr["EndTime"],
                };
            }
            catch
            {

            }
            return null;
        }
        
    }
}
