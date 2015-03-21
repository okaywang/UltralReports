using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public abstract class StandaloneConfigBase<TSection> where TSection : ConfigurationSection
    {
        private TSection _section;

        protected abstract string ConfigFullFileName { get; }

        protected abstract string SectionNodeName { get; }

        public TSection Section
        {
            get
            {
                if (_section == null)
                {
                    var map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = ConfigFullFileName;
                    _section = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None).GetSection(this.SectionNodeName) as TSection;
                }
                return _section;
            }
        }
    }
}
