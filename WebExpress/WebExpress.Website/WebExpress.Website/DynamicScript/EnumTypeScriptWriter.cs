using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using WebExpress.Core;

namespace WebExpress.Website
{
    public class EnumTypeScriptWriter : IScriptWriter
    {
        public void WriteScripts(StringBuilder writer)
        {
            if (EnumConfigManager.Instance.Section != null)
            {
                var enumTypes = EnumConfigManager.Instance.Section.Enums;
                foreach (var item in EnumConfigManager.Instance.Section.Enums)
                {
                    var ele = item as EnumTypeElement;
                    var enumItems = ele.EnumItems;
                    writer.AppendFormat("webExpress.config.enums.{0} = {{", ele.Name);
                    foreach (var enumItem in enumItems)
                    {
                        writer.AppendFormat("{0}:new EnumItem('{1}','{2}'),", enumItem.Name, enumItem.Value, enumItem.Text);
                    }
                    writer.AppendLine("};");
                }
            }
        }
    }
}
