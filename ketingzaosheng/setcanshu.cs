using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ps5000example
{
    public partial class setcanshu : Form
    {
        
        public BackgroundWorker bw;    //使用BackgroundWorker进行多线程异步处理
        //Mainform mainform = new Mainform();
        ps5000example.ketingzaosheng.Calculate calculate = new ketingzaosheng.Calculate();
        public setcanshu()
        {
            InitializeComponent();
            
           

        }

 

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            //mainform.serialPort.PortName = //comboBox1.Text;
            //Mainform.Portname = comboBox1.Text;
            //mainform.serialPort.BaudRate = 9600;
            //mainform.serialPort.Parity = Parity.None;
            //mainform.serialPort.DataBits = 8;
            //calculate.celiang_gaodu = textBox1.Text;
            //calculate.G_max = textBox2.Text;
            //calculate.G_bool = comboBox1.Text;
            calculate.setcanshu(textBox1.Text, textBox2.Text, comboBox1.Text);
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
