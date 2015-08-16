using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ReportWS
{
    public partial class ReportService : ServiceBase
    {
        private readonly Common.Logging.ILog logger;
        public Timer mTimer { get; set; }
        public ReportService()
        {
            InitializeComponent();
            // writer log
            logger = Common.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // timer
            this.mTimer = new Timer();
            this.mTimer.Elapsed += new ElapsedEventHandler(mTimer_Elapsed);
            mTimer.Interval = 1000 * 60 *60;
        }

        protected override void OnStart(string[] args)
        {
            mTimer.Start();
            logger.Info("报表服务启动");
        }

        protected override void OnStop()
        {
            mTimer.Stop();
            logger.Info("报表服务--停止");
        }
        public void mTimer_Elapsed(object sender, EventArgs e)
        {
            mTimer.Enabled = false;
            try
            {
                DateTime now = DateTime.Now;
                //logger.Info(now);
                logger.Info("Start Day Report:" + DateTime.Now);
                // Calc day report for every hour
                CalcDayReport cdr = new CalcDayReport();
                cdr.CalcData();
                // // 计算1A投入小时、1B投入小时、
                logger.Info("Start Day Secend Report:" + DateTime.Now);
                cdr.SecendCalc(now);
                logger.Info("Start Day Third Report:" + DateTime.Now);
                cdr.ThirdCalc(now);
               
                logger.Info("End Day Report:" + DateTime.Now);
                if (now.Hour < 4)
                {
                    logger.Info("Start Month Report:" + DateTime.Now);
                    // Calc month report for every Day
                    CalcMonthReport cmr = new CalcMonthReport();
                    cmr.CalcData();
                    logger.Info("End Month Report:" + DateTime.Now);
                }
                //logger.Info(now);

            }
            catch (Exception ex)
            {
                logger.Error("Timer:" + ex);
            }
            finally
            {
                mTimer.Enabled = true;
            }
        }

        public void test()
        {
            //mTimer.Start();
            //CalcMonthReport cmr = new CalcMonthReport();
            //cmr.ConvertMonthTime(2015, 3);
            //cmr.ConvertMonthTime(2015,5);
            //cmr.ConvertMonthTime(2015, 6);

            //cmr.CalcData();
            //cmr.ReCalcReport(2015, 4);
            CalcDayReport cdr = new CalcDayReport();
            //cdr.CalcData();
            //for (int i = 2; i < 5; i++)
            //{
                //cdr.SecendCalc(new DateTime(2015, 8, i));
                cdr.ThirdCalc(new DateTime(2015, 8, 5));
            //}
            
            
            //cdr.ThirdCalc(DateTime.Now.AddDays(-1));
        }
    }
}
