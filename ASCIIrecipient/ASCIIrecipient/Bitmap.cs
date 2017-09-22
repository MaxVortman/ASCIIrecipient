using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ASCIIrecipient
{
    class Bitmap
    {

        public ARGB this[int i, int j]
        {
            get
            {
                int index = i * stride + j * COUNT_OF_TONES;
                return new ARGB
                {
                    Red = pixels[index],
                    Green = pixels[index + 1],
                    Blue = pixels[index + 2],
                    Alpha = pixels[index + 3]
                };
            }
        }

        private const int COUNT_OF_TONES = 4;
        private int stride;
        private byte[] pixels;

        public int Height;
        public int Width;

        public Bitmap(BitmapSource bitmapSource)
        {
            Height = bitmapSource.PixelHeight;
            Width = bitmapSource.PixelWidth;
            CopyPixels(bitmapSource);
        }

        private void CopyPixels(BitmapSource bitmapSource)
        {
            stride = Width * COUNT_OF_TONES;
            int size = Height * stride;
            pixels = new byte[size];
            bitmapSource.CopyPixels(pixels, stride, 0);            
        }        
    }
}
