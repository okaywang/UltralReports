using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    [ConfigurationCollection(typeof(EnumTypeElement), AddItemName = "enum")]
    public class EnumTypeElementCollection : ConfigurationElementCollection
    {
        public EnumTypeElementCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EnumTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnumTypeElement)element).Name;
        }
    }
}
