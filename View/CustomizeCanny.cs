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
    public partial class CustomizeCanny : Form
    {
        Form1 form;
        public CustomizeCanny(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  void button1_Click(object sender, EventArgs e)
        { 
            if (form == null) return;

            form.CannyCusomized((double)numericUpDown1.Value, (double)numericUpDown2.Value);

        }
    }
}
