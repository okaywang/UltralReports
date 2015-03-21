using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ChangePasswordModel
    {
        [Min(1)]
        public int AccountId { get; set; }
        
        public string OldPassword { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码长度必须为6-20个字符")]
        public string NewPassword { get; set; }
    }
}