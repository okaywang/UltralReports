using SE.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    /// <summary>
    /// 用户登录数据
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }


    public class LoginResultModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
    }
    public enum LoginModelStatus
    {
        [DisplayText("登录成功")]
        Success = 0,

        [DisplayText("手机号无效")]
        InvalidPhoneNumber,

        [DisplayText("验证码不正确")]
        IncorrectCheckCode
    }

    public enum SuggestionModelStatus
    {
        [DisplayText("提交成功")]
        Success = 0,

        [DisplayText("用户无效")]
        InvalidUser,
         [DisplayText("可返现金额不足")]
        CashBackPriceFalse
    }
}