using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engmu.View
{
    public partial class HistogramDetails : Form
    {
        Bitmap bm;
        public HistogramDetails(Bitmap _bm)
        {
            InitializeComponent();
            this.bm = _bm;

            ShowHistogram();
        }

     
        private void ShowHistogram()
        {
           
                chart1.Series["Red"].Points.Clear();
                chart1.Series["Green"].Points.Clear();
                chart1.Series["Blue"].Points.Clear();

                Bitmap bmpImg = bm;
                int width = bmpImg.Width;
                int hieght = bmpImg.Height;


                int[] ni_Red = new int[256];
                int[] ni_Green = new int[256];
                int[] ni_Blue = new int[256];

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < hieght; j++)
                    {
                        Color pixelColor = bmpImg.GetPixel(i, j);

                        ni_Red[pixelColor.R]++;
                        ni_Green[pixelColor.G]++;
                        ni_Blue[pixelColor.B]++;

                    }
                }


                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["Red"].Points.AddY(ni_Red[i]);
                    chart1.Series["Green"].Points.AddY(ni_Green[i]);
                    chart1.Series["Blue"].Points.AddY(ni_Blue[i]);
                }
            
        }
        
    }
}
