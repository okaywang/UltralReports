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
    public class SmsLogListPageModel : ListPageModal
    { 
    }

     
    public class SmsLogListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("发送时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}")]
        public System.DateTime FADateTime { get; set; }

        [DisplayName("短信内容")]
        public string Content { get; set; }

        [DisplayName("短信类型")]
        public int SmsType { get; set; }

        [DisplayName("短信接收组")]
        public string GroupName { get; set; }

        //public bool IsSuccess { get; set; }

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
}