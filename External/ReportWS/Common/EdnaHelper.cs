using EdnaUtility.Data;
using EdnaUtility.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinch.Common
{
    public class EdnaHelper
    {
        private static EdnaHelper _instance = null;        

        private RealtimeClient client;
        private EdnaHelper()
        {
            client = new eDNA();
        }
        public static EdnaHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EdnaHelper();
            }
            return _instance;
        }
        public Double GetHistory(String poingName, DateTime time)
        {
            var pt = new PointModel { Name = poingName };
            var hist_st = this.client.Hist(pt, time);
            return hist_st.Value;
        }

        public Double GetAverage(String poingName, DateTime starttime, DateTime endtime)
        {
            var pt = new PointModel { Name = poingName };
            return this.client.Statis(pt, starttime, endtime, StatisType.Average).Value;
        }

        public double GetMaximum(string poingName, DateTime starttime, DateTime endtime)
        {
            var pt = new PointModel { Name = poingName };
            return this.client.Statis(pt, starttime, endtime, StatisType.Maximum).Value;
        }

        public double GetMinimum(string poingName, DateTime starttime, DateTime endtime)
        {
            var pt = new PointModel { Name = poingName };
            return this.client.Statis(pt, starttime, endtime, StatisType.Minimum).Value;
        }

        public double GetMaximum(string poingName, DateTime starttime, DateTime endtime, out DateTime time)
        {
            var pt = new PointModel { Name = poingName };
            RecordData rd = this.client.Statis(pt, starttime, endtime, StatisType.Maximum);
            time = rd.Time;
            return rd.Value;
        }

        public double GetMinimum(string poingName, DateTime starttime, DateTime endtime, out DateTime time)
        {
            var pt = new PointModel { Name = poingName };
            RecordData rd = this.client.Statis(pt, starttime, endtime, StatisType.Minimum);
            time = rd.Time;
            return rd.Value;
        }
    }

}
