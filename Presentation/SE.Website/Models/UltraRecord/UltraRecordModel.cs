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
using WebExpress.Core;
using Website.Common;

namespace Website.Models
{
    #region Ultra
    public class UltraSummaryListPageModel : ListPageModal
    {
        public UltraSummaryListPageModel()
        {
            MonitorTypes = new NameValuePair[0];
        }
        public NameValuePair[] MonitorTypes { get; set; }
        public string AddItemUrl { get; set; }
    }
    public class ProUltraRecordListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }

        public NameValuePair[] Majors { get; set; }
    }

    public class UltraRecordListPageModel : ListPageModal
    {
        public string EquipmentName { get; set; }

        public string PartName { get; set; }

        public PagedModel<UltraRecordListItemModel> Records { get; set; }
    }

    public class DurationValueConvertor : IValueConvertor
    {
        public object Convert(object obj)
        {
            var model = obj as UltraRecordListItemModel;
            var span = model.EndTime.Subtract(model.StartTime);
            return model.Duration = span.Days * 60 + span.Minutes;
        }
    }

    public class UltraRecordListItemModel : IListItemModel
    {
        public int PartId { get; set; }

        [DisplayName("开始时间")]
        public DateTime StartTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime EndTime { get; set; }

        [DisplayName("超限类型")]
        [ValueConvertor(typeof(UltraTypeValueConvertor))]
        public string UltraType { get; set; }

        [DisplayName("超限时长(分钟)")]
        [ValueConvertor(typeof(DurationValueConvertor))]
        public int Duration { get; set; }

        [DisplayName("最小值")]
        public decimal? MinValue { get; set; }

        [DisplayName("最大值")]
        public decimal? MaxValue { get; set; }

        [DisplayName("平均值")]
        public decimal? AvgValue { get; set; }

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



    public class RemarksValueConvertor : IValueConvertor
    {
        public object Convert(object obj)
        {
            var model = obj as ProUltraRecordListItemModel;
            if (model.Remarks == null || model.Remarks.ToString() == "")
            {
                return "<button class='btn btn-primary btn-sm' command-name='fill' type='button'>填报</button>";
            }
            return model.Remarks;
        }
    }

    public class ExtremeValueConvertor : IValueConvertor
    {
        public object Convert(object obj)
        {
            var model = obj as ProUltraRecordListItemModel;
            return model.UltraType == "PH" ? model.MaxValue : model.MinValue;
        }
    }

    public class UltraTypeValueConvertor : IValueConvertor
    {
        private static Dictionary<string, string> _dict = new Dictionary<string, string>();
        static UltraTypeValueConvertor()
        {
            _dict.Add("H1", "高1限");
            _dict.Add("H2", "高2限");
            _dict.Add("H3", "高2限");
            _dict.Add("L1", "低1限");
            _dict.Add("L2", "低2限");
            _dict.Add("L3", "低3限");
            _dict.Add("PH", "专业超高限");
            _dict.Add("PL", "专业超低限");
        }

        public object Convert(object obj)
        {
            var model = obj as dynamic;
            return _dict[model.UltraType];
        }
    }

    [RequestUrl("/UltraRecord/Reason")]
    public class UltroReasonModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("原因")]
        [ControlType(typeof(NativeTextarea))]
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
        [ValueConvertor(typeof(UltraTypeValueConvertor))]
        public string UltraType { get; set; }

        [DisplayName("开始时间")]
        public DateTime StartTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime EndTime { get; set; }

        [DisplayName("所属专业")]
        public string MajorName { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        [DisplayName("超限最大幅值")]
        [ValueConvertor(typeof(ExtremeValueConvertor))]
        public decimal ExtremeValue { get; set; }

        [DisplayName("超限原因")]
        [ValueConvertor(typeof(RemarksValueConvertor))]
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