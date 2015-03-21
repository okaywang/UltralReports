using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    [ConfigurationCollection(typeof(EnumItemElement), AddItemName = "item")]
    public class EnumItemElementCollection : ConfigurationElementCollection
    {
        public EnumItemElementCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EnumItemElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnumItemElement)element).Value;
        }
    }
}
