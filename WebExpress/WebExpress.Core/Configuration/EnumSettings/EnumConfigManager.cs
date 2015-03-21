using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class EnumConfigManager : StandaloneConfigBase<EnumSettingSection>
    {
        public static readonly EnumConfigManager Instance = new EnumConfigManager();

        protected override string ConfigFullFileName
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/EnumSettings.config"); }
        }

        protected override string SectionNodeName
        {
            get { return "enumTypes"; }
        }
    }
}
