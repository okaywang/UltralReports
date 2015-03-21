using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class FixedDimensionTransformerAttribute : Attribute, IImageFileTransformer
    {
        private int _width;
        private int _height;
        private int _maxByteLength;
        private ImageResizeType _resizeType;

        public FixedDimensionTransformerAttribute(int width, int height, int maxSizeInKb)
            : this(width, height, maxSizeInKb, ImageResizeType.CutFromCenter)
        {
        }

        public FixedDimensionTransformerAttribute(int width, int height, int maxSizeInKb, ImageResizeType resizeType)
        {
            _width = width;
            _height = height;
            _maxByteLength = maxSizeInKb * 1024;
            _resizeType = resizeType;
        }

        public Size Transform(string srcPath, string destPath)
        {
            var quality = 100;
            Size size = new Size();
            while (quality > 10)
            {
                size = ImageSizeTransformManager.Instance.ResizeImageToSize(srcPath, destPath, _width, _height, _resizeType, quality);
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
