using ReprotDal.Model;
using ReprotDal.Repo;
using Rinch.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWS
{
    public class CalcDayReport
    {
        private readonly Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        EdnaHelper edna = EdnaHelper.GetInstance();

        DayDataRepo ddr = new DayDataRepo();

        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();
        String logstr = String.Empty;

        public void CalcData()
        {
            // get points list
            IEnumerable<Point> pointsList = (new PointRepo()).GetPoints(2);

            DateTime now = DateTime.Now;
            if (now.Hour == 0)
            {
                endTime = new DateTime(now.Year, now.Month, now.Day);
                startTime = endTime.AddDays(-1);
            }
            else
            {
                endTime = now;
                startTime = new DateTime(now.Year, now.Month, now.Day);
            }
            // calc each point
            foreach (var point in pointsList)
            {
                Double value = edna.GetAverage(point.Name, startTime, endTime);
                if (Double.IsNaN(value))
                {
                    logstr = " 点名:<" + point.Name + "> 在"
                            + startTime.ToString() + "到" + endTime.ToString() + "间取平均值失败！";
                    logger.Error(logstr);
                    value = 0;
                }
                // insert
                ddr.Insert(point.ID, value, startTime);
            }

            //SecendCalc(now);
        }

        public void SecendCalc(DateTime day)
        {
            // 计算1A投入小时、1B投入小时、
            //日投入小时：每天0点开始累计，每分钟取一次测点M5935的数值。若测点M5935数值为1时，则日投入小时增加1分钟；若数值不为1，则日投入小时不增加	
            DateTime etime = new DateTime(day.Year, day.Month, day.Day);
            DateTime stime = etime.AddDays(-1);
            logger.Info("Mark 1 : " + stime.ToString() + "----" + etime.ToString());
            IEnumerable<PartTimespan> timeList = ddr.GetPartTimes(stime, etime);
            logger.Info("Mark 2 : timeList个数：" + timeList.Count());

            // Overruan table : partid 58,59,60,61,62,63
            // RtPoints table : PointID: 99-106
            IEnumerable<PartTimespan> tempList58 = timeList.Where(t => t.PartID == 58);
            IEnumerable<PartTimespan> tempList59 = timeList.Where(t => t.PartID == 59);
            IEnumerable<PartTimespan> tempList60 = timeList.Where(t => t.PartID == 60);
            IEnumerable<PartTimespan> tempList61 = timeList.Where(t => t.PartID == 61);
            IEnumerable<PartTimespan> tempList62 = timeList.Where(t => t.PartID == 62);
            IEnumerable<PartTimespan> tempList63 = timeList.Where(t => t.PartID == 63);
            // 1号机组 1A投入小时
            Double m1_1A = GetTotalHours(tempList58, stime, etime);
            logger.Info("Mark 3 : m1_1A数：" + m1_1A);
            ddr.Insert(99, m1_1A, stime);
            // 2号机组 1A投入小时
            Double m2_1A = GetTotalHours(tempList59, stime, etime);
            logger.Info("Mark 4 : m2_1A数：" + m2_1A);
            ddr.Insert(100, m2_1A, stime);
            // 1号机组 1B投入小时
            Double m1_1B = GetTotalHours(tempList60, stime, etime);
            logger.Info("Mark 5 : m1_1B数：" + m1_1B);
            ddr.Insert(101, m1_1B, stime);
            // 2号机组 1B投入小时
            Double m2_1B = GetTotalHours(tempList61, stime, etime);
            logger.Info("Mark 6 : m2_1B数：" + m2_1B);
            ddr.Insert(102, m2_1B, stime);

            //日投入小时 1号机组
            Double m1_hour = GetTotalHours(tempList62, stime, etime);
            logger.Info("Mark 7 : m1_hour数：" + m1_hour);
            //日投入小时 1号机组
            Double m2_hour = GetTotalHours(tempList63, stime, etime);
            logger.Info("Mark 8 : m2_hour数：" + m2_hour);

            //1A投入率、1B投入率

            // 日投入率：日投入小时/（测点E0004大于300的小时数）

            // 1号机组 1A投入率
            // 2号机组 1A投入率
            Double m1_1Ar = 0;
            Double m2_1Ar = 0;
            if (m1_hour != 0)
            {
                m1_1Ar = m1_hour == 0 ? 0 : m1_1A / m1_hour * 100;
                m2_1Ar = m2_hour == 0 ? 0 : m2_1A / m2_hour * 100;
            }            
            ddr.Insert(103, m1_1Ar, stime);
            ddr.Insert(104, m2_1Ar, stime);

            // 1号机组 1B投入率
            // 2号机组 1B投入率
            Double m1_1Br =0;
            Double m2_1Br = 0;
            if (m1_hour != 0)
            {
                m1_1Br = m1_hour == 0 ? 0 : m1_1B / m1_hour * 100;
                m2_1Br = m2_hour == 0 ? 0 : m2_1B / m2_hour * 100;
            }            
            ddr.Insert(105, m1_1Br, stime);
            ddr.Insert(106, m2_1Br, stime);

        }

        private Double GetTotalHours(IEnumerable<PartTimespan> timeList, DateTime stime, DateTime etime)
        {
            if (timeList.Count() == 0)
            {
                return 0;
            }
            Double result = 0;
            foreach (var item in timeList)
            {
                DateTime s = item.StartTime < stime ? stime : item.StartTime;
                DateTime e = item.EndTime > etime ? etime : item.EndTime;
                result += e.Subtract(s).TotalHours;
            }
            return result;
        }



        public void ThirdCalc(DateTime day)
        {
            // 计算A侧液氨量（DCS统计）、B侧液氨量（DCS统计）
            DateTime etime = new DateTime(day.Year, day.Month, day.Day);
            DateTime stime = etime.AddDays(-1);
            logger.Info("Mark 3-1 : " + stime.ToString() + "----" + etime.ToString());
            // get points list
            IEnumerable<Point> pointsList = (new PointRepo()).GetPoints(4);
            logger.Info("Mark 3-2 : " + pointsList.Count());
            Double value = 0;
            foreach (var p in pointsList)
            {
                value = edna.GetHistory(p.Name, etime) - edna.GetHistory(p.Name, stime);
                if (Double.IsNaN(value))
                {
                    continue;
                }
                ddr.Insert(p.ID, value, stime);
                logger.Info("Mark 3-3");
            }
        }
    }
}
