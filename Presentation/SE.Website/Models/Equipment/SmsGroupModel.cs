using BussinessLogic;
using Common.Types;
using DataAccess;
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
    #region Equipment
    public class EquipmentListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    public class MonitorTypeControlSourceAttribute : Attribute, IControlSource
    {
        public NameValuePair[] GetSource()
        {
            var bll = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(EquipmentBussinessLogic)) as EquipmentBussinessLogic;
            var entities = bll.MonitorTypeGetAll();
            var items = AutoMapper.Mapper.Map<List<MonitorType>, NameValuePair[]>(entities);
            return items;
        }
    }

    [RequestUrl("/Equipment/Add")]
    public class EquipmentAddModel
    {
        [DisplayName("机组")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [DisplayName("监控类型")]
        [ControlType(typeof(NativeSelect))]
        [MonitorTypeControlSourceAttribute]
        public int MonitorTypeId { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }
    }

    [RequestUrl("/Equipment/Update")]
    public class EquipmentUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [DisplayName("机组")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [DisplayName("监控类型")]
        [ControlType(typeof(NativeSelect))]
        [MonitorTypeControlSourceAttribute]
        public int MonitorTypeId { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }
    }

    public class EquipmentListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("机组")]
        public MachineSetType MachineSet { get; set; }

        public int MonitorTypeId { get; set; }

        [DisplayName("监控类型")]
        public string MonitorTypeName { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/Equipment/Update"), 
                    new ListItemCommand("remove","删除","/Equipment/Remove") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    #endregion

    #region Monitor Type
    public class MonitorTypeListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    [RequestUrl("/Equipment/MonitorTypeAdd")]
    public class MonitorTypeAddModel
    {
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    [RequestUrl("/Equipment/MonitorTypeUpdate")]
    public class MonitorTypeUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
    }

    public class MonitorTypeListItemModel : IListItemModel
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
                    new ListItemCommand("update", "编辑", "/Equipment/MonitorTypeUpdate"), 
                    new ListItemCommand("remove","删除","/Equipment/MonitorTypeRemove") 
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