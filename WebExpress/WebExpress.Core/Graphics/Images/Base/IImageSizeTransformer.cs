using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public interface IImageFileTransformer
    {
        Size Transform(string srcPath, string destPath);
    }
}
