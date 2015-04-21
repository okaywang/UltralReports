﻿using BussinessLogic;
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
    public class UltraRecordListPageModel : ListPageModal
    {
        public string AddItemUrl { get; set; }
    }

    public class UltraSummaryListItemModel : IListItemModel
    {
        public int PartId { get; set; }

        [DisplayName("部件设备名称")]
        public string PartName { get; set; }

        [DisplayName("设备名称")]
        public string EquipmentName { get; set; }

        [DisplayName("监控类型")]
        public string MonitorTypeName { get; set; }

        public decimal L3 { get; set; }

        public decimal H1 { get; set; }

        [DisplayName("额定运行范围")]
        public string RatedRange { get; set; }

        [DisplayName("班值")]
        public int Duty { get; set; }

        [DisplayName("超限次数")]
        public int Times { get; set; }

        [DisplayName("超限时长")]
        public int Duration { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IListItemCommand[] Commands
        {
            get
            {
                return new ListItemCommand[0];
            }
        }
    }
    #endregion

}