using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Probleme
{
    class Problem7
    {
        public static void solve()
        {
            Console.WriteLine("Problema 7");

            Console.WriteLine("Enter image path:");
            var path = Console.ReadLine();
            Console.WriteLine("Enter console width:");
            var wConsole = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter console height:");
            var hConsole = int.Parse(Console.ReadLine());

            var bitmap = (Bitmap)Image.FromFile(path);
            var bitmapResized = new Bitmap(wConsole, hConsole);
            var g = Graphics.FromImage((Image)bitmapResized);
            g.DrawImage(bitmap, 0, 0, bitmapResized.Width, bitmapResized.Height);

            for (var y = 0; y < bitmapResized.Height; y++)
            {
                for (var x = 0; x < bitmapResized.Width; x++)
                {
                    var pixel = bitmapResized.GetPixel(x, y);

                    var depth = (pixel.R + pixel.G + pixel.B + pixel.A) / 255.0 / 4.0 * 100.0;

                    char ch = (char)('.' + (int)depth);

                    Console.Write(ch);
                }

                Console.WriteLine();
            }
        }
    }
}
