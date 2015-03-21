using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public enum SendCheckCodeStatus
    {
        Success,
        [DisplayText("正在发送")]
        Sending,

        [DisplayText("手机号码无效")]
        InvlidPhoneNumber,

        [DisplayText("发送失败")]
        SendFailure
    }
}