using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace ForAsciiImageToStartCode
{
    public class Program
    {

        static void Main(string[] args)
        {
            Image test = new Image();
            
            Console.WriteLine("Please enter a File path (Note: change the font size to 5)");
            string filePath = Console.ReadLine();
            
            var bounds = test.GetImageBounds(filePath);
            
            var pic = test.PixelIntensity(filePath);
            ;
            for (int j = 0; j < bounds.Item2 - 1; j++)
            {
                for (int i = 0; i < bounds.Item1 - 1; i++)
                {
                    Console.Write(pic[i, j]);
                    Console.Write(pic[i, j]);
                    Console.Write(pic[i, j]);
                }
                Console.Write("\r\n");
            }
            
            Console.ReadLine();

        }

    }
}
