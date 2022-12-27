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
using Emgu;
using Emgu.CV;
using Emgu.CV.UI;
using Engmu;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Engmu.Model;
using Engmu.View;

namespace Engmu
{
    public partial class Form1 : Form
    {
        OpenFileDialog _ = new OpenFileDialog();
        private string USERNAME = Environment.UserName;
        private const string FILTER = "Bitmap Files (*.bmp;*.dib)|*.bmp;*.dib|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif";
        public Image<Bgr, byte> img;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _.InitialDirectory = @"C:\Users\" + USERNAME + @"\Pictures";
            _.Filter = FILTER;
            _.FilterIndex = 2;


            if (_.ShowDialog() == DialogResult.OK)
            {

                img = new Image<Bgr, byte>(_.FileName);

                if(imageBox2.Image != null)
                {
                    imageBox2.Image = null;
                }

                imageBox1.Image = img;
                imageBox1.FunctionalMode = ImageBox.FunctionalModeOption.PanAndZoom;

            }
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageBox2.Image = await Task.Run(() => { 
                return img.ToBitmap().Grayscale();
            });

        }

        private async void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }

            var _img = new Bitmap(img.ToBitmap());

            imageBox2.Image = await Task.Run(() => {
                return img.ToBitmap().Split('r');
            });


    }

    private async void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }
            imageBox2.Image = await Task.Run(() =>
            {
                return img.ToBitmap().Split('g');
            });
        }

        private async void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }
            imageBox2.Image = await Task.Run(() => { 
                return img.ToBitmap().Split('b');
            });
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            More m = new More(this);
            m.Show();
        }

        private async void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }

            var _img = new Bitmap(img.ToBitmap());

            imageBox2.Image = await Task.Run(() => {
                return new Masking().BlurMask(_img, 9, 9);
            });
        }

        private async void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }

            var _img = new Bitmap(img.ToBitmap());

            imageBox2.Image = await Task.Run(() => {
                return new Masking().SobelMask(_img);
            });

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomizeCanny canny = new CustomizeCanny(this);
            canny.Show();
        }

        public async void CannyCusomized(double tresh, double threshLindking)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }

            var _img = new Bitmap(img.ToBitmap());

            imageBox2.Image = await Task.Run(() => {
                Image<Gray, byte> m = new Masking().SobelMask(_img, tresh, threshLindking);
                if (m == null) return null;

                return  m;
            });
        }

        private async void binrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox2.Image != null)
            {
                imageBox2.Image = null;
            }

            var _img = new Bitmap(img.ToBitmap());

            imageBox2.Image = await Task.Run(() => {
                return _img.Binarization().ToImage<Gray, byte>();
            });
        }
    }
}
