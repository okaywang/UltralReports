using BussinessLogic;
using Common.Types;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Website.Common;

namespace Website.Models
{
    #region Ultra
    public class UltraSummaryListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }
    public class ProUltraRecordListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    public class UltraRecordListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    public class UltraRecordListItemModel : IListItemModel
    {
        public int PartId { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        [DisplayName("监控类型")]
        public string MonitorTypeName { get; set; }

        [DisplayName("部件设备名称")]
        public string PartName { get; set; }

        [DisplayName("开始时间")]
        public DateTime BeginTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime EndTime { get; set; }

        [DisplayName("班值")]
        public int Duty { get; set; }

        [DisplayName("超限时长")]
        public int Duration { get; set; }

        [DisplayName("最小值")]
        public decimal MinValue { get; set; }

        [DisplayName("最大值")]
        public decimal MaxValue { get; set; }

        [DisplayName("平均值")]
        public decimal AvgValue { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IListItemCommand[] Commands
        {
            get
            {
                return new ListItemCommand[0];
            }
        }
    }

    public class UltraSummaryListItemModel : IListItemModel
    {
        public int PartId { get; set; }

        [DisplayName("部件设备名称")]
        public string PartName { get; set; }

        [DisplayName("监控类型")]
        public string MonitorTypeName { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        //public decimal L3 { get; set; }

        //public decimal H1 { get; set; }

        [DisplayName("额定运行范围")]
        public string RatedRange { get; set; }

        [DisplayName("班值")]
        public int Duty { get; set; }

        [DisplayName("超限次数")]
        [DisplayFormat(DataFormatString = "<a href='javascript:;' class='times' command-name='detail'>{0}</a>")]
        public int Times { get; set; }

        [DisplayName("超限时长")]
        public int Duration { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IListItemCommand[] Commands
        {
            get
            {
                return new ListItemCommand[0];
            }
        }
    }



    public class MyValueConvertor : IValueConvertor
    {
        public object Convert(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return "<button class='btn btn-primary btn-sm' command-name='fill' type='button'>填报</button>";
            }
            return value;
        }
    }


    [RequestUrl("/UltraRecord/Reason")]
    public class UltroReasonModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("原因")]
        public string Reason { get; set; }
    }

    public class ProUltraRecordListItemModel : IListItemModel
    {
        public int Id { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        [DisplayName("部件名称")]
        public string PartName { get; set; }

        [DisplayName("超限类别")]
        public string UltraType { get; set; }

        [DisplayName("开始时间")]
        public DateTime StartTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime EndTime { get; set; }

        [DisplayName("所属专业")]
        public string MajorName { get; set; }

        [DisplayName("最小值")]
        public decimal MinValue { get; set; }

        [DisplayName("最大值")]
        public decimal MaxValue { get; set; }

        [DisplayName("超限原因")]
        [ValueConvertor(typeof(MyValueConvertor))]
        public string Remarks { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IListItemCommand[] Commands
        {
            get
            {
                return new ListItemCommand[0];
            }
        }
    }
    #endregion

}