using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Common;

namespace Website.Models
{
    #region Monitor Type
    public class MajorListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    [RequestUrl("/Major/Add")]
    public class MajorAddModel
    {
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    [RequestUrl("/Major/Update")]
    public class MajorUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    public class MajorListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/Major/Update"), 
                    new ListItemCommand("remove","删除","/Major/Remove") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    #endregion
}