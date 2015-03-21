using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Website
{
    public interface IScriptWriter
    {
        /// <summary>
        /// Write the scripts content to writer.
        /// </summary>
        /// <param name="writer">The writer where the script content is written into.</param>
        /// <returns>Returns true if the scripts are written successfully; otherwise returns false.</returns>
        void WriteScripts(System.Text.StringBuilder writer);
    }
}
