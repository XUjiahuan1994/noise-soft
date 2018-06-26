using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System.Threading;


namespace ps5000example
{
    public partial class AudioNoiseform : Form
    {

        

        public AudioNoiseform()
        {
            InitializeComponent();
        }

    
        private void AudioNoiseform_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {

            long size_n = 2 * 1024 * 1024;
            double Fs8 = 0;


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            string strFileName = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
               // return;
               
            }


            //readtimedata.Readtimedata readtimedata = new readtimedata.Readtimedata();
            //MWArray result = readtimedata.readtimedata(strFileName);



            strFileName = ofd.FileName;
            
            MessageBox.Show("您当前选择数据为" + strFileName.ToString());
            FileStream file = new FileStream(strFileName, FileMode.Open);
            byte[] byData = new byte[8];
            sbyte[] data_7 = new sbyte[8];
            file.Seek(0, SeekOrigin.Begin);

            file.Read(byData, 0, 7);

            file.Close();
            
            for (int i = 0; i < 8; i++)
                data_7[i] = (sbyte)byData[i];
            

            switch (data_7[0])
            {
                case 0: Fs8 = 1024; break;
                case 1: Fs8 = 1024 * 2; break;
                case 2: Fs8 = 1024 * 4; break;
                case 3: Fs8 = 1024 * 8; break;
                case 4: Fs8 = 1024 * 16; break;
                case 5: Fs8 = 1024 * 32; break;
                case 6: Fs8 = 1024 * 64; break;
                case 7: Fs8 = 1024 * 128; break;
                case 8: Fs8 = 1024 * 256; break;
                case 9: Fs8 = 1024 * 512; break;
                case 10: Fs8 = 1024 * 1024; break;
                case 18:
                    Fs8 = 1024 * 1024 * 62.5;
                    //data_voltage1 = file.Read(fid, size_n + 7, 'schar');
                    //data_voltage = data_voltage1(8:size_n + 7);
                    break;
                case 21:
                    Fs8 = 1024 * 1024 * 500;
                    //data_voltage1 = fread(fid, size_n + 1, 'schar', 7);
                    //data_voltage = data_voltage1(2:size_n + 1);  
                    break;

            }

            //显示文本信息
            
            string[] sArray = strFileName.Split('\\');

            textBox_filename8.Text = sArray[5];
            textBox_Fs8.Text =  ((Fs8 / 1024) / 1024).ToString() + " M";
            textBox_size_n8.Text = ((size_n/1024)/1024).ToString()+" M";

             
            textBox_voltage8.Text = sArray[4]+" kV";



        }

        private void button3_Click(object sender, EventArgs e)
        {
            long size_n = 2 * 1024 * 1024;
            double Fs0 = 0;


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            string strFileName = "D:\\开题\\shuju\\20120712_20m+\\0\\2012-07-12-12_25_56.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
                // return;

            }
            else
            {

                strFileName = ofd.FileName;


            }
  

            MessageBox.Show("您当前选择数据为" + strFileName.ToString());
            FileStream file = new FileStream(strFileName, FileMode.Open);
            byte[] byData = new byte[8];
            sbyte[] data_7 = new sbyte[8];
            file.Seek(0, SeekOrigin.Begin);

            file.Read(byData, 0, 7);

            file.Close();

            for (int i = 0; i < 8; i++)
                data_7[i] = (sbyte)byData[i];


            switch (data_7[0])
            {
                case 0: Fs0 = 1024; break;
                case 1: Fs0 = 1024 * 2; break;
                case 2: Fs0 = 1024 * 4; break;
                case 3: Fs0 = 1024 * 8; break;
                case 4: Fs0 = 1024 * 16; break;
                case 5: Fs0 = 1024 * 32; break;
                case 6: Fs0 = 1024 * 64; break;
                case 7: Fs0 = 1024 * 128; break;
                case 8: Fs0 = 1024 * 256; break;
                case 9: Fs0 = 1024 * 512; break;
                case 10: Fs0 = 1024 * 1024; break;
                case 18:
                    Fs0 = 1024 * 1024 * 62.5;
                    
                    break;
                case 21:
                    Fs0 = 1024 * 1024 * 500;
                   
                    break;

            }

            //显示文本信息
            string[] sArray = strFileName.Split('\\');

            textBox_filename0.Text = sArray[5];
            textBox_Fs0.Text = ((Fs0 / 1024) / 1024).ToString() + " M";
            textBox_size_n0.Text = ((size_n / 1024) / 1024).ToString() + " M";
            textBox_voltage0.Text = sArray[4] + " kV";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = "D:\\开题\\shuju";
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DirectoryInfo theFolder = new DirectoryInfo(foldPath);
                FileInfo[] dirInfo = theFolder.GetFiles();
                //遍历文件夹  
                foreach (FileInfo file in dirInfo)
                {
                    MessageBox.Show(file.ToString());
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private IntPtr hChild;  //子窗口
        private IntPtr hParent; //父窗口
        public delegate void UpdateUI();//委托用于更新UI
        Thread startload;//线程用于matlab窗体处理  
        IntPtr figure1;//图像句柄  

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "matlab资源调用中！";
            startload = new Thread(new ThreadStart(startload_run));
            //开始线程  
            startload.Start();
            
        }




        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        void startload_run()
        {
            int count50ms = 0;
            //实例化matlab对象
            temdis.Class1 distribute = new temdis.Class1();
            //调用方法画高斯分布函数图
            distribute.temdis();

            //循环查找figure1窗体
            while (figure1 == IntPtr.Zero)
            {
                //查找matlab的Figure 1窗体
                figure1 = DotNetWin32.FindWindow("SunAwtFrame", "Figure 1");
                //延时50ms
                Thread.Sleep(50);
                count50ms++;
                //20s超时设置
                if (count50ms >= 400)
                {
                    label4.Text = "matlab资源加载时间过长！";
                    return;
                }
            }

            //跨线程，用委托方式执行
            UpdateUI update = delegate
            {
                //隐藏标签
                label4.Visible = false;
                //设置matlab图像窗体的父窗体为panel
                DotNetWin32.SetParent(figure1, this.panel_figure.Handle);
                //获取窗体原来的风格
                var style = DotNetWin32.GetWindowLong(figure1, DotNetWin32.GWL_STYLE);
                //设置新风格，去掉标题,不能通过边框改变尺寸
                DotNetWin32.SetWindowLong(figure1, DotNetWin32.GWL_STYLE, style & ~DotNetWin32.WS_CAPTION & ~DotNetWin32.WS_THICKFRAME);
                
                //移动到panel里合适的位置并重绘
                DotNetWin32.MoveWindow(figure1, 0, 0, panel_figure.Width + 20, panel_figure.Height , true);
                //调用显示窗体函数，隐藏再显示相当于刷新一下窗体
                
            };
            panel_figure.Invoke(update);
            //再移动一次，防止显示错误
            Thread.Sleep(100);
            DotNetWin32.MoveWindow(figure1, 0, 0, panel_figure.Width + 20, panel_figure.Height , true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
