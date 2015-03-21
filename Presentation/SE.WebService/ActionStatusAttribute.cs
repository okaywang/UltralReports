using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.WebService
{
    public class ActionStatusAttribute : Attribute
    {
        private Type _type;
        public ActionStatusAttribute(Type status)
        {

        }
    }
}