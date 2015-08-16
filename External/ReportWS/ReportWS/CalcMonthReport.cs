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
    public class CalcMonthReport
    {
        private readonly Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        MonthDataRepo mdr = new MonthDataRepo();

        EdnaHelper edna = EdnaHelper.GetInstance();
        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();
        String logstr = String.Empty;

        public void ReCalcReport(int year,int month)
        {
            startTime = new DateTime(year, month, 1);
            endTime = startTime.AddMonths(1) > DateTime.Now ? DateTime.Now : startTime.AddMonths(1);
            if (startTime > DateTime.Now)
            {
                return;
            }
            CalcMonthData(startTime, endTime);
        }
        public void CalcData()
        {            
            DateTime now = DateTime.Now;
            if (now.Day == 1)
            {
                endTime = new DateTime(now.Year, now.Month, now.Day);
                startTime = endTime.AddMonths(-1);
            }
            else
            {
                endTime = now;
                startTime = new DateTime(now.Year, now.Month, 1);
            }
            CalcMonthData(startTime, endTime);

        }

        private void CalcMonthData(DateTime startTime, DateTime endTime)
        {
            // get points list
            IEnumerable<Point> pointsList = (new PointRepo()).GetPoints(1);
            // calc each point
            foreach (var point in pointsList)
            {
                List<MonthTime> monthTimeList = ConvertMonthTime(startTime.Year, startTime.Month);
                 if (monthTimeList.Count == 0)
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
                    mdr.Insert(point.ID, value, startTime.Year, startTime.Month);
                }
                // 加权计算
                else
                {
                    Double totalMinutes = 0;
                    Double sum = 0;
                    foreach (var monthTime in monthTimeList)
                    {
                        Double subvalue = edna.GetAverage(point.Name, monthTime.StartTime, monthTime.EndTime);
                        Double subMinites = monthTime.EndTime.Subtract(monthTime.StartTime).TotalMinutes;
                        totalMinutes += subMinites;
                        sum += subvalue * subMinites;
                    }
                    Double value = sum / totalMinutes;
                    if (Double.IsNaN(value))
                    {
                        value = 0;
                    }
                    // insert
                    mdr.Insert(point.ID, value, startTime.Year, startTime.Month);
                }

            }
        }

        public List<MonthTime> ConvertMonthTime(int year,int month)
        {
            List<MonthTime> mteList = (new MonthTimeRepo()).GetTimes(year, month).ToList();

            List<MonthTime> rtlist = new List<MonthTime>();
            if (mteList.Count == 0)
            {
                return rtlist;
            }
            DateTime stime = new DateTime(year, month, 1);
            DateTime etime = new DateTime(year, month + 1, 1);
            etime = etime > DateTime.Now ? DateTime.Now : etime;
            int count = mteList.Count;
            foreach (var mt in mteList)
            {
                rtlist.Add(new MonthTime { Year = year, Month = month, StartTime = stime, EndTime = mt.StartTime });
                stime = mt.EndTime;
                if (--count == 0)
                {
                    rtlist.Add(new MonthTime { Year = year, Month = month, StartTime = mt.EndTime, EndTime = etime });
                }
            }
            return rtlist;
        }
    }
}
