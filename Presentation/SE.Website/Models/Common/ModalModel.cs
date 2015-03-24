using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Website.Models
{
    public class ModalModel
    {
        public string Title { get; set; }

        public IEnumerable<PropertyInfo> Properties { get; set; }
    }
}