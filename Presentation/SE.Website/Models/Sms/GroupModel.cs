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
    public class SmsGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [RequestUrl("/Sms/GroupAdd")]
    public class SmsGroupAddModel
    {
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    [RequestUrl("/Sms/GroupUpdate")]
    public class SmsGroupUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    public class SmsGroupListItemModel : IListItemModel
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
                    new ListItemCommand("update", "编辑", "/AdminSys/Tenant/UpdateConstItem"), 
                    new ListItemCommand("remove","删除","/AdminSys/Tenant/RemoveConstItem") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}