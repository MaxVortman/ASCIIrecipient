using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ASCIIrecipient
{
    class Converter
    {

        public BitmapSource SourceBmp { get; set; }
        public string ASCIItext
        {
            get { return ascii ?? ""; }
            private set { ascii = value; }
        }

        private string ascii;

        public void CreateASCII()
        {
            var bitmap = new Bitmap(SourceBmp);
            var asciiBuilder = new StringBuilder();

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    var argb = bitmap[i, j];
                    var pixelColor = Color.FromArgb((byte)((argb.Red + argb.Green + argb.Blue + argb.Alpha) / 4), 
                        (byte)((argb.Red + argb.Green + argb.Blue + argb.Alpha) / 4), 
                        (byte)((argb.Red + argb.Green + argb.Blue + argb.Alpha) / 4),
                        (byte)((argb.Red + argb.Green + argb.Blue + argb.Alpha) / 4));
                    var rValue = int.Parse(pixelColor.R.ToString());
                    asciiBuilder.Append(GetGrayShade(rValue));
                }
                asciiBuilder.Append(System.Environment.NewLine);
            }
            ASCIItext = asciiBuilder.ToString();
        }


        private const char BLACK = '@';
        private const char CHARCOAL = '#';
        private const char DARKGRAY = '8';
        private const char MEDIUMGRAY = '&';
        private const char MEDIUM = 'o';
        private const char GRAY = ':';
        private const char SLATEGRAY = '*';
        private const char LIGHTGRAY = '.';
        private const char WHITE = ' ';

        private char GetGrayShade(int redValue)
        {
            char asciival = ' ';

            if (redValue >= 230)
            {
                asciival = WHITE;
            }
            else if (redValue >= 200)
            {
                asciival = LIGHTGRAY;
            }
            else if (redValue >= 180)
            {
                asciival = SLATEGRAY;
            }
            else if (redValue >= 160)
            {
                asciival = GRAY;
            }
            else if (redValue >= 130)
            {
                asciival = MEDIUM;
            }
            else if (redValue >= 100)
            {
                asciival = MEDIUMGRAY;
            }
            else if (redValue >= 70)
            {
                asciival = DARKGRAY;
            }
            else if (redValue >= 50)
            {
                asciival = CHARCOAL;
            }
            else
            {
                asciival = BLACK;
            }

            return asciival;
        }
    }
}
