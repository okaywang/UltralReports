using UR.BussinessLogic;
using UR.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Common;


namespace Website.Models
{
    public class PersonAccountModel
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