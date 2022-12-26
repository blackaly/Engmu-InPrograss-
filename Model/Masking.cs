using Emgu.CV;
using Emgu.CV.Ocl;
using Emgu.CV.Structure;
using Engmu.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Engmu.Model
{
    public class Masking : IMask
    {
        public Image<Bgra, byte> BlurMask(Bitmap bm, int maskWidth, int maskHeight)
        {
            if (bm == null) return null;
            if (maskWidth % 2 == 0 && maskHeight % 2 == 0) return null;


            int maskSize = (maskHeight * maskWidth);
            int offset = maskWidth / 2;

            Bitmap blured = new Bitmap(bm);

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    int red = 0, blue = 0, green = 0, alpha = 0;

                    for (int filterX = -offset; filterX <= offset; filterX++)
                    {
                        int pxlx = x + filterX;

                        if (pxlx < 0) pxlx = 0;
                        if (pxlx >= bm.Width) pxlx = bm.Width - 1;  

                        for (int filterY = -offset; filterY <= offset; filterY++)
                        {
                            int pxly = y + filterY;

                            if(pxly < 0) pxly = 0;
                            if(pxly >= bm.Height) pxly = bm.Height - 1;

                            Color c = bm.GetPixel(pxlx, pxly);

                            red += c.R;
                            blue += c.B;
                            green += c.G;
                            alpha += c.A;
                        }
                    }



                    red /= maskSize; blue /= maskSize;
                    green /= maskSize; alpha /= maskSize;

                    blured.SetPixel(x, y, Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue));
                }
            }


            return blured.ToImage<Bgra, byte>();


        }
        public Image<Gray, byte> SobelMask(Bitmap bm, double thresh=50, double threshLinking=100)
        {
            if (bm == null) return null;

            Image<Gray, byte> ImageCanny = new Image<Gray, byte>(bm.Width, bm.Height, new Gray(0));

            ImageCanny = bm.ToImage<Bgra, byte>().Canny(thresh, threshLinking);

            if(ImageCanny == null) return null;

            return ImageCanny;
            
        }
    }
}
