using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EdnaUtility.Data;
using EdnaUtility.Drivers.API;

namespace EdnaUtility.Drivers
{
    [Serializable]
    public sealed class eDNA : RealtimeClient
    {
        private const int BufferSize = 0xff;

        //digital true or digital false the 8th char is t or f

        private readonly Func<StringBuilder, double, double> getAnalog = (status, value) => (float)value;
        private readonly Func<StringBuilder, StringBuilder, double> getDigital = (status, value) => string.Equals("digital true", value.ToString(), StringComparison.OrdinalIgnoreCase) ? 1 : 0;

        public eDNA()
        {
            this.DriverInfo = "eDAN Client";
            var dir = Path.Combine(Environment.GetEnvironmentVariable("windir"), "system32", "drivers", "etc");
            var hosts = Directory.GetFiles(dir).Select(x => new FileInfo(x)).First(x => x.Name.StartsWith("hosts", StringComparison.OrdinalIgnoreCase));

            //192.160.101.100  dna_svcdir_01  # add by installer
            var svcdir = File.ReadAllLines(hosts.FullName).Select(x => x.ToLower()).FirstOrDefault(x => !x.TrimStart().StartsWith("#") && x.Contains("dna_svcdir_01"));
            if (string.IsNullOrEmpty(svcdir))
            {
                throw new Exception(string.Format("连接失败，未能在'{0}'文件中找到类似'192.168.1.1 dna_svcdir_01'的配置信息", hosts));
            }
            this.ConnectionString = svcdir;
        }

        private string GetID(PointModel point)
        {
            var id = point.Name.Trim();
            //var id = point.ID != null ? (string)point.ID : this.GetID(point.Name);
            //point.ID = id;
            //if (!string.IsNullOrEmpty(id))
            //{
            //    if (string.IsNullOrEmpty(point.Name))
            //    {
            //        var nameBuffer = new StringBuilder(BufferSize);
            //        if (0 == eDNA_API.LongIdFromShortId(id, nameBuffer, (ushort)nameBuffer.Capacity))
            //        {
            //            point.Name = nameBuffer.ToString().Trim();
            //        }
            //    } 
            //}
            return id;
        }

        public override dynamic GetID(string tag)
        {
            var statusBuffer = new StringBuilder(BufferSize);
            var split = tag.Split('.');
            if (split.Length > 2)// && split[2].Length > 8)
            {
                var serviceName = string.Format("{0}.{1}", split[0], split[1]);
                var longId = tag.Substring(serviceName.Length + 1);
                eDNA_API.ShortIdFromLongId(serviceName, longId, statusBuffer, (ushort)statusBuffer.Capacity);
            }
            var id = statusBuffer.ToString().Trim();
            return string.IsNullOrEmpty(id) ? null : id;
        }

