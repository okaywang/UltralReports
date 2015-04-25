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
using WebExpress.Core;
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
        [Required]
        [DisplayName("机组")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [Required]
        [DisplayName("监控类型")]
        [ControlType(typeof(NativeSelect))]
        [MonitorTypeControlSourceAttribute]
        public int MonitorTypeId { get; set; }

        [Required]
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

    #region Part
    public class PartListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    [RequestUrl("/Equipment/PartAdd")]
    public class PartAddModel
    {
        [Required]
        [DisplayName("机组号")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [Required]
        [DisplayName("设备名称")]
        [ControlType(typeof(NativeSelect))]
        public int EquipmentId { get; set; }

        [Required]
        [DisplayName("部件名称")]
        public string Name { get; set; }

        [Required]
        [DisplayName("测点名称")]
        public string DataKey { get; set; }

        [Required]
        [DisplayName("单位")]
        public string Unit { get; set; }

        [Required]
        [DisplayName("高3限")]
        public decimal H3 { get; set; }

        [Required]
        [DisplayName("高2限")]
        public decimal H2 { get; set; }

        [Required]
        [DisplayName("高1限")]
        public decimal H1 { get; set; }

        [Required]
        [DisplayName("低1限")]
        public decimal L1 { get; set; }

        [Required]
        [DisplayName("低2限")]
        public decimal L2 { get; set; }

        [Required]
        [DisplayName("低3限")]
        public decimal L3 { get; set; }
    }

    [RequestUrl("/Equipment/PartUpdate")]
    public class PartUpdateModel
    {
        [ControlType(typeof(NativeInputHidden))]
        public int Id { get; set; }

        [Required]
        [DisplayName("机组号")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [Required]
        [DisplayName("设备名称")]
        [ControlType(typeof(NativeSelect))]
        public int EquipmentId { get; set; }

        [Required]
        [DisplayName("部件名称")]
        public string Name { get; set; }

        [Required]
        [DisplayName("测点名称")]
        public string DataKey { get; set; }

        [Required]
        [DisplayName("单位")]
        public string Unit { get; set; }

        [Required]
        [DisplayName("高3限")]
        public decimal H3 { get; set; }

        [Required]
        [DisplayName("高2限")]
        public decimal H2 { get; set; }

        [Required]
        [DisplayName("高1限")]
        public decimal H1 { get; set; }

        [Required]
        [DisplayName("低1限")]
        public decimal L1 { get; set; }

        [Required]
        [DisplayName("低2限")]
        public decimal L2 { get; set; }

        [Required]
        [DisplayName("低3限")]
        public decimal L3 { get; set; }
    }

    public class PartListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("机组号")]
        public MachineSetType MachineSet { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        [DisplayName("部件名称")]
        public string Name { get; set; }

        public int EquipmentId { get; set; }

        [DisplayName("测点名称")]
        public string DataKey { get; set; }

        [DisplayName("单位")]
        public string Unit { get; set; }

        [DisplayName("高3")]
        public decimal H3 { get; set; }

        [DisplayName("高2")]
        public decimal H2 { get; set; }

        [DisplayName("高1")]
        public decimal H1 { get; set; }

        [DisplayName("低1")]
        public decimal L1 { get; set; }

        [DisplayName("低2")]
        public decimal L2 { get; set; }

        [DisplayName("低3")]
        public decimal L3 { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/Equipment/PartUpdate"), 
                    new ListItemCommand("remove","删除","/Equipment/PartRemove") 
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    #endregion

    #region Pro Part
    public class ProPartListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    [RequestUrl("/Equipment/ProPartAdd")]
    public class ProPartAddModel
    {
        [Required]
        [DisplayName("机组号")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [Required]
        [DisplayName("设备名称")]
        [ControlType(typeof(NativeSelect))]
        public int EquipmentId { get; set; }

        [Required]
        [DisplayName("部件")]
        [ControlType(typeof(NativeSelect))]
        public int PartId { get; set; }

        [Required]
        [DisplayName("专业")]
        [ControlType(typeof(NativeSelect))]
        [MajorControlSource]
        public int MajorId { get; set; }

        [Required]
        [DisplayName("高限")]
        public decimal PH { get; set; }

        [Required]
        [DisplayName("低限")]
        public decimal PL { get; set; }


    }

    [RequestUrl("/Equipment/ProPartUpdate")]
    public class ProPartUpdateModel
    {
        [Required]
        [DisplayName("机组号")]
        [ControlType(typeof(NativeSelect))]
        [EnumControlSource(typeof(MachineSetType))]
        public MachineSetType MachineSet { get; set; }

        [Required]
        [DisplayName("设备名称")]
        [ControlType(typeof(NativeSelect))]
        public int EquipmentId { get; set; }

        [DisplayName("专业")]
        [ControlType(typeof(NativeSelect))]
        [MajorControlSource]
        public int MajorId { get; set; }

        [Required]
        [DisplayName("部件")]
        [ControlType(typeof(NativeSelect))]
        public int PartId { get; set; }

        [Required]
        [DisplayName("高限")]
        public decimal PH { get; set; }

        [Required]
        [DisplayName("低限")]
        public decimal PL { get; set; }
    }

    public class ProPartListItemModel : IListItemModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("机组号")]
        public MachineSetType MachineSet { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        [DisplayName("部件名称")]
        public string Name { get; set; }

        public int EquipmentId { get; set; }

        [Required]
        [DisplayName("高限")]
        public decimal PH { get; set; }

        [Required]
        [DisplayName("低限")]
        public decimal PL { get; set; }

        [DisplayName("操作")]
        [JsonIgnore]
        public IListItemCommand[] Commands
        {
            get
            {
                return new IListItemCommand[]
                { 
                    new ListItemCommand("update", "编辑", "/Equipment/PartUpdate"), 
                    new ListItemCommand("remove","删除","/Equipment/PartRemove") 
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