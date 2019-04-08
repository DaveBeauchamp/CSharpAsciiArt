using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace ForAsciiImageToStartCode
{
    public class Image
    {
        public Tuple<int, int> GetImageBounds(string filePath)
        {
            int width = 0;
            int height = 0;

            using (MagickImage image = new MagickImage())
            {
                image.Read(filePath);
                width = image.Width;
                height = image.Height;
            }

            var pictureBounds = Tuple.Create(width, height);
            return pictureBounds;
        }
        
        public string[,] PixelIntensity(string filePath)
        {
            int width = 0;
            int height = 0;
            string[,] intensity = new string [width , height]; 

            using (MagickImage image = new MagickImage())
            {
                image.Read(filePath);
                width = image.Width - 1;
                height = image.Height - 1;
                intensity = new string [width, height]; 
                int blue = 0;
                int green = 0;
                int red = 0;
                IPixelCollection pc = image.GetPixels();

                for (int i = 0; i < width - 1; i++)
                {

                    for (int j = 0; j < height - 1; j++)
                    {
                        
                        var col = pc.GetPixel(i, j).ToColor();
                        ;

                        if (col.B <= 255)
                        {
                            // don't divide, thake the value as is
                            blue = col.B;
                        }
                        else if (col.B >= 256 && col.B <= 65280)
                        {
                            // divide by 256
                            blue = col.B / 256;
                        }
                        else if (col.B < 65280)
                        {
                            // divide by 65536
                            blue = col.B / 65536;
                        }

                        if (col.G <= 255)
                        {
                            // don't divide, take the value as is
                            green = col.G;
                        }
                        else if (col.G >= 256 && col.G <= 65280)
                        {
                            // divide by 256
                            green = col.G / 256;
                        }
                        else if (col.G < 65280)
                        {
                            // divide by 65536
                            green = col.G / 65536;
                        }

                        if (col.R <= 255)
                        {
                            // don't divide, thake the value as is
                            red = col.R;
                        }
                        else if (col.R >= 256 && col.R <= 65280)
                        {
                            // divide by 256
                            red = col.R / 256;
                        }
                        else if (col.R < 65280)
                        {
                            // divide by 65536
                            red = col.R / 65536;
                        }

                        //Decimal spectrum
                        //Blue divide value: 0 - 255
                        //Green divide value: 256 - 65280
                        //Red divide value: 65536 - 16711680

                        int pixVal = 0;
                        string asciiShade = string.Empty;

                        if (red == 0 && green == 0 && blue == 0)
                        {
                            //don't divide just use 0
                            pixVal = 0;
                        }
                        else
                        {
                            pixVal = (red + green + blue) / 3;
                        }

                        asciiShade = AsciiShadeChar(pixVal);
                        
                        intensity[i, j] = asciiShade; 
                        
                    }
                }
            }
            
            return intensity;
        }

        private string AsciiShadeChar(int pixelIntensity)
        {
            string asciiShade = string.Empty;

            if (pixelIntensity == 0)
            {
                asciiShade = " ";
            }
            else if (pixelIntensity > 0 && pixelIntensity <= 11)
            {
                asciiShade = ".";
            }
            else if (pixelIntensity > 11 && pixelIntensity <= 22)
            {
                asciiShade = ",";
            }
            else if (pixelIntensity > 22 && pixelIntensity <= 33)
            {
                asciiShade = ";";
            }
            else if (pixelIntensity > 33 && pixelIntensity <= 44)
            {
                asciiShade = "*";
            }
            else if (pixelIntensity > 44 && pixelIntensity <= 55)
            {
                asciiShade = "L";
            }
            else if (pixelIntensity > 55 && pixelIntensity <= 66)
            {
                asciiShade = "s";
            }
            else if (pixelIntensity > 66 && pixelIntensity <= 77)
            {
                asciiShade = "v";
            }
            else if (pixelIntensity > 88 && pixelIntensity <= 99)
            {
                asciiShade = "{";
            }
            else if (pixelIntensity > 99 && pixelIntensity <= 110)
            {
                asciiShade = "I";
            }
            else if (pixelIntensity > 110 && pixelIntensity <= 121)
            {
                asciiShade = "Z";
            }
            else if (pixelIntensity > 121 && pixelIntensity <= 132)
            {
                asciiShade = "S";
            }
            else if (pixelIntensity > 132 && pixelIntensity <= 143)
            {
                asciiShade = "j";
            }
            else if (pixelIntensity > 143 && pixelIntensity <= 154)
            {
                asciiShade = "[";
            }
            else if (pixelIntensity > 154 && pixelIntensity <= 165)
            {
                asciiShade = "E";
            }
            else if (pixelIntensity > 165 && pixelIntensity <= 176)
            {
                asciiShade = "V";
            }
            else if (pixelIntensity > 176 && pixelIntensity <= 187)
            {
                asciiShade = "p";
            }
            else if (pixelIntensity > 187 && pixelIntensity <= 198)
            {
                asciiShade = "h";
            }
            else if (pixelIntensity > 198 && pixelIntensity <= 209)
            {
                asciiShade = "b";
            }
            else if (pixelIntensity > 209 && pixelIntensity <= 220)
            {
                asciiShade = "#";
            }
            else if (pixelIntensity > 220 && pixelIntensity <= 231)
            {
                asciiShade = "B";
            }
            else if (pixelIntensity > 231 && pixelIntensity <= 242)
            {
                asciiShade = "g";
            }
            else if (pixelIntensity > 242 && pixelIntensity <= 253)
            {
                asciiShade = "Q";
            }
            else if (pixelIntensity > 253)
            {
                asciiShade = "@";
            }

            return asciiShade;
            
        }

    }
}
