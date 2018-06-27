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
using ZedGraph;
using System.Collections;


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
            


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            strFileName8 = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
               // return;
               
            }


            //readtimedata.Readtimedata readtimedata = new readtimedata.Readtimedata();
            //MWArray result = readtimedata.readtimedata(strFileName);



            strFileName8 = ofd.FileName;
            
            MessageBox.Show("您当前选择数据为" + strFileName8.ToString());

            FileStream file = new FileStream(strFileName8, FileMode.Open);
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
            switch (data_7[2])
            {
                case 0: voltage8 = 0.1; break;
                case 1: voltage8 = 0.2; break;
                case 2: voltage8 = 0.5; break;
                case 3: voltage8 = 1; break;
                case 4: voltage8 = 2; break;
                case 5: voltage8 = 5; break;
                case 6: voltage8 = 10; break;
                case 7: voltage8 = 20; break;

            }

            //显示文本信息

            string[] sArray = strFileName8.Split('\\');

            textBox_filename8.Text = sArray[5];
            textBox_Fs8.Text =  ((Fs8 / 1024) / 1024).ToString() + " M";
            textBox_size_n8.Text = ((size_n/1024)/1024).ToString()+" M";

             
            textBox_voltage8.Text = sArray[4]+" kV";



        }
        string strFileName8 = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt ";
        string strFileName0 = "D:\\开题\\shuju\\20120712_20m+\\0\\2012-07-12-12_25_56.txt  ";
        double voltage8=2 , Fs8 = 0;
        double voltage0=0.2 , Fs0 = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            long size_n = 2 * 1024 * 1024;
            


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            strFileName0 = "D:\\开题\\shuju\\20120712_20m+\\0\\2012-07-12-12_25_56.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
                // return;

            }
            else
            {

                strFileName0 = ofd.FileName;


            }
  

            MessageBox.Show("您当前选择数据为" + strFileName0.ToString());
            FileStream file = new FileStream(strFileName0, FileMode.Open);
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
            switch (data_7[2])
            {
                case 0: voltage0 = 0.1; break;
                case 1: voltage0 = 0.2; break;
                case 2: voltage0 = 0.5; break;
                case 3: voltage0 = 1; break;
                case 4: voltage0 = 2; break;
                case 5: voltage0 = 5; break;
                case 6: voltage0 = 10; break;
                case 7: voltage0 = 20; break;

            }


            //显示文本信息
            string[] sArray = strFileName0.Split('\\');

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
       

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("数据量较大，请耐心等待");

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "加压信号时域波形";
            myPane.XAxis.Title.Text = "时间(ms)";
            myPane.YAxis.Title.Text = "电流(mA)";
            myPane = zedGraphControl2.GraphPane;
            myPane.Title.Text = "加压信号频域波形";
            myPane.XAxis.Title.Text = "频率(kHZ)";
            myPane.YAxis.Title.Text = "幅值";

            get_time_data_byMatlab(strFileName8, zedGraphControl1);
            get_FFT_data_byMatlab(strFileName8, zedGraphControl2);


        }

       
        

       


        private void button5_Click(object sender, EventArgs e)
        {
            get_Shujuchuli_data_byMatlab(strFileName8, strFileName0, zedGraphControl4,zedGraphControl3, zedGraphControl2);
            zedGraphControl3.Visible = true;
            zedGraphControl4.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

           
        }

        private void get_time_data_byMatlab(string strfile, ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "加压信号时域波形";
            myPane.XAxis.Title.Text = "时间(ms)";
            myPane.YAxis.Title.Text = "电流(mA)";

            getTandFdataNative.getTandFdata getTandFdata = new getTandFdataNative.getTandFdata();
            object resultObj = getTandFdata.readtimedata(2, strfile);
            object[] resultObjs = (object[])resultObj;
            double[,] time_ms = (double[,])resultObjs[0];
            double[,] time_data = (double[,])resultObjs[1];



            zgc.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();

            for (int i = 0; i < 2 * 1024 * 1024 - 10; i++)
            {

                list1.Add(time_ms[0, i], time_data[i, 0]);

            }

            LineItem mCure = myPane.AddCurve("", list1, Color.Blue, SymbolType.None);
            zgc.AxisChange();

            zgc.Refresh();//重新刷新


        }

        double[,] Center_freq_for_AN;
        double[,] Yc_for_AN;

        private void button6_Click_1(object sender, EventArgs e)
        {
            //int[] intArr = new int[100];
            //ArrayList myList = new ArrayList();


            //Generate 100 different numbers
            //Random rnd = new Random();
            //while (myList.Count < 100)
            //{
            //    int num = rnd.Next(1, 101);
            //    if (!myList.Contains(num))
            //        myList.Add(num);
            //}

            //for (int i = 0; i < 100; i++)
            //    intArr[i] = (int)myList[i];

            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn("Number");
            //dt.Columns.Add(dc);
            //foreach (int s in intArr)
            //{
            //    dt.Rows.Add(s);
            //}

            //this.dataGridView1.DataSource = dt;
            //dataGridView1.Refresh();
            this.dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderCell.Value = "序号";
            dataGridView1.Columns[1].HeaderCell.Value = "中心频率";
            dataGridView1.Columns[2].HeaderCell.Value = "幅值";
            for (int i=0;i<31;i++)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = i;
                this.dataGridView1.Rows[index].Cells[1].Value = Center_freq_for_AN[0, i];
                this.dataGridView1.Rows[index].Cells[2].Value = Yc_for_AN[0, i];
            }
            
        }

        private void get_FFT_data_byMatlab(string strfile, ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "加压信号频域波形";
            myPane.XAxis.Title.Text = "频率(kHZ)";
            myPane.YAxis.Title.Text = "幅值";

            getTandFdataNative.getTandFdata getTandFdata = new getTandFdataNative.getTandFdata();
            object resultObj = getTandFdata.readpinyudata(2, strfile);
            object[] resultObjs = (object[])resultObj;
            double[,] Ff = (double[,])resultObjs[0];
            double[,] abs_Y8 = (double[,])resultObjs[1];



            zgc.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();

            for (int i = 0; Ff[0, i] < 20; i++)
            {

                list1.Add(Ff[0, i], abs_Y8[i, 0]);

            }

            LineItem mCure = myPane.AddCurve("", list1, Color.Blue, SymbolType.None);
            zgc.AxisChange();

            zgc.Refresh();//重新刷新


        }

        private void get_Shujuchuli_data_byMatlab(string strfile8, string strfile0, ZedGraphControl zgc,ZedGraphControl zgc0, ZedGraphControl zgc1)
        {
            GraphPane myPane = zgc0.GraphPane;
            GraphPane myPane1 = zgc1.GraphPane;
            GraphPane myPane_1_3 = zgc.GraphPane;
            myPane.Title.Text = "信号降噪后时域波形";
            myPane.XAxis.Title.Text = "时间(ms)";
            myPane.YAxis.Title.Text = "电流(mA)";
            
            myPane1.Title.Text = "信号降噪后频域波形";
            myPane1.XAxis.Title.Text = "频率(kHZ)";
            myPane1.YAxis.Title.Text = "幅值";

            myPane_1_3.Title.Text = "信号降噪后1/3倍频程对数功率谱";
            myPane_1_3.XAxis.Title.Text = "频率(kHZ)";
            myPane_1_3.YAxis.Title.Text = "幅值";

            getTandFdataNative.getTandFdata getTandFdata = new getTandFdataNative.getTandFdata();
            object resultObj = getTandFdata.ChuLiShuJu(6, strfile8, strfile0);
            object[] resultObjs = (object[])resultObj;

            double[,] time_ms = (double[,])resultObjs[0];
            double[,] time_data = (double[,])resultObjs[1];
            double[,] Ff = (double[,])resultObjs[2];
            double[,] abs_Y8 = (double[,])resultObjs[3];
            double[,] Center_freq = (double[,])resultObjs[4];
            double[,] Yc = (double[,])resultObjs[5];



            zgc0.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            zgc1.GraphPane.CurveList.Clear();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();

            for (int i = 0; Ff[0, i] < 20; i++)
            {
                list1.Add(Ff[0, i], abs_Y8[i, 0]);
            }
            for (int i = 0; i < 2 * 1024 * 1024 - 10; i++)
            {

                list2.Add(time_ms[0, i], time_data[i, 0]);

            }
            for (int i = 0; i < 31; i++)
            {

                list3.Add(Center_freq[0, i]/1000, Yc[0, i]);

            }
            Center_freq_for_AN = Center_freq;
            Yc_for_AN = Yc;

            LineItem mCure = myPane.AddCurve("", list2, Color.Blue, SymbolType.None);
            LineItem mCure1 = myPane1.AddCurve("", list1, Color.Blue, SymbolType.None);

            LineItem mCure_1_3=myPane_1_3.AddCurve("", list3, Color.Red, SymbolType.Circle);
            //mCure_1_3.Line.IsVisible = false;

            zgc0.AxisChange();
            zgc0.Refresh();//重新刷新
            zgc1.AxisChange();
            zgc1.Refresh();//重新刷新
            zgc.AxisChange();
            zgc.Refresh();//重新刷新


        }

    }
}