        public override RecordData Snap(PointModel point)
        {
            var data = new RecordData { Point = point, Time = DateTime.Now };
            var id = this.GetID(point);
            if (id != null)
            {
                var val = 0d;
                var utcTime = 0;
                eDNA_API.DNAGetRTTimeUTC(id, ref utcTime);
                if (point.PointType == "DI")
                {
                    var buffer = new StringBuilder(BufferSize);
                    if (0 == eDNA_API.DNAGetRTValueAsString(id, buffer, (ushort)buffer.Capacity))
                    {
                        data.Value = string.Equals("digital true", buffer.ToString(), StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                    }
                }
                else
                {
                    if (0 == eDNA_API.DNAGetRTValue(id, ref val))
                    {
                        data.Value = val;
                    }
                }

                data.Time = eDNA_API.UTCToDateTime(utcTime);
            }
            return data;
        }

        public override RecordData Statis(PointModel point, DateTime startTime, DateTime endTime, StatisType statisType)
        {
            var data = new RecordData { Point = point };

            var id = this.GetID(point);
            point.ID = id;
            if (id != null)
            {
                var val = 0d;
                var utcTime = 0;
                uint uk = 0;
                var ret = -1;
                switch (statisType)
                {
                    case StatisType.Maximum:
                        ret = eDNA_API.DnaGetHistMaxUTC(id, eDNA_API.DateTimeToUTC(startTime), eDNA_API.DateTimeToUTC(endTime), 1 + (int)(endTime - startTime).TotalSeconds, ref uk);
                        break;
                    case StatisType.Minimum:
                        ret = eDNA_API.DnaGetHistMinUTC(id, eDNA_API.DateTimeToUTC(startTime), eDNA_API.DateTimeToUTC(endTime), 1 + (int)(endTime - startTime).TotalSeconds, ref uk);
                        break;
                    case StatisType.Average:
                        ret = eDNA_API.DnaGetHistAvgUTC(id, eDNA_API.DateTimeToUTC(startTime), eDNA_API.DateTimeToUTC(endTime), 1 + (int)(endTime - startTime).TotalSeconds, ref uk);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("statisType");
                }

                if (ret == 0)
                {
                    var statusBuffer = new StringBuilder(BufferSize);
                    if (eDNA_API.DnaGetNextHistUTC(uk, ref val, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity) == 0)
                    {
                        data.Value = getAnalog(statusBuffer, val);
                        data.Time = eDNA_API.UTCToDateTime(utcTime);
                    }
                }
            }
            return data;
        }

        public override List<RecordData> Raw(PointModel point, DateTime startTime, DateTime endTime)
        {
            var data = new List<RecordData>();
            var id = this.GetID(point);
            if (id != null)
            {
                uint uk;
                var val = 0d;
                var utcTime = 0; 
                if (eDNA_API.DnaGetHistRawUTC(id, eDNA_API.DateTimeToUTC(startTime), eDNA_API.DateTimeToUTC(endTime), out uk) == 0)
                {
                    var statusBuffer = new StringBuilder(BufferSize);

                    #region di string value

                    if (point.PointType == "DI")
                    {
                        var valBuffer = new StringBuilder(BufferSize);
                        while (eDNA_API.DnaGetNextHistStrUTC(uk, valBuffer, (ushort)valBuffer.Capacity, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity) == 0)
                        {
                            var item = new RecordData { Point = point, Time = eDNA_API.UTCToDateTime(utcTime), Value = getDigital(statusBuffer, valBuffer) };
                            data.Add(item);
                            valBuffer = new StringBuilder(BufferSize);
                            statusBuffer = new StringBuilder(BufferSize);
                        }
                    }
                    else
                    #endregion
                    {
                        while (eDNA_API.DnaGetNextHistUTC(uk, ref val, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity) == 0)
                        {
                            var item = new RecordData { Point = point, Time = eDNA_API.UTCToDateTime(utcTime), Value = getAnalog(statusBuffer, val) };
                            data.Add(item);
                            statusBuffer = new StringBuilder(BufferSize);
                        }
                    }
                }
            }
            return data;
        }

        public override RecordData Hist(PointModel point, DateTime time, BoundaryType boundaryType = BoundaryType.Auto)
        {
            var data = new RecordData { Point = point, Time = time };
            var id = this.GetID(point);
            if (id != null)
            {
                uint uk = 0;
                var val = 0d;
                var utcTime = 0;
                if (eDNA_API.DnaGetHistSnapUTC(id, eDNA_API.DateTimeToUTC(time), eDNA_API.DateTimeToUTC(time), 1, ref uk) == 0)
                {
                    var statusBuffer = new StringBuilder(BufferSize);
                    if (point.PointType == "DI")
                    {
                        var valBuffer = new StringBuilder(BufferSize);
                        eDNA_API.DnaGetNextHistStrUTC(uk, valBuffer, (ushort)valBuffer.Capacity, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity);
                        val = getDigital(statusBuffer, valBuffer);
                    }
                    else
                    {
                        eDNA_API.DnaGetNextHistUTC(uk, ref val, ref utcTime, statusBuffer, (ushort)(statusBuffer.Capacity));
                        val = getAnalog(statusBuffer, val);
                    }
                    data.Value = val;
                    data.Time = eDNA_API.UTCToDateTime(utcTime);
                }
            }
            return data;
        }

        public override List<RecordData> Hist(PointModel point, DateTime startTime, DateTime endTime, TimeSpan interval, BoundaryType boundaryType = BoundaryType.Auto)
        {
            var data = new List<RecordData>();
            var id = this.GetID(point);
            if (id != null)
            {
                uint uk = 0;
                var val = 0d;
                var utcTime = 0;

                switch (boundaryType)
                {
                    case BoundaryType.Before:
                    case BoundaryType.Auto:
                        //var source = this.Raw(point, startTime, endTime);
                        //data.AddRange(FillWithDif(source, startTime, endTime, interval));
                        //break;
                        var period = (int)interval.TotalSeconds;
                        if (eDNA_API.DnaGetHistSnapUTC(id, eDNA_API.DateTimeToUTC(startTime), eDNA_API.DateTimeToUTC(endTime), period, ref uk) == 0)
                        {
                            var statusBuffer = new StringBuilder(BufferSize);
                            if (point.PointType == "DI")
                            {
                                var valBuffer = new StringBuilder(BufferSize);
                                while (eDNA_API.DnaGetNextHistStrUTC(uk, valBuffer, (ushort)valBuffer.Capacity, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity) == 0)
                                {
                                    var item = new RecordData { Point = point, Time = eDNA_API.UTCToDateTime(utcTime), Value = getDigital(statusBuffer, valBuffer) };
                                    data.Add(item);
                                    valBuffer = new StringBuilder(BufferSize);
                                    statusBuffer = new StringBuilder(BufferSize);
                                }
                            }
                            else
                            {
                                while (eDNA_API.DnaGetNextHistUTC(uk, ref val, ref utcTime, statusBuffer, (ushort)statusBuffer.Capacity) == 0)
                                {
                                    var item = new RecordData { Point = point, Time = eDNA_API.UTCToDateTime(utcTime), Value = getAnalog(statusBuffer, val) };
                                    data.Add(item);
                                    statusBuffer = new StringBuilder(BufferSize);
                                }
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("boundaryType");
                }
            }
            else
            {
                var times = CalculateTimes(startTime, endTime, interval);
                data.AddRange(times.Select(x => new RecordData { Point = point, Time = x, Value = double.NaN }));
            }
            return data;
        }
 
        public override PointDetails GetPoint(string tag)
        {
            var point = new PointDetails { Name = tag, ID = this.GetID(tag) };

            if (string.IsNullOrEmpty(point.ID)) return point;

            var descriptor = new StringBuilder(BufferSize);
            var unit = new StringBuilder(BufferSize);
            if (0 == eDNA_API.DNAGetRTDesc((string)point.ID, descriptor, (ushort)descriptor.Capacity))
            {
                point.Descriptor = descriptor.ToString().Trim();
            }

            if (0 == eDNA_API.DNAGetRTUnits((string)point.ID, unit, (ushort)unit.Capacity))
            {
                point.Unit = unit.ToString().Trim();
            }

            return point;
        }

 
        
    }
}