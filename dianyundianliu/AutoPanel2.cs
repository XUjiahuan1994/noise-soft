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
    public partial class AutoPanel2 : Form
    {
        public static AutoPanel2 form = new AutoPanel2();
        public AutoPanel2()
        {
            InitializeComponent();
            form = this;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainform a = new Mainform();

            Mainform.AutoSaveFlag = 1;

            //ainform.timer1_Tick(object sender, EventArgs e);
            //ainform.timer1.Interval = 1000;
            //ainform.timer1.Start();
            Mainform.flag_caiji = 0;

           // a.autocollect();
          //   a.timer1.Enabled=true;
            //a.timer1.Interval = 1000;
           //  a.timer1.Start();
          //  a.shijian = 60;
          //  this.Close();
            //a.Show();
           // a.autocollectTimer = new System.Windows.Forms.Timer();
           // a.autocollectTimer.Enabled = true;
          //  a.autocollectTimer.Interval = 1000;
           // a.autocollectTimer.Tick += new EventHandler(a.autocollect);
          //  a.autocollectTimer.Start();
           // a.Show();






        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainform a = new Mainform();
            Mainform.AutoSaveFlag = 0;
            a.timer1.Enabled = true;
            a.timer1.Interval = 1000;
            a.timer1.Start();
            Mainform.flag_caiji = 0;

            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
