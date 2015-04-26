using BussinessLogic;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Website.Common;

namespace Website.Models
{
    public class LoginModel
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Captcha { get; set; }

        public bool RememberMe { get; set; }

        public ResultModel CheckModel()
        {
            if (string.IsNullOrEmpty(this.LoginName))
            {
                return new ResultModel(false, "用户名不能为空");
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                return new ResultModel(false, "密码不能为空");
            }
            if (string.IsNullOrEmpty(this.Captcha))
            {
                return new ResultModel(false, "验证码不能为空");
            }
            return new ResultModel(true);
        }

    }

    public class MajorControlSourceAttribute : Attribute, IControlSource
    {
        public NameValuePair[] GetSource()
        {
            var bll = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(MajorBussinessLogic)) as MajorBussinessLogic;
            var entities = bll.GetAll();
            var items = AutoMapper.Mapper.Map<List<Major>, NameValuePair[]>(entities);
            return items;
        }
    }

    [RequestUrl("/Account/Add")]
    public class AccountAddModel
    {
        [Required]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Required]
        [DisplayName("登录名")]
        public string LoginName { get; set; }

        [Required]
        [DisplayName("密码")]
        public string Password { get; set; }
         
        [Required]
        [DisplayName("手机号码")]
        public string PhoneNumber { get; set; }

        [DisplayName("专业")]
        [ControlType(typeof(NativeSelect))]
        [MajorControlSourceAttribute]
        public int? MajorId { get; set; }
    }

    [RequestUrl("/Account/Update")]
    public class AccountUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Required]
        [DisplayName("登录名")]
        public string LoginName { get; set; }

        [MinLength(6)]
        [DisplayName("密码")]
        //[ControlType(typeof(NativeInputText))]
        public string Password { get; set; }

        [Required]
        [DisplayName("手机号码")]
        public string PhoneNumber { get; set; }

        [DisplayName("专业")]
        [ControlType(typeof(NativeSelect))]
        [MajorControlSourceAttribute]
        public int? MajorId { get; set; }
    }

    public class AccountListItemModel : IListItemModel
    {
        [DisplayName("账号Id")]
        public int Id { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("登录名")]
        public string LoginName { get; set; }
        
        [DisplayName("手机号码")]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public int? MajorId { get; set; }

        [DisplayName("专业")]
        public string MajorName { get; set; }

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