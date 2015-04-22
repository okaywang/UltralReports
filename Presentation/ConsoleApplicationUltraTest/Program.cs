﻿using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationUltraTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new UltralReportsEntities();
            var repository = new EfRepository<UltraRecord>(context);
            var bll = new UltraReportBussinessLogic(repository);
            var criteria = new UltraSummarySearchCriteria();
            //criteria.Duty = 3;
            //criteria.MachineSet = Common.Types.MachineSetType.MachineSet1;
            var result = bll.SearchSummary(criteria);
            Console.WriteLine("abc");
        }

        private static void GenerateData_UltraRecord()
        {
            var context = new UltralReportsEntities();
            var repository = new EfRepository<UltraRecord>(context);
            var bll = new UltraReportBussinessLogic(repository);

            var types = new[] { "L1", "L2", "L3", "H1", "H2", "H3" };
            var symbols = new[] { 1, -1 };
            var parts = new[] { 1, 2, 3 };
            var duties = new[] { 1, 2, 3, 4, 5 };
            var rand = new Random();
            var records = new List<UltraRecord>();
            for (int i = 0; i < 10000; i++)
            {
                var record = new UltraRecord();
                record.UltraType = types[rand.Next(types.Length)];
                record.PartId = parts[rand.Next(parts.Length)];
                record.Duty = duties[rand.Next(duties.Length)];
                record.BeginTime = DateTime.Now.AddMinutes(rand.Next(24 * 60) * symbols[rand.Next(2)]);
                record.EndTime = record.BeginTime.AddMinutes(rand.Next(1, 20));
                record.MinValue = rand.Next(500, 600);
                record.MaxValue = record.MinValue + rand.Next(200);
                record.AvgValue = (record.MinValue + record.MaxValue) / 2;
                records.Add(record);
            }
            bll.InsertRange(records);
        }
    }
}