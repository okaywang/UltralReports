using BussinessLogic;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Website.Common;


namespace Website.Models
{
    public interface IListItemModel : IListItemCommands
    {
        string ToJson();
    }

   
}