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

            var _img = img.Clone();

            imageBox2.Image = await Task.Run(() => {
               return _img.ToBitmap().Split('r');
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
            More m = new More();
            m.Show();
        }
    }
}
