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


    public class AccountAddModel
    {
        [Required]
        [ControlType(typeof(NativeInputHidden))]
        public int TenantId { get; set; }

        [Required]
        [ControlType(typeof(NativeInputHidden))]
        public int ConstId { get; set; }

        [Required]
        [DisplayName("类型")]
        [ControlType(typeof(NativeSelect), false)]
        //[EnumControlSource(typeof(ShareCodeClassEnum))]
        public int ClassId { get; set; }

        [Required]
        [DisplayName("编码")]
        [ControlType(typeof(NativeInputText), false)]
        public int Code { get; set; }

        [Required]
        [DisplayName("名称")]
        public string CodeName { get; set; }

        [Required]
        [DisplayName("父级Id")]
        [ControlType(typeof(NativeInputText))]
        public int ParentId { get; set; }

        [Required]
        [DisplayName("排序")]
        //[ControlType(typeof(NativeInputText), false)]
        public int OrderId { get; set; }
    }
}