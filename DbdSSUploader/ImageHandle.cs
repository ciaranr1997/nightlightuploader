using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using System.IO;

namespace DbdSSUploader
{
    static class ImageHandle
    {
        public static bool isScoreboard(String screenshot) 
        {
            Bitmap template = ConvertToBitmap("scoreboard.png");
            Bitmap bmp = ConvertToBitmap(screenshot);
            const Int32 divisor = 4;
            const Int32 epsilon = 10;
            Console.WriteLine(template.Width);
            Console.WriteLine(template.Height);

            Console.WriteLine(bmp.Width);
            Console.WriteLine(bmp.Height);
            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.9f);

            TemplateMatch[] tm = etm.ProcessImage(
                new ResizeNearestNeighbor(bmp.Width / divisor, bmp.Height / divisor).Apply(bmp),
                new ResizeNearestNeighbor(template.Width / divisor, template.Height / divisor).Apply(template)
                );
            if (tm.Length == 1)
            {
                return true;
            }

            return false;
        }

        public static Bitmap ConvertToBitmap(string fileName)
        {
            System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            Bitmap copy = new Bitmap(bitmap.Width, bitmap.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(bitmap, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

    }

}

