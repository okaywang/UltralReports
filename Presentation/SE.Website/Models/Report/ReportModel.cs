using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Common;

namespace Website.Models
{
    public class GapListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }
    [RequestUrl("/Report/GapAdd")]
    public class GapAddModel
    {
        [Required]
        [DisplayName("开始时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [ControlType(typeof(BootstrapDateTimePicker))]
        public System.DateTime StartTime { get; set; }

        [Required]
        [DisplayName("结束时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [ControlType(typeof(BootstrapDateTimePicker))]
        public System.DateTime EndTime { get; set; }
    }

    [RequestUrl("/Report/GapUpdate")]
    public class GapUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("开始时间")] 
        [ControlType(typeof(BootstrapDateTimePicker))]
        public System.DateTime StartTime { get; set; }

        [Required]
        [DisplayName("结束时间")] 
        [ControlType(typeof(BootstrapDateTimePicker))] 
        public System.DateTime EndTime { get; set; }
    }

    public class GapListItemModel : IListItemModel
    {
        public int Id { get; set; }

        [DisplayName("开始时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public System.DateTime StartTime { get; set; }


        [DisplayName("结束时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public System.DateTime EndTime { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm" }); 
        }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new ListItemCommand[]
                    { 
                    new ListItemCommand("update","编辑","/Report/GapUpdate"),
                    new ListItemCommand("remove","删除","/Report/GapRemove") 
                    };
            }
        }
    }
}