using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Common;


namespace Website.Models
{
    public class AccountListItemModel : IListItemCommands
    {
        [DisplayName("账号Id")]
        public int AccountId { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("登录名")]
        public string LoginName { get; set; }

        [DisplayName("部门")]
        public string Department { get; set; }

        [DisplayName("创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("操作")]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("edit", "编辑", "/AdminSys/Tenant/UpdateConstItem"), 
                    new ListItemCommand("remove","删除","/AdminSys/Tenant/RemoveConstItem") 
                };
            }
        }
    }

    public class AccountModel
    {
        public int PersonId { get; set; }
        public int AccountId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LoginName { get; set; }

        [Required]
        public string Department { get; set; }

        [RequiredIf("AccountId", 0)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}