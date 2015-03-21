using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class EnumTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public EnumItemElementCollection InnerEnumItems
        {
            get
            {
                var elements = base[""] as EnumItemElementCollection;
                return elements;
            }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true, DefaultValue = "")]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
        }

        [ConfigurationProperty("type", DefaultValue = "")]
        private string EnumTypeName
        {
            get
            {
                return ((string)base["type"]).Trim();
            }
        }

        private IEnumItem[] _enumItems;
        public IEnumItem[] EnumItems
        {
            get
            {
                if (_enumItems == null)
                {
                    var items = EnumExtenstion.GetEnumItems(Type.GetType(EnumTypeName));
                    var overrideItems = this.InnerEnumItems.Cast<EnumItemElement>();
                    foreach (var item in items)
                    {
                        var overrideEnumItem = overrideItems.FirstOrDefault(i => i.Value == item.Value);
                        if (overrideEnumItem != null)
                        {
                            item.Text = overrideEnumItem.Text;
                        }
                    }
                    _enumItems = items;
                }
                return _enumItems;
            }
        }
    }
}
