using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class KeepMinHeightSizeTransformerAttribute : Attribute, IImageFileTransformer
    {
        private int _width;
        private int _minHeight;
        private int _maxByteLength;
        public KeepMinHeightSizeTransformerAttribute(int width, int minHeight, int maxSizeInKb)
        {
            _width = width;
            _minHeight = minHeight;
            _maxByteLength = maxSizeInKb * 1024;
        }

        public Size Transform(string srcPath, string destPath)
        {
            var quality = 100;
            Size size = new Size();
            while (quality > 10)
            {
                size = ImageSizeTransformManager.Instance.ResizeImageToWidth(srcPath, destPath, _width, _minHeight,quality);
                var length = new FileInfo(destPath).Length;
                if (length > _maxByteLength)
                {
                    quality -= 5;
                    continue;
                }
                return size;
            }
            return size; 
        }
    }
}
