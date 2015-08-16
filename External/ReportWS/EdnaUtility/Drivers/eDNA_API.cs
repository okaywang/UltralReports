#region using...

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace EdnaUtility.Drivers.API
{
    [Serializable]
    internal static class eDNA_API
    {
        public static int DateTimeToUTC(DateTime dateTime)
        {
            return (int) dateTime.Subtract(new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds;
        }

        public static DateTime UTCToDateTime(int utcTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(utcTime).ToLocalTime();
        }

        // Methods
        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaAddAnalogExtIdRecordNoStatus(string Service, string intId, int tTime, double dValue);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaAddAnalogLongIdRecordNoStatus(string Service, string intId, int tTime, double dValue);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaAddAnalogShortIdRecordNoStatus(string Service, string PointId, int tTime, double dValue);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaAddDigitalShortIdRecord(string Service, string PointId, int tTime, int bSet, string ValueString, int bDigitalWarning, int bDigitalChattering, int bUnReliable, int bManual);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaFlushAllRecords(string Service, StringBuilder Message, ushort MsgLength);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaFlushLongIdRecords(string Service, StringBuilder Message, ushort MsgLength);

        [DllImport("EZDnaServApi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaFlushShortIdRecords(string Service, StringBuilder Message, ushort MsgLength);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistAvgUTC(string szPoint, int tStart, int tEnd, int tPeriod, ref uint pulKey);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistDirectRawUTC(string szHistory, string szPoint, int tStart, int tEnd, ref ulong pulKey);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistMaxUTC(string szPoint, int tStart, int tEnd, int tPeriod, ref uint pulKey);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistMinUTC(string szPoint, int tStart, int tEnd, int tPeriod, ref uint pulKey);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistRawUTC(string Point, int StartTime, int EndTime, out uint Key);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetHistSnapUTC(string szPoint, int tStart, int tEnd, int tPeriod, ref uint pulKey);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetNextHistUTC(uint ulKey, ref double pdValue, ref int ptTime, StringBuilder szStatus, ushort nStatus);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetNextHistStrUTC(uint ulKey, StringBuilder pdValueString, ushort len, ref int ptTime, StringBuilder szStatus, ushort nStatus);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetNextPointEntry(ulong ulKey, StringBuilder szPoint, ushort nPoint, out double pdValue, StringBuilder szTime, ushort nTime, StringBuilder szStatus, ushort nStatus, StringBuilder szDesc, ushort nDesc, StringBuilder szUnits, ushort nUnits);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetNextServiceEntry(ulong key, StringBuilder szSvrName, ushort nName, StringBuilder szSvrDesc, ushort nDesc, StringBuilder szSvrType, ushort nType, StringBuilder szSvrStatus, ushort nStatus);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetPointEntry(string szServiceName, ushort nStarting, out ulong key, StringBuilder szPoint, ulong nPoint, out double pdValue, StringBuilder szTime, ushort nTime, StringBuilder szStatus, ushort nStatus, StringBuilder szDesc, ushort nDesc, StringBuilder szUnits, ushort nUnits);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        private static extern int DnaGetPointList(ushort nCount, string szServiceName, ushort nStarting, IntPtr[] szPoint, ushort nPoint, double[] dValue, IntPtr[] szTime, ushort nTime, IntPtr[] szStatus, ushort nStatus, IntPtr[] szDesc, ushort nDesc, IntPtr[] szUnits, ushort nUnits);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTAll(string szPoint, ref double pdValue, StringBuilder szTime, ushort nTime, StringBuilder szStatus, ushort nStatus, StringBuilder szDesc, ushort nDesc, StringBuilder szUnits, ushort nUnits);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTFull(string szPoint, ref double pdValue, StringBuilder szValue, ushort nValue, ref int ptTime, StringBuilder szTime, ushort nTime, ref ushort pusStatus, StringBuilder szStatus, ushort nStatus, StringBuilder szDesc, ushort nDesc, StringBuilder szUnits, ushort nUnits);

        //DNAGetRTDesc
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTDesc(string szPoint, StringBuilder szDesc, ushort sDesc);

        //DNAGetRTDescList
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTDescList(ushort count, StringBuilder[] points, StringBuilder[] szDesc, ushort sDesc);

        //DNAGetRTUnitsList
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTUnitsList(ushort count, StringBuilder[] points, StringBuilder[] szUnit, ushort sUnit);

        //DNAGetRTValueList
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTValueList(ushort count, StringBuilder[] points, double[] values);

        //DNAGetRTTimeListUTC
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTTimeListUTC(ushort count, StringBuilder[] points, long[] utcTimes);

        //DNAGetRTUnits
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTUnits(string szPoint, StringBuilder szUnit, ushort sUnit);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTTime(string szPoint, StringBuilder szTime, ushort nTime);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTTimeUTC(string szPoint, ref int lTime);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTValue(string szPoint, ref double pdValue);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DNAGetRTValueAsString(string szPoint, StringBuilder pdValueString, ushort len);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaGetServiceEntry(string szType, string szStartSvcName, ref ulong key, StringBuilder szSvrName, ushort nName, StringBuilder szSvrDesc, ushort nDesc, StringBuilder szSvrType, ushort nType, StringBuilder szSvrStatus, ushort nStatus);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        private static extern int DnaGetServiceList(ushort nCount, string szType, string szStartSvcName, IntPtr[] szSvcName, ushort nSvcName, IntPtr[] szSvcDesc, ushort nSvcDesc, IntPtr[] szSvcType, ushort nSvcType, IntPtr[] szStatus, ushort nStatus);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistFlushAppendValues(string szService, string szPoint, StringBuilder szError, ushort nError);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistFlushUpdateInsertValues(string szService, string szPoint, StringBuilder szError, ushort nError);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistMxClose(uint key);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistMxInitialize(out uint key, string serviceName);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistMxUpdateInsert(uint key, string pointId, ushort count, int[] timeList, ushort[] statusList, string[] valueList, [MarshalAs(UnmanagedType.LPStr)] StringBuilder error, int lenError);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistQueueAppendValue(string szService, string szPoint, int iTime, ushort nStatus, string nValue, StringBuilder szError, ushort nError);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaHistQueueUpdateInsertValue(string szService, string szPoint, int iTime, ushort nStatus, string nValue, StringBuilder szError, ushort nError);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaSelectPoint(StringBuilder szPoint, ushort nPoint);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int DnaSelectService(string szType, StringBuilder szService, ushort nService);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern bool DoesIdExist(string szPoint);

        [DllImport("ezdnaservapi.dll", CharSet = CharSet.Ansi)]
        public static extern int eDnaMxAddRec(int key, string pointid, int utcTime, int usms, int usstatus, double value);

        [DllImport("ezdnaservapi.dll", CharSet = CharSet.Ansi)]
        public static extern int eDnaMxFlushUniversalRecord(int key, int requesttype);

        [DllImport("ezdnaservapi.dll", CharSet = CharSet.Ansi)]
        public static extern int eDnaMxUniversalDataConnect(int key, string IPAddress, int usPort, string IPAddress2, int usPort2);

        [DllImport("ezdnaservapi.dll", CharSet = CharSet.Ansi)]
        public static extern int eDnaMxUniversalInitialize(out int key, bool bAckDataPacket, bool bQueueEnabled, bool bCacheEnabled, int nMaxCacheKBytes, string szCacheFileName, string szCacheDriveDir);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int LongIdFromShortId(string szPoint, StringBuilder szLongId, ushort nLongId);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int ShortIdFromLongId(string szService, string szLongId, StringBuilder szPoint, ushort nPoint);

        //ShortIdFromExtendedId
        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int ShortIdFromExtendedId(string szService, string szLongId, StringBuilder szPoint, ushort nPoint);


        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int StringToUTCTime(string szTime);

        [DllImport("ezdnaapi.dll", CharSet = CharSet.Ansi)]
        public static extern int UCTToStringTime(int iTime, StringBuilder szTime, ushort nTime);

        //IsDigital
    }
}