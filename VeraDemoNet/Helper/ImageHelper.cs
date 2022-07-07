using System;
using System.IO;
using System.Linq;
using System.Text;

namespace VeraDemoNet.Helper
{
    public static class ImageHelper
    {
        public static void AssertIsValid(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM"); // BMP
            var gif = Encoding.ASCII.GetBytes("GIF"); // GIF
            var png = new byte[] { 137, 80, 78, 71 }; // PNG
            var tiff = new byte[] { 73, 73, 42 }; // TIFF
            var tiff2 = new byte[] { 77, 77, 42 }; // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)) ||
                gif.SequenceEqual(bytes.Take(gif.Length)) ||
                png.SequenceEqual(bytes.Take(png.Length)) ||
                tiff.SequenceEqual(bytes.Take(tiff.Length)) ||
                tiff2.SequenceEqual(bytes.Take(tiff2.Length)) ||
                jpeg.SequenceEqual(bytes.Take(jpeg.Length)) ||
                jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
            {
                return;
            }

            throw new ArgumentException("Invalid image type");
        }

        public static void AssertIsValid(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                AssertIsValid(ms.ToArray());
            }
        }
    }
}