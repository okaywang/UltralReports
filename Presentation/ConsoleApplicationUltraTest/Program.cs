using BussinessLogic;
using DataAccess;
using SmsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApplicationUltraTest
{
    class Program
    {
        ///异步打印传入的字符串
        public async static Task<string> AsyncAdd(string str)
        {
            string result = await PringString(str);
            Console.WriteLine("AsyncAdd");
            return result;
        }
        public async static Task<string> PringString(string str)
        {
            return await Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    return "Hello World" + str;
                });
        }

        /// <summary>
        /// 同步方法打印Hello World
        /// </summary>
        public static void PrintHelloWorld()
        {
            Console.WriteLine("同步方法调用开始");
            Console.WriteLine("同步方法:Hello World");
            Thread.Sleep(1000);
            Console.WriteLine("退出同步方法");
        }

        /// <summary>
        /// 异步方法打印Hello World
        /// </summary>
        public async static void AsyncPrintHelloWorld()
        {
            Console.WriteLine("异步方法调用开始");
            Console.WriteLine("异步方法:Hello World");
            await Task.Delay(3000);
            Console.WriteLine("退出异步方法");
        }

        static void Main(string[] args)
        {
            GenerateData_SmsLog();

            Console.WriteLine("abc");
        }

        private static void SendSmsTest()
        {
            var sms = new SmsDevice("COM1");

            var phones = new[] { "13488886666", "13411112222", "13966667777" };
            var msg = "广大市民请注意，明天有大暴雨，请注意出行！";
            sms.SendSms(phones, msg);
        }

        private async static void TTTTTTTTTTT()
        {
            var device = new MockDeviceTest();
            Console.WriteLine(100);
            await device.SendSmsAysc(new string[] { "aa", "bb", "cc" }, "bad");
            Console.WriteLine(200);
        }

        private static void GenerateData_SmsLog()
        {
            var context = new UltralReportsEntities();
            var repository = new EfRepository<SmsLog>(context);
            var bll = new SmsLogBussinessLogic(repository);
            var records = new List<SmsLog>();
            var groups = new[] { 1, 2 };
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var record = new SmsLog();
                record.GroupId = groups[rand.Next(groups.Length)];
                record.IsSuccess = rand.Next(10) > 5 ? true : false;
                record.SmsType = rand.Next(10) > 5 ? 1 : 2;
                record.Content = "this is conent" + i.ToString();
                record.FADateTime = DateTime.Now;
                records.Add(record);
            }
            try
            {
            bll.InsertRange(records);

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private static void GenerateData_UltraRecord()
        {
            var context = new UltralReportsEntities();
            var repository = new EfRepository<UltraRecord>(context);
            var bll = new UltraReportBussinessLogic(repository);

            var types = new[] { "L1", "L2", "L3", "H1", "H2", "H3", "PH", "PL" };
            var symbols = new[] { 1, -1 };
            var parts = new[] { 4, 5 };
            var duties = new[] { 1, 2, 3, 4, 5 };
            var rand = new Random();
            var records = new List<UltraRecord>();
            for (int i = 0; i < 100; i++)
            {
                var record = new UltraRecord();
                record.UltraType = types[rand.Next(types.Length)];
                record.PartId = parts[rand.Next(parts.Length)];
                record.Duty = duties[rand.Next(duties.Length)];
                record.StartTime = DateTime.Now.AddMinutes(rand.Next(24 * 60) * symbols[rand.Next(2)]);
                if (i % 10 != 0)
                {
                    record.EndTime = record.StartTime.AddMinutes(rand.Next(1, 20));
                }
                if (rand.Next(10) > 5)
                {
                    record.MinValue = rand.Next(500, 600);
                }
                if (rand.Next(10) > 5)
                {
                    record.MaxValue = record.MinValue + rand.Next(200);
                }
                if (rand.Next(10) > 5)
                {
                    record.AvgValue = (record.MinValue + record.MaxValue) / 2;
                }
                records.Add(record);
            }
            try
            {
                bll.InsertRange(records);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
