using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class EnumItemElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
        }

        [ConfigurationProperty("value", IsRequired = true, IsKey = true, DefaultValue = 0)]
        public int Value
        {
            get
            {
                return (int)base["value"];
            }
        }

        [ConfigurationProperty("text", IsRequired = false, IsKey = true, DefaultValue = "")]
        public string Text
        {
            get
            {
                return base["text"] as string;
            }
        }
    }
}
