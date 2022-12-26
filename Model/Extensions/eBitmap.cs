using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engmu
{
    public static class eBitmap
    {
        public static Image<Gray, byte> Grayscale(this Bitmap bm)
        {
            if (bm == null) throw new ArgumentNullException();

            int Height = bm.Height;
            int Width = bm.Width;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Color c = bm.GetPixel(j, i);
                    int average = (c.R + c.G + c.B) / 3;
                    bm.SetPixel(j, i, Color.FromArgb(c.A, average, average, average));
                }
            }

            return bm.ToImage<Gray, byte>();
        }

        public static Image<Bgr, byte> Split(this Bitmap bm, char color='r')
        {
            if (bm == null) return null;
            int Height = bm.Height;
            int Width = bm.Width;
            Bitmap cbm = new Bitmap(bm);

            switch (color)
            {
                case 'r':
                case 'R':
                    for (int i = 0; i < Height; ++i)
                    {
                        for (int j = 0; j < Width; ++j)
                        {
                            Color p = cbm.GetPixel(j, i);
                            cbm.SetPixel(j, i, Color.FromArgb(p.A, p.R, 0, 0));
                        }
                    }
                    break;
                case 'g':
                case 'G':
                    for (int i = 0; i < Height; ++i)
                    {
                        for (int j = 0; j < Width; ++j)
                        {
                            Color p = cbm.GetPixel(j, i);
                            cbm.SetPixel(j, i, Color.FromArgb(p.A, 0, p.G, 0));
                        }
                    }
                    break;
                case 'B':
                case 'b':
                    for (int i = 0; i < Height; ++i)
                    {
                        for (int j = 0; j < Width; ++j)
                        {
                            Color p = cbm.GetPixel(j, i);
                            cbm.SetPixel(j, i, Color.FromArgb(p.A, 0, 0, p.B));
                        }
                    }
                    break;
            }

            return cbm.ToImage<Bgr, byte>();
        }
    }
}
