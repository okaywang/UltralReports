using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    internal class ImageSizeTransformManager
    {
        public static readonly ImageSizeTransformManager Instance = new ImageSizeTransformManager();
        private ImageSizeTransformManager()
        {

        }

        public Size ResizeImageToWidth(string srcPath, string destPath, int destWidth, int quality = 100)
        {
            var srcImage = Image.FromFile(srcPath);
            var srcWidth = srcImage.Width;
            var srcHeight = srcImage.Height;

            double factor = (double)destWidth / srcWidth;
            var destHeight = (int)(srcHeight * factor);

            return ResizeImage(srcImage, destPath, destWidth, destHeight, quality);
        }

        public Size ResizeImageToWidth(string srcPath, string destPath, int destWidth, int minHeight, int quality = 100)
        {
            var srcImage = Image.FromFile(srcPath);
            var srcWidth = srcImage.Width;
            var srcHeight = srcImage.Height;

            double factor = (double)destWidth / srcWidth;
            var destHeight = (int)(srcHeight * factor);
            if (destHeight <= minHeight)
            {
                destHeight = minHeight;
                factor = (double)destHeight / srcHeight;
            }

            var validWidth = (int)(destWidth / factor);
            var redundantWidth = srcWidth - validWidth;

            var srcRect = new Rectangle(redundantWidth / 2, 0, validWidth, srcHeight);
            return ResizeImage(srcImage, destPath, destWidth, destHeight, srcRect, quality);
        }

        public Size ResizeImageToHeight(string srcPath, string destPath, int destHeight, int quality = 100)
        {
            var srcImage = Image.FromFile(srcPath);
            var srcWidth = srcImage.Width;
            var srcHeight = srcImage.Height;

            double factor = (double)destHeight / srcHeight;
            var destWidth = (int)(srcWidth * factor);

            return ResizeImage(srcImage, destPath, destWidth, destHeight, quality);
        }

        public Size ResizeImageToSize(string srcPath, string destPath, int destWidth, int destHeight, ImageResizeType resizeType, int quality = 100)
        {
            var srcImage = Image.FromFile(srcPath);
            var srcWidth = srcImage.Width;
            var srcHeight = srcImage.Height;

            Rectangle srcRect = new Rectangle(0, 0, srcWidth, srcHeight);
            if (resizeType == ImageResizeType.CutFromCenter)
            {
                double factorWidth = (double)destWidth / srcWidth;
                double factorHeight = (double)destHeight / srcHeight;
                var invalidFactor = Math.Max(factorWidth, factorHeight);
                if (factorWidth > factorHeight)
                {
                    var validHeight = (int)(destHeight / invalidFactor);
                    var redundantHeight = srcHeight - validHeight;
                    srcRect = new Rectangle(0, redundantHeight / 2, srcWidth, validHeight);
                }
                else
                {
                    var validWidth = (int)(destWidth / invalidFactor);
                    var redundantWidth = srcWidth - validWidth;
                    srcRect = new Rectangle(redundantWidth / 2, 0, validWidth, srcHeight);
                }
            }

            return ResizeImage(srcImage, destPath, destWidth, destHeight, srcRect, quality);
        }

        public Size ResizeImage(Image srcImage, string destPath, int destWidth, int destHeight, int quality = 100)
        {
            var srcRect = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            return ResizeImage(srcImage, destPath, destWidth, destHeight, srcRect, quality);
        }

        public Size ResizeImage(Image srcImage, string destPath, int destWidth, int destHeight, Rectangle srcRect, int quality)
        {
            var destSize = new Size(destWidth, destHeight);
            using (var destBitmap = new Bitmap(destWidth, destHeight))
            {
                var g = Graphics.FromImage(destBitmap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.White);
                var destRect = new Rectangle(Point.Empty, destSize);
                g.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);

                var parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
                var encoders = ImageCodecInfo.GetImageEncoders();
                var encoder = encoders.Where(i => i.FormatID == srcImage.RawFormat.Guid).FirstOrDefault();
                destBitmap.Save(destPath, encoder, parameters);
            }
            return destSize;
        }
    }
}
