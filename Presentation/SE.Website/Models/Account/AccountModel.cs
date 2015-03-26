using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
    }

    [RequestUrl("/Account/Update")]
    public class AccountUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int AccountId { get; set; }

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
    }
}