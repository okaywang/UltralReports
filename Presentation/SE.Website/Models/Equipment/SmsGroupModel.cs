using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Common;

namespace Website.Models
{
    public class MonitorTypeListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }


    [RequestUrl("/Equipment/MonitorTypeAdd")]
    public class MonitorTypeAddModel
    {
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    [RequestUrl("/Equipment/MonitorTypeUpdate")]
    public class MonitorTypeUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    public class MonitorTypeListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/Equipment/MonitorTypeUpdate"), 
                    new ListItemCommand("remove","删除","/Equipment/MonitorTypeRemove") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}