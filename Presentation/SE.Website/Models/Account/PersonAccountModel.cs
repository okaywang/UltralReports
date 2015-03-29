using BussinessLogic;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Website.Common;


namespace Website.Models
{
    public interface IListItemModel : IListItemCommands
    {
        string ToJson();
    }

    public class AccountListItemModel : IListItemModel
    {
        [DisplayName("账号Id")]
        public int AccountId { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("登录名")]
        public string LoginName { get; set; }

        [DisplayName("创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("setAuthority", "设置权限", "/AdminSys/Tenant/UpdateConstItem"), 
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