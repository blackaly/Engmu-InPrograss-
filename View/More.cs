using Emgu.CV;
using Engmu.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engmu
{
    public partial class More : Form
    {
        Form1 form;
        public More(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void histogramButton_Click(object sender, EventArgs e)
        {

            if(form.img != null)
            {
                HistogramDetails h = new HistogramDetails(form.img.ToBitmap());
                h.Show();
            }

            /*
            if(form.img != null)
            {
                int[] img_R = new int[256];
                int[] img_G = new int[256];
                int[] img_B = new int[256];

                Bitmap bm = form.img.ToBitmap();
                
                int Height = bm.Height;
                int Width = bm.Width;

                for(int i = 0; i < Height; i++)
                {
                    for(int j = 0; j < Width; j++) { 
                        Color px = bm.GetPixel(j, i);

                        img_R[px.R]++;
                        img_B[px.B]++;
                        img_G[px.G]++;
                    }
                }

            }*/



        }
    }
}
