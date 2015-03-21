using SE.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace SE.WebService.Models
{
    public class CommunityModel : ITranslatable<Community,CommunityModel>
    {
         /// <summary>
        /// 楼宇Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 楼宇名称
        /// </summary>
        public string Name { get; set; }


        public CommunityModel Translate(Community from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            return this;
        }
    }

    public enum ComminityModelStatus
    {
        Success,

        [DisplayText("该区县不存在")]
        CountyNotExisted
    } 
}