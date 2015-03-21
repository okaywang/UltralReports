using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.WebService.Models
{
    public class LatestVersionModel
    {
        public string LatestVersion { get; set; }
        public bool IsMandatoryUpgrade { get; set; }
        public string UrlAddress { get; set; }
        public string Message { get; set; }   
    }
}