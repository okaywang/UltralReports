using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class EnumSettingSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public EnumTypeElementCollection Enums
        {
            get
            {
                return base[""] as EnumTypeElementCollection;
            }
        }
    }
}
