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
    public partial class dianchi_warning : Form
    {
        public dianchi_warning()
        {
            InitializeComponent();
            Mainform a = new Mainform();
            a.init_flag = 0;
        }
    }
}
