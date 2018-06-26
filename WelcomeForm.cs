using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ps5000example
{
    public partial class WelcomeForm : Form
    {

        //protected override void OnLoad(EventArgs e)
        //{
        //    System.Threading.Thread.Sleep(5000);
        //    base.OnLoad(e);
        //}
        

        public WelcomeForm()
        {

            //this.BackgroundImage = Image.FromFile(@"图片路径");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainform frm = new Mainform();
            
            //this.Hide();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AudioNoiseform frm = new AudioNoiseform();

            //this.Hide();
            frm.ShowDialog();
        }
    }
}
