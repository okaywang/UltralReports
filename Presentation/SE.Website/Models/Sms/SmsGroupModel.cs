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
    public class SmsGroupListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    public class SmsGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    //public class AccountSourceAttribute : Attribute, IControlSource
    //{
    //    public NameValuePair[] GetSource()
    //    {
    //        var bll = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(AccountBussinessLogic)) as AccountBussinessLogic;
    //        var entities = bll.GetAll();
    //        var items = AutoMapper.Mapper.Map<List<Account>, NameValuePair[]>(entities);
    //        return items;
    //    }
    //}

    [RequestUrl("/Sms/AssociateAccount")]
    public class SmsGroupAddRecipientModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int GroupId { get; set; }

        [Required]
        [DisplayName("选择人员")]
        [ControlType(typeof(NativeSelect))]
        //[AccountSourceAttribute]
        public int AccountId { get; set; }
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

    public class RecipientsConvertor : IValueConvertor
    {
        public object Convert(object obj)
        {
            var model = obj as SmsGroupListItemModel;
            var result = string.Join(",", model.Recipients.Select(i => string.Format("<span value={0} command-name='removeRecipient'>{1}</span>", i.Value, i.Name)));
            return result;
        }
    }

    public class SmsGroupListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("人员")]
        [ValueConvertor(typeof(RecipientsConvertor))]
        public NameValuePair[] Recipients { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/AdminSys/Tenant/UpdateConstItem"), 
                    new ListItemCommand("remove","删除","/AdminSys/Tenant/RemoveConstItem"),
                    new ListItemCommand("addRecipient","添加人员","/AdminSys/Tenant/RemoveConstItem") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}