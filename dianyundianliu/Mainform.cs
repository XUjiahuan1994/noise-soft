using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.OleDb;
using ZedGraph;
using System.IO.Ports;



namespace ps5000example
{


    public partial class Mainform : Form
    {

        public static Mainform form1 = null;
        public static string Portname="COM3";
        public static int BaudRate;

        public static int DataBits;
        public List<Device> devices = new List<Device>();
        public List<Coronameasure> Coronameasure = new List<Coronameasure>();
        public Coronameasure Measure;
        // public int init_flag=-1;
        public short init_flag = -1;
        public short handle;
        public short first_open;
        private readonly short _handle;
        public const int BUFFER_SIZE = 1024;
        public double nm_dy = 0;
        public const int MAX_CHANNELS = 4;
        public const int QUAD_SCOPE = 4;
        public const int DUAL_SCOPE = 2;
        public bool g_ready = false;
        public int timeIndisposed;
        public int flag = 0;
        public long sampleCount;
        public static int AutoSaveFlag = 0;
        public int count_caiji = 0;
        public static int flag_caiji = 0;
        public int Rangval;
        public int plotHandle = 0;
        public int time_next = 0;
        public int atimeInterval = 0;
        public long SampleVal = 0;
        public int timeInterval1;
        public int maxSamples;
        public short status = -1;
        public int TimeBase;
        public int Size;
        public int Amplitude;
        public int Couple;
        public byte FileParaFlag = 0;
        public int hFile0;
        public int VoltageLevel;
        public int shijian=60;
        public static string liangcheng, caiyanglv, cunchushengdu, ouhefangshi,wenjian;
        public double size1;
        private Imports.ps5000BlockReady callbackDelegate1;
        public int qq=0;














        uint _timebase = 8;
        short _oversample = 1;
        bool _scaleVoltages = true;

        ushort[] inputRanges = { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000 };
        bool _ready = false;
        int _sampleCount;
        uint _startIndex;
        bool _autoStop;
        //private ChannelSettings[] _channelSettings;
        private int _channelCount;
        private Imports.Range _firstRange;
        private Imports.Range _lastRange;
        private Imports.ps5000BlockReady _callbackDelegate;

        public byte[] buf1 = new byte[] { 0xaa, 0x00, 0x0d, 0x0a };//继电器全闭合===所有电源都关闭
        public byte[] buf2 = new byte[] { 0xaa, 0x0f, 0x0d, 0x0a };//6V电源控制--Picro 
        public byte[] buf3 = new byte[] { 0xaa, 0x01, 0x0d, 0x0a };//5V电源控制---USB 
        public byte[] buf4 = new byte[] { 0xaa, 0x08, 0x0d, 0x0a };//串口测试
        public byte[] buf5 = new byte[] { 0xaa, 0x09, 0x0d, 0x0a };//电池监测---正常“ok” ，非正常"low"
        public byte[] buf6 = new byte[] { 0xaa, 0x10, 0x0d, 0x0a };//温度检测
        public byte[] buf7 = new byte[] { 0xaa, 0x05, 0x0d, 0x0a };// 500欧姆
        public byte[] buf8 = new byte[] { 0xaa, 0x20, 0x0d, 0x0a };//短路模式 
        public byte[] buf9 = new byte[] { 0xaa, 0x21, 0x0d, 0x0a };//开路模式
        public System.Windows.Forms.Timer autocollectTimer;

        public static Mainform form = new Mainform();   //创建静态变量，便于与其他窗口传值
        public SerialPort serialPort;

        public class VerticalProgressBar : ProgressBar
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x04;
                    return cp;
                }
            }
        }
        public Mainform()
        {
            serialPort = new SerialPort();
            form = this;
            InitializeComponent();
            pictureBox1.Image = imageList1.Images[1];
            pictureBox2.Image = imageList1.Images[1];
            pictureBox3.Image = imageList1.Images[1];
            textBox1.Text = "60";
            //textBox2.Text = "0";
            //  timer1.Enabled=true;
            // timer1.Interval = 1000;
            // timer1.Start();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
            serialPort.PortName = Portname;
            if (!serialPort.IsOpen)
                serialPort.Open();

            serialPort.Write(buf3, 0, buf3.Length);
            Thread.Sleep(300);
            serialPort.Write(buf2, 0, buf2.Length);
            Thread.Sleep(100);
            read_canshu();
            pictureBox1.Image = imageList1.Images[0];
            serialPort.Close();
            }catch
            {
                MessageBox.Show("请检查串口连接情况");
            }
            


        }

        int read_canshu()
        {
            int value_v = 0;

            return 0;

        }

        int save_canshu()
        {


            return 0;
        }

        private void 启动设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            adddevice device = new adddevice();
            device.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            serialPort.PortName = Portname;

            if (!serialPort.IsOpen)
                serialPort.Open();

            if (init_flag != 0)
            { init_flag = Imports.OpenUnit(out handle); }


            switch (init_flag)
            {
                case 0:
                    pictureBox2.Image = imageList1.Images[0];
                    if (first_open == 0)
                    {
                        test_dianchi();

                    }
                    first_open = 1;
                    textBox5.Text = "设备空闲";
                    textBox5.Update();
                    qq = 0;
                    break;
                // case 1:
                default:
                    textBox5.Text = "设备未发现";
                    textBox5.Update();
                    Message3 message3 = new Message3();
                    message3.Show();
                    //qq = 1;
                    break;

            }

            serialPort.Close();

        }

      public  int acq_status(int value)
        {
            switch (value)
            {
                case 1:
                    textBox5.Text = "数据正在采集中，请不要点击其他按钮";
                    break;
                case 2:
                    textBox5.Text = "数据采集完毕，可以进行下一步操作";
                    break;
                case 3:
                    textBox5.Text = "数据大于8M，仅显示前8MB数据";
                    break;
                default:
                    textBox5.Text = "设备空闲中";
                    break;

            }
            return 0;
        }
        void BlockCallback(short handle, short status, IntPtr pVoid)
        {
            // flag to say done reading data
            g_ready = true;
        }

        public int test_dianchi()
        {
            double sum = 0;
            uint SampleVal = 127;
            // char* buf;
            //short* buffer3;
            // char* buffer4;

           // IntPtr.Zero = 0;
            ushort segIndex;
            double value;

            long noOfPrev = 0;
            long size1;
            char[] current = new char[30];
            //int timeInterval;
            int i;
            //int maxsamples;

            long sampleCount = BUFFER_SIZE;
            PinnedArray<short>[] minPinned = new PinnedArray<short>[_channelCount];
            PinnedArray<short>[] maxPinned = new PinnedArray<short>[_channelCount];
            //  if (init_flag != 0)
            // {
            //dianchi_warning warning = new dianchi_warning();
            // warning.Show();\
            g_ready = false;
            //  }
            int a=Imports.SetChannel(handle, Imports.Channel.ChannelA + 1, 1, 1, Imports.Range.Range_20V);
            int b=Imports.SetChannel(handle, Imports.Channel.ChannelA, 0, 1, Imports.Range.Range_20V);
            int bb=Imports.GetTimebase(handle, SampleVal, 1024, out timeInterval1, 1, out maxSamples, 0);
            callbackDelegate1 = BlockCallback;
            int c= Imports.RunBlock(handle, 0, 1024, SampleVal, 1, out timeIndisposed, 0, callbackDelegate1, IntPtr.Zero);
            //callbackDelegate1(handle, status, IntPtr.Zero);


            while (!g_ready)
            {
                Thread.Sleep(100);
                //callbackDelegate1=BlockCallback;
                //callbackDelegate1(handle, status, IntPtr.Zero);
            }

            short[] buffer3 = new short[1024];
            long[] buffer5 = new long[1024];
            string[] buffer6 = new string[1024];
            byte[] buffer4 = new byte[1024];
            // minPinned[1] = new PinnedArray<short>(minBuffers);
            // maxPinned[1] = new PinnedArray<short>(maxBuffers);
            int aa= Imports.SetDataBuffer(handle, (Imports.Channel)1, buffer5, 1024);





            

            //status = Imports.RunBlock(handle, 0, 1024, SampleVal, 1, out timeIndisposed, 0, _callbackDelegate, IntPtr.Zero);
            flag = 1;

            acq_status(flag);

            // while (!g_ready)
            // {
            //     Thread.Sleep(100);
            // }
            Imports.Stop(handle);
            //if (g_ready)
            //{
            short overflow;
               int d = Imports.GetValues(handle, 0, ref sampleCount, 1, Imports.DownSamplingMode.None, 0, out overflow);
            //  }
            Thread.Sleep(100);


           // buffer3 = Convert.ToInt16(buffer5);

            for (i = 0; i < 1024; i++)
            {
               // buffer6[i] = Convert.ToString(buffer5[i]);
               // buffer3[i] = Convert.ToString(buffer6[i]);
                buffer4[i] = (byte)(buffer5[i] >> 56);
                sum = sum + (float)(buffer4[i]) / 127.0 * 20;

            }
            short[] buf = new short[20];
            nm_dy = sum*4 / 1024;
            textBox4.Text = Convert.ToString(nm_dy);
            VerticalprogressBar.Value = Convert.ToInt16(nm_dy);


            return 0;
        }

        double getRange(long index)
        {
            double value;
            //(Va / 127.0 * 量程(0.1,0.2,0.5-20)) / R(100) * 1000 = Ia(mA)
            //	  value = 量程 / 127.0 /100 * 1000 = 10*量程/127.0
            switch (index)
            {
                case 0: //value = 0.1;
                    value = 1.0;
                    break;
                case 1: //value = 0.2;
                    value = 2.0;
                    break;
                case 2: //value = 0.5;
                    value = 5.0;
                    break;
                case 3: //value = 1.0;
                    value = 10.0;
                    break;
                case 4: //value = 2.0;
                    value = 20.0;
                    break;
                case 5: //value = 5.0;
                    value = 50.0;
                    break;
                case 6: //value = 10.0;
                    value = 100.0;
                    break;
                case 7: //value = 20.0;
                    value = 200.0;
                    break;
                default: //value=0.1;
                    value = 1.0;
                    break;
            }

            return value;
        }

      public long test_caiji(long sampleCount1, long SampleVal1)
        {
           // ushort segindex;
            double value;
           // long noOfPrev = 0;
            long i, size1;
            char[] current_C = new char[30];
            double sum = 0,sum2=0,root=0;
            //int timeInterval;
            string time, size, amplitude, couple, voltagelevel;
            int sleep = 0;
            int qq = 0;

          //  int maxsamples;
            short status;
            //sampleCount = BUFFER_SIZE;

            if (init_flag != 0)
            {
                dianchi_warning warning = new dianchi_warning();
                warning.Show();
            }
            serialPort.PortName = Portname;
            if (!serialPort.IsOpen)
                serialPort.Open();

            serialPort.Write(buf5, 0, buf5.Length);
            serialPort.Close();

            size1 = sampleCount1/4;
            SampleVal = SampleVal1;

            long[] buffer1 = new long[sampleCount1];
            flag = 1;
            acq_status(flag);
            Imports.GetTimebase(handle, SampleVal, sampleCount1, out timeInterval1, 1, out maxSamples, 0);
           
           // Imports.GetTimebase(handle, (uint)SampleVal, 1024, out timeInterval1, 1, out maxSamples, 0);
            g_ready = false;
            status = -1;
            callbackDelegate1 = BlockCallback;
            status = Imports.RunBlock(handle, 0, sampleCount1, SampleVal, 1, out timeIndisposed, 0, callbackDelegate1, IntPtr.Zero);


            while (!g_ready)
            {
                Thread.Sleep(100);
                sleep++;
                if(sleep==200)
                {
                    sleep = 0;
                    g_ready = true;
                  textBox5.Text = "设备丢失";
                    textBox5.Update();
                    Message3 message3 = new Message3();
                    message3.Show();
                    qq = 1;
                }

            }

            sleep = 0;

                Imports.SetDataBuffer(handle, (Imports.Channel)0, buffer1, sampleCount1);
                // Thread.Sleep(3000);
                // if (status != 0)
                // {
                //    Imports.Stop(_handle);
                //     return 1;
                //  }

                // while (!g_ready)
                // {
                //      Thread.Sleep(100);
                //   }
                Imports.Stop(handle);
                //   if (g_ready)
                //  {
                short overflow;
                sampleCount = sampleCount1;

                status = Imports.GetValues(handle, 0, ref sampleCount, 1, Imports.DownSamplingMode.None, 0, out overflow);
            //  }
           // Thread.Sleep(100);
            if (qq == 0)
            { 
               //Thread.Sleep(100);
                long[] buffer2 = new long[sampleCount1];
                double[] bufferTransfer = new double[sampleCount1];
                double[] bufferTransfer2 = new double[sampleCount1];

                switch (comboBox1.Text)
                {
                    case "+/-1mA":
                       // liangcheng = "+/-1mA";
                        Rangval = 0;
                        break;
                    case "+/-2mA":
                       // liangcheng = "+/-2mA";
                        Rangval = 1;
                        break;
                    case "+/-5mA":
                       // liangcheng = "+/-5mA";
                        Rangval = 2;
                        break;
                    case "+/-10mA":
                       // liangcheng = "+/-10mA";
                        Rangval = 3;
                        break;
                    case "+/-20mA":
                      //  liangcheng = "+/-20mA";
                        Rangval = 4;
                        break;
                    case "+/-50mA":
                       // liangcheng = "+/-50mA";
                        Rangval = 5;
                        break;
                    case "+/-100mA":
                      //  liangcheng = "+/-100mA";
                        Rangval = 6;
                        break;
                    case "+/-200mA":
                      //  liangcheng = "+/-200mA";
                        Rangval = 7;
                        break;
                    default:
                        Rangval = 0;
                        break;
                }

               // liangcheng = comboBox1.Text;

                value = getRange(Rangval);

                for (i = 0; i < sampleCount; i++)
                {
                    buffer2[i] = buffer1[i] >> 56;
                    if (i < 8192 * 1024)
                    {
                        bufferTransfer[i] = (buffer2[i]) * value / 127.0;
                        bufferTransfer2[i] = Math.Pow((buffer2[i]) * value*4 / 127.0 , 2);
                        sum = sum + bufferTransfer[i];
                        sum2 = sum2 + bufferTransfer2[i];
                    }
                    else
                    {
                        sum2=sum2+ Math.Pow((buffer2[i]) * value*4 / 127.0, 2);
                        sum = sum + (buffer2[i]) * value / 127.0;

                    }
                }
                root = Math.Sqrt(sum2 / sampleCount);


                textBox6.Text = Convert.ToString(root);
                textBox9.Text = Convert.ToString(sum * 4 / sampleCount);



                if (size1 > 8192 * 1024)
                {
                    flag = 3;
                    acq_status(flag);
                    size1 = 8192 * 1024;
                }

                textBox5.Text = "图像绘制中，请勿操作";
                textBox5.Update();
                this.ZedGraphControl1.GraphPane.CurveList.Clear();
                //this.ZedGraphControl1.GraphPane.GraphItemList.Clear();
                Random ran = new Random();
                PointPairList list = new PointPairList();
                LineItem myCurve;
                this.ZedGraphControl1.GraphPane.Title.Text = "电晕电流图";
                this.ZedGraphControl1.GraphPane.XAxis.Title.Text = "采样点";
                this.ZedGraphControl1.GraphPane.YAxis.Title.Text = "电流";
                double y;
                //long x;
                for (long k = 0; k < size1; k++)
                {
                     //x = k;
                    //double y;//double[] y = new double[sampleCount];
                    y = bufferTransfer[k];
                    list.Add(k, y);
                }
                
                myCurve = ZedGraphControl1.GraphPane.AddCurve("电流曲线", list, Color.Red, SymbolType.None);
                myCurve.Line.Width = 0.01F;//线宽
                this.ZedGraphControl1.AxisChange();
                this.ZedGraphControl1.Refresh();

                textBox5.Text = "存储中，请勿操作";
                textBox5.Update();
                string fileNameOne = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
        + ".txt";
                string filePathOne = System.IO.Path.Combine(textBox7.Text, fileNameOne);
                //string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);
                //System.IO.File.Create(filePathOne).Close();
                //FileStream aFile = new FileStream(filePathOne, FileMode.CreateNew);
                //StreamWriter sw = new StreamWriter(aFile);

                using (StreamWriter sw = File.AppendText(filePathOne))
                {
                    //time = comboBox2.Text;
                    // time = System.Text.RegularExpressions.Regex.Replace(comboBox2.Text, @"[^0-9]+", "");
                    //size = comboBox3.Text;
                    //size = System.Text.RegularExpressions.Regex.Replace(comboBox3.Text, @"[^0-9]+", "");
                    //amplitude = comboBox1.Text;
                    //amplitude = System.Text.RegularExpressions.Regex.Replace(comboBox1.Text, @"[^0-9]+", "");
                    //couple = comboBox4.Text;

                    couple = "0";

                    if (comboBox4.Text == "直流耦合")
                    {
                        couple = "0";
                    }
                    if (comboBox4.Text == "交流耦合")
                    {
                        couple = "1";
                    }
                    // couple = System.Text.RegularExpressions.Regex.Replace(comboBox4.Text, @"[^0-9]+", "");
                    //voltagelevel = textBox6.Text;
                    voltagelevel = System.Text.RegularExpressions.Regex.Replace(textBox6.Text, @"[^0-9]+", "");

                    switch (comboBox2.Text)
                    {
                        case "1K/S": time = "0"; break;
                        case "2K/S": time = "1"; break;
                        case "4K/S": time = "2"; break;
                        case "8K/S": time = "3"; break;
                        case "16K/S": time = "4"; break;
                        case "32K/S": time = "5"; break;
                        case "64K/S": time = "6"; break;
                        case "128K/S": time = "7"; break;
                        case "256K/S": time = "8"; break;
                        case "512K/S": time = "9"; break;
                        case "1M/S": time = "10"; break;
                        case "2M/S": time = "11"; break;
                        case "2.5M/S": time = "12"; break;
                        case "4M/S": time = "13"; break;
                        case "5M/S": time = "14"; break;
                        case "8.3M/S": time = "15"; break;
                        case "12.5M/S": time = "16"; break;
                        case "25M/S": time = "17"; break;
                        case "62.5M/S": time = "18"; break;
                        case "125M/S": time = "19"; break;
                        case "250M/S": time = "20"; break;
                        case "500M/S": time = "21"; break;
                        case "1G/S": time = "22"; break;
                        default: time = ""; break;

                    }

                    switch (comboBox3.Text)
                    {
                        case "1KB": size = "0"; break;
                        case "2KB": size = "1"; break;
                        case "4KB": size = "2"; break;
                        case "8KB": size = "3"; break;
                        case "16KB": size = "4"; break;
                        case "32KB": size = "5"; break;
                        case "64KB": size = "6"; break;
                        case "128KB": size = "7"; break;
                        case "256KB": size = "8"; break;
                        case "512KB": size = "9"; break;
                        case "1MB": size = "10"; break;
                        case "2MB": size = "11"; break;
                        case "4MB": size = "12"; break;
                        case "8MB": size = "13"; break;
                        case "16MB": size = "14"; break;
                        case "32MB": size = "15"; break;
                        case "64MB": size = "16"; break;
                        case "128MB": size = "17"; break;
                        default: size = ""; break;
                    }

                    switch (comboBox1.Text)
                    {
                        case "+/-1mA": amplitude = "0"; break;
                        case "+/-2mA": amplitude = "1"; break;
                        case "+/-5mA": amplitude = "2"; break;
                        case "+/-10mA": amplitude = "3"; break;
                        case "+/-20mA": amplitude = "4"; break;
                        case "+/-50mA": amplitude = "5"; break;
                        case "+/-100mA": amplitude = "6"; break;
                        case "+/-200mA": amplitude = "7"; break;
                        default: amplitude = ""; break;
                    }

                    sw.Write(" " + time + " ");
                    sw.Write(" " + size + " ");

                    sw.Write(" " + amplitude + " ");
                    sw.Write(" " + couple + " ");
                    sw.Write(" " + voltagelevel + " ");
                    for (i = 0; i < sampleCount; i++)
                    {

                        //sw.Write("\n");

                        sw.Write(" " + buffer2[i] + " ");

                    }
                    sw.Close();
                }

                if (qq == 0)
                {
                    textBox5.Text = "存储完毕,可进行下一步操作";
                    textBox5.Update();


                    flag = 2;
                    acq_status(flag);
                }
                count_caiji = 0;
            }
            qq = 0;

            return 0;
        }

        long count_buf(long index)
        {
            long total;
            total = Convert.ToInt64(Math.Pow(2, index+2) * 1024);
            return total;
        }

        // int save_canshu()
        // {
        //  int value_v = 0;
        //   int len;
        //   if（strcmp()
        //}

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        public void button5_Click(object sender, EventArgs e)
        {
            //int Rangval;

            textBox5.Text = "正在采集中,请勿操作";
            textBox5.Update();
            AutoSaveFlag = 1;

            timer1.Enabled = false;
            timer1.Stop();


         //   if (count_caiji == 0)
          //  {
          switch(comboBox1.Text)
            {
                case "+/-1mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_100MV);
                    break;
                case "+/-2mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_200MV);
                    break;
                case "+/-5mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_500MV);
                    break;
                case "+/-10mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_1V);
                    break;
                case "+/-20mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_2V);
                    break;
                case "+/-50mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_5V);
                    break;
                case "+/-100mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_10V);
                    break;
                case "+/-200mA":
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_20V);
                    break;
                default:
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, 1, Imports.Range.Range_20V);
                    break;
            }

                //liangcheng = comboBox1.Text;

                Imports.SetChannel(handle, Imports.Channel.ChannelB, 0, 1, Imports.Range.Range_100MV);

                switch (comboBox3.Text)
                {
                    case "1KB":
                        sampleCount = count_buf(0);
                        break;
                    case "2KB":
                        sampleCount = count_buf(1);
                        break;
                    case "4KB":
                        sampleCount = count_buf(2);
                        break;
                    case "8KB":
                        sampleCount = count_buf(3);
                        break;
                    case "16KB":
                        sampleCount = count_buf(4);
                        break;
                    case "32KB":
                        sampleCount = count_buf(5);
                        break;
                    case "64KB":
                        sampleCount = count_buf(6);
                        break;
                    case "128KB":
                        sampleCount = count_buf(7);
                        break;
                    case "256KB":
                        sampleCount = count_buf(8);
                        break;
                    case "512KB":
                        sampleCount = count_buf(9);
                        break;
                    case "1MB":
                        sampleCount = count_buf(10);
                        break;
                    case "2MB":
                        sampleCount = count_buf(11);
                        break;
                    case "4MB":
                        sampleCount = count_buf(12);
                        break;
                    case "8MB":
                        sampleCount = count_buf(13);
                        break;
                    case "16MB":
                        sampleCount = count_buf(14);
                        break;
                    case "32MB":
                        sampleCount = count_buf(15);
                        break;
                    case "64MB":
                        sampleCount = count_buf(16);
                        break;
                    case "128MB":
                        sampleCount = count_buf(17);
                        break;
                }
                //BUFFER_SIZE = sampleCount;
                //cunchushengdu = comboBox3.Text;

                switch (comboBox2.Text)
                {

                    case "1K/S":
                       // caiyanglv = "1K/S";
                        SampleVal = 125002;
                        break;
                    case "2K/S":
                       // caiyanglv = "2K/S";
                        SampleVal = 62502;
                        break;
                    case "4K/S":
                      //  caiyanglv = "4K/S";
                        SampleVal = 31252;
                        break;
                    case "8K/S":
                       // caiyanglv = "8K/S";
                        SampleVal = 15627;
                        break;
                    case "16K/S":
                      //  caiyanglv = "16K/S";
                        SampleVal = 7815;
                        break;
                    case "32K/S":
                       // caiyanglv = "32K/S";
                        SampleVal = 3908;
                        break;
                    case "64K/S":
                       // caiyanglv = "64K/S";
                        SampleVal = 1955;
                        break;
                    case "128K/S":
                       // caiyanglv = "128K/S";
                        SampleVal = 978;
                        break;
                    case "256K/S":
                       // caiyanglv = "256K/S";
                        SampleVal = 490;
                        break;
                    case "512K/S":
                       // caiyanglv = "512K/S";
                        SampleVal = 246;
                        break;
                    case "1M/S":
                      //  caiyanglv = "1M/S";
                        SampleVal = 127;
                        break;
                    case "2M/S":
                       // caiyanglv = "2M/S";
                        SampleVal = 64;
                        break;
                    case "2.5M/S":
                      //  caiyanglv = "2.5M/S";
                        SampleVal = 52;
                        break;
                    case "4M/S":
                        //caiyanglv = "4M/S";
                        SampleVal = 33;
                        break;
                    case "5M/S":
                       // caiyanglv = "5M/S";
                        SampleVal = 27;
                        break;
                    case "8.3M/S":
                       // caiyanglv = "8.3M/S";
                        SampleVal = 17;
                        break;
                    case "12.5M/S":
                      //  caiyanglv = "12.5M/S";
                        SampleVal = 12;
                        break;
                    case "25M/S":
                       // caiyanglv = "25M/S";
                        SampleVal = 7;
                        break;
                    case "62.5M/S":
                       // caiyanglv = "62.5M/S";
                        SampleVal = 4;
                        break;
                    case "125M/S":
                       // caiyanglv = "125M/S";
                        SampleVal = 3;
                        break;
                    case "250M/S":
                       // caiyanglv = "250M/S";
                        SampleVal = 2;
                        break;
                    case "500M/S":
                       // caiyanglv = "500M/S";
                        SampleVal = 1;
                        break;
                    case "1G/S":
                       // caiyanglv = "1G/S";
                        SampleVal = 0;
                        break;
                }

                //caiyanglv = comboBox2.Text;
            if (sampleCount >= 134217728)
            {
                sampleCount = 134210000;
            }
                switch (init_flag)
                {
                    case 0:
                        count_caiji = 1;
                        flag_caiji = 0;
                        test_caiji(sampleCount, SampleVal);
                        break;
                    case 1:
                        Message1 message1 = new Message1();
                        message1.Show();
                        break;
                    case 3:
                        Message3 message3 = new Message3();
                        message3.Show();
                        break;
                    case 4:
                        Message4 message4 = new Message4();
                        message4.Show();
                        break;
                    case 5:
                        Message5 message5 = new Message5();
                        message5.Show();
                        break;
                    case 9:
                        Message9 message9 = new Message9();
                        message9.Show();
                        break;
                    case 10:
                        Message10 message10 = new Message10();
                        message10.Show();
                        break;
                    case 11:
                        Message11 message11 = new Message11();
                        message11.Show();
                        break;

                }

           // }

        }

        public void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox7.Text = this.folderBrowserDialog1.SelectedPath;
                   wenjian = this.folderBrowserDialog1.SelectedPath;

            //wenjian = textBox7.Text;
            string activeDir = this.folderBrowserDialog1.SelectedPath;
            string newPath = System.IO.Path.Combine(activeDir, "");
            System.IO.Directory.CreateDirectory(newPath);
            //创建一个空白文件
           // string fileNameOne = DateTime.Now.ToString("yyyyMMddHHmm")
             //   + ".txt";
           // string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);
            //string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);
          //  System.IO.File.Create(filePathOne);
        }

 

         private void button7_Click(object sender, EventArgs e)
        {
            flag = 0;
            acq_status(flag);
            timer1.Stop();
            timer1.Enabled = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort.PortName = Portname;
            try
            {
             if (!serialPort.IsOpen)
                serialPort.Open();
            //serialPort.PortName = Portname;
            serialPort.Write(buf1, 0, buf1.Length);
            Thread.Sleep(1000);
            serialPort.Write(buf1, 0, buf1.Length);
            Thread.Sleep(1000);
            serialPort.Write(buf8, 0, buf8.Length);
            Thread.Sleep(1000);
            serialPort.Write(buf8, 0, buf8.Length);
            pictureBox1.Image = imageList1.Images[1];
            serialPort.Close();
            }
            catch
            {
                MessageBox.Show("请检查串口连接情况");
                
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //serialPort.PortName = Portname;
            serialPort.PortName = Portname;
            if (!serialPort.IsOpen)
                serialPort.Open();
            if (init_flag != 0)
            {

                dianchi_warning warning = new dianchi_warning();

                warning.Show();
            }
            flag = 0;
            acq_status(flag);
            Imports.CloseUnit(handle);
            init_flag = -1;
            pictureBox2.Image = imageList1.Images[1];

            serialPort.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort.PortName = Portname;
            if (!serialPort.IsOpen)
                serialPort.Open();
            serialPort.Write(buf6, 0, buf6.Length);
            Thread.Sleep(300);
            serialPort.Write(buf6, 0, buf6.Length);
            Thread.Sleep(300);
            byte[] buf = new byte[8];
            int n;
            n = serialPort.Read(buf, 0, 8);
            textBox3.Text = Convert.ToString(buf);
            serialPort.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            test_dianchi();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[10];
            long index1, size1;
            double rate, totalTime;
            double value;
            double y;
            long x;

            byte MemDepIndex;
            int arrayIndex = 0;
            int i, j;
            byte[] path1 = new byte[500];
            double gain, sum = 0, average, cur, root,sum2=0;
            byte tmp;
            byte[] target = new byte[30];
            byte[] current = new byte[30];
            int rangIndex;
            string time, size, amplitude, couple, res1;
            long dispMemDepIndex = 0, TimeBaseIndex, SizeIndex, AmplitudeIndex, CoupleIndex, resIndex;
            string IndexString;
            long sampleCount1;
            string Read;
            double timeInterval;

            // MemDepIndex = Convert.ToByte(textBox1.Text);
            switch (comboBox3.Text)
            {

                case "1KB":
                    sampleCount1 = count_buf(0);
                    break;
                case "2KB":
                    sampleCount1 = count_buf(1);
                    break;
                case "4KB":
                    sampleCount1 = count_buf(2);
                    break;
                case "8KB":
                    sampleCount1 = count_buf(3);
                    break;
                case "16KB":
                    sampleCount1 = count_buf(4);
                    break;
                case "32KB":
                    sampleCount1 = count_buf(5);
                    break;
                case "64KB":
                    sampleCount1 = count_buf(6);
                    break;
                case "128KB":
                    sampleCount1 = count_buf(7);
                    break;
                case "256KB":
                    sampleCount1 = count_buf(8);
                    break;
                case "512KB":
                    sampleCount1 = count_buf(9);
                    break;
                case "1MB":
                    sampleCount1 = count_buf(10);
                    break;
                case "2MB":
                    sampleCount1 = count_buf(11);
                    break;
                case "4MB":
                    sampleCount1 = count_buf(12);
                    break;
                case "8MB":
                    sampleCount1 = count_buf(13);
                    break;
                case "16MB":
                    sampleCount1 = count_buf(14);
                    break;
                case "32MB":
                    sampleCount1 = count_buf(15);
                    break;
                case "64MB":
                    sampleCount1 = count_buf(16);
                    break;
                case "128MB":
                    sampleCount1 = count_buf(17);
                    break;
            }
            //BUFFER_SIZE = count_buf(MemDepIndex);
            System.Windows.Forms.OpenFileDialog folder = new System.Windows.Forms.OpenFileDialog();
            //byte[] byData = new byte[100];
            long readBufSize = 0;
            //long x;
            // double y;
            string text1;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                Read = folder.FileName;
                try
                {
                    // FileStream file = new FileStream(Read, FileMode.Open);
                    // file.Seek(0, SeekOrigin.Begin);
                    // file.Read(byData, 0, 5); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                    // Decoder d = Encoding.Default.GetDecoder();

                    string text = System.IO.File.ReadAllText(Read);
                    int count = text.Count();
                    if (count < 8192 * 1024)
                    { text1 = text.Substring(0, count); }
                    else
                    {
                        text1 = text.Substring(0, 8192 * 1024);
                    }
                    string[] nums = text1.Split(' ');
                    //Thread.Sleep(200);
                    nums = nums.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    nums = nums.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                    long[] byData = new long[nums.Length];
                    for (i = 0; i < nums.Length; i++)
                    {
                        byData[i] = Convert.ToInt64(nums[i]);
                    }

                    dispMemDepIndex = byData[1];
                    TimeBaseIndex = byData[0];
                    SizeIndex = byData[1];
                    AmplitudeIndex = byData[2];
                    CoupleIndex = byData[3];
                    resIndex = byData[4];   //新传感器	buffer[4]表示电阻大小
                    timeInterval = sampleInterval(byData[0]);

                    time = getTime(TimeBaseIndex);
                    size = getSize(SizeIndex);
                    amplitude = getAmplitude(AmplitudeIndex);
                    couple = getCouple(CoupleIndex);
                    res1 = getRes(resIndex);

                    IndexString = string.Format("当前文件指标索引：时基：{0},大小：{1},幅值：{2},耦合方式：{3},电阻档：{4}", time, size, amplitude, couple, res1);
                    textBox8.Text = IndexString;
                    if (dispMemDepIndex <= 4)
                    { readBufSize = Convert.ToInt64(Math.Pow(2, dispMemDepIndex - 1) * 1024); }
                    else
                    {
                        readBufSize = Convert.ToInt64(Math.Pow(2, 3) * 1024);
                    }
                    //byte[] buffer = new byte[readBufSize];
                    // file.Read(buffer, 0, (int)readBufSize);
                    value = getRange(AmplitudeIndex);
                    double[] bufferTransfer = new double[readBufSize];
                    double[] bufferTransfer2 = new double[readBufSize];
                    for (i = 5; i < readBufSize; i++)
                    {
                        bufferTransfer[i] = (double)((byData[i]) / 127.0 * value);
                        bufferTransfer2[i] = Math.Pow(bufferTransfer[i], 2);
                        sum += bufferTransfer[i];
                        sum2 += bufferTransfer2[i];
                    }

                    average = sum / readBufSize;

                    root = Math.Sqrt(sum2 / readBufSize);

                    textBox6.Text = Convert.ToString(root);

                    textBox9.Text = Convert.ToString(average);

                    if (dispMemDepIndex <= 4)
                    { size1 = Convert.ToInt64(Math.Pow(2, dispMemDepIndex - 1) * 1024); }
                    else
                    {
                        size1 = Convert.ToInt64(Math.Pow(2, 3) * 1024);
                    }
                    if (size1 > 100000000)
                    {
                        //MessagePopup("警告", "文件太大，仅显示8MB数据");
                        chaoguo8M chaoguo = new chaoguo8M();
                        chaoguo.Show();
                        size1 = 8192 * 1024;
                        //return 0;
                    }
                    this.ZedGraphControl1.GraphPane.CurveList.Clear();
                    this.ZedGraphControl1.GraphPane.GraphObjList.Clear();
                    Random ran = new Random();
                    PointPairList list = new PointPairList();
                    LineItem myCurve;
                    this.ZedGraphControl1.GraphPane.Title.Text = "电晕电流图";
                    this.ZedGraphControl1.GraphPane.XAxis.Title.Text = "采样点";
                    this.ZedGraphControl1.GraphPane.YAxis.Title.Text = "电流";
                    //System.Threading.Thread.Sleep(200);

                    for (long k = 0; k < size1; k++)
                    {
                        x = k;
                        y = bufferTransfer[k];
                        list.Add(x, y);
                    }

                    myCurve = ZedGraphControl1.GraphPane.AddCurve("My Curve", list, Color.DarkGreen, SymbolType.None);
                    this.ZedGraphControl1.AxisChange();
                    this.ZedGraphControl1.Refresh();
                    //Read.Close();
                }
                catch (IOException)
                {
                    // Console.WriteLine(e.ToString());
                }
                //readBufSize = Convert.ToInt64(Math.Pow(2, dispMemDepIndex) * 1024);


            }


        }
        static string getTime(long value)
        {
            string buf;
            switch (value)
            {
                case 0: buf = "1K/S"; break;
                case 1: buf = "2K/S"; break;
                case 2: buf = "4K/S"; break;
                case 3: buf = "8K/S"; break;
                case 4: buf = "16K/S"; break;
                case 5: buf = "32K/S"; break;
                case 6: buf = "64K/S"; break;
                case 7: buf = "128K/S"; break;
                case 8: buf = "256K/S"; break;
                case 9: buf = "512K/S"; break;
                case 10: buf = "1M/S"; break;
                case 11: buf = "2M/S"; break;
                case 12: buf = "2.5M/S"; break;
                case 13: buf = "4M/S"; break;
                case 14: buf = "5M/S"; break;
                case 15: buf = "8.3M/S"; break;
                case 16: buf = "12.5M/S"; break;
                case 17: buf = "25M/S"; break;
                case 18: buf = "62.5M/S"; break;
                case 19: buf = "125M/S"; break;
                case 20: buf = "250M/S"; break;
                case 21: buf = "500M/S"; break;
                case 22: buf = "1G/S"; break;
                default: buf = ""; break;

            }
            return buf;
        }
        //文件大小显示函数
        static string getSize(long SizeIndex)
        {
            string buf;
            switch (SizeIndex)
            {
                case 0: buf = "1KB"; break;
                case 1: buf = "2KB"; break;
                case 2: buf = "4KB"; break;
                case 3: buf = "8KB"; break;
                case 4: buf = "16KB"; break;
                case 5: buf = "32KB"; break;
                case 6: buf = "64KB"; break;
                case 7: buf = "128KB"; break;
                case 8: buf = "256KB"; break;
                case 9: buf = "512KB"; break;
                case 10: buf = "1MB"; break;
                case 11: buf = "2MB"; break;
                case 12: buf = "4MB"; break;
                case 13: buf = "8MB"; break;
                case 14: buf = "16MB"; break;
                case 15: buf = "32MB"; break;
                case 16: buf = "64MB"; break;
                case 17: buf = "128MB"; break;
                default: buf = ""; break;

            }
            return buf;
        }
        //量程显示函数
        static string getAmplitude(long AmplitudeIndex)
        {
            string buf;
            switch (AmplitudeIndex)
            {
                case 0: buf = "+/-1mA"; break;
                case 1: buf = "+/-2mA"; break;
                case 2: buf = "+/-5mA"; break;
                case 3: buf = "+/-10mA"; break;
                case 4: buf = "+/-20mA"; break;
                case 5: buf = "+/-50mA"; break;
                case 6: buf = "+/-100mA"; break;
                case 7: buf = "+/-200mA"; break;
                default: buf = ""; break;
            }
            return buf;

        }
        //耦合显示函数
        static string getCouple(long coupleIndex)
        {
            string buf;
            switch (coupleIndex)
            {
                case 1: buf = "交流耦合"; break;
                case 0: buf = "直流耦合"; break;
                default: buf = ""; break;
            }
            return buf;
        }

        static string getRes(long resIndex)
        {
            string buf;
            // buf = (char*)malloc(20);
            switch (resIndex)
            {
                case 0: buf = "100欧姆"; break;   //新配置程序
                case 1: buf = "10欧姆"; break;
                case 2: buf = "50欧姆"; break;
                case 3: buf = "100欧姆"; break;
                case 4: buf = "500欧姆"; break;
                default: buf = "100欧姆"; break;  //新配置程序 
            }
            return buf;
        }
        static double sampleInterval(long timeBaseIndex)
        {
            int timeBase;
            double time = 0, time1, time2, time3;

            switch (timeBaseIndex)
            {
                case 0:
                    timeBase = 125002;
                    break;
                case 1:
                    timeBase = 62502;
                    break;
                case 2:
                    timeBase = 31252;
                    break;
                case 3:
                    timeBase = 15627;
                    break;
                case 4:
                    timeBase = 7815;
                    break;
                case 5:
                    timeBase = 3908;
                    break;
                case 6:
                    timeBase = 1955;
                    break;
                case 7:
                    timeBase = 978;
                    break;
                case 8:
                    timeBase = 490;
                    break;
                case 9:
                    timeBase = 246;
                    break;
                case 10:
                    timeBase = 127;
                    break;
                case 11:
                    timeBase = 64;
                    break;
                case 12:
                    timeBase = 52;
                    break;
                case 13:
                    timeBase = 33;
                    break;
                case 14:
                    timeBase = 27;
                    break;
                case 15:
                    timeBase = 17;
                    break;
                case 16:
                    timeBase = 12;
                    break;
                case 17:
                    timeBase = 7;
                    break;
                case 18:
                    timeBase = 4;
                    break;
                case 19:
                    timeBase = 3;
                    break;
                case 20:
                    timeBase = 2;
                    break;
                case 21:
                    timeBase = 1;
                    break;
                case 22:
                    timeBase = 0;
                    break;
                default:
                    timeBase = 0;
                    break;
            }

            if ((timeBase >= 0) && (timeBase <= 2))
            {
                time = Math.Pow(2, timeBase);   //单位ns               
            }
            if (timeBase >= 3)
            {
                time = (timeBase - 2) * 8;   //单位ns        		                                           
                if ((time1 = time / 1000.0) < 1)
                {

                }
                else if ((time2 = time1 / 1000.0) < 1)
                {

                    time = time1;
                }
                else if ((time3 = time2 / 1000.0) < 1)
                {

                    time = time2;
                }
                else
                {

                    time = time3;
                }

            }

            return time;  // 时间长度和时间单位都已得出
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            serialPort.PortName = Portname;
        
            if (!serialPort.IsOpen)
                serialPort.Open();//serialPort.PortName = "COM3";
            serialPort.Write(buf1, 0, buf1.Length);
            Thread.Sleep(100);
            serialPort.Write(buf8, 0, buf8.Length);
            Thread.Sleep(100);
            serialPort.Write(buf8, 0, buf8.Length);

            serialPort.Close();

            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // this.Hide();
            textBox5.Text = "正在采集中，请勿操作";
            textBox5.Update();
            int i;
            if (save_canshu() == 2)
            {
                Cuowu cuowu = new Cuowu();
                cuowu.Show();
            }

          // timer1.Enabled=true;
          //  timer1.Interval = 1000;
          //  timer1.Start();
           // shijian = 60;


            if (textBox1.Text == "0")
            {
                Shijian shijian = new Shijian();
                shijian.Show();
            }

         //   wenjian = textBox7.Text;
          //  liangcheng = comboBox1.Text;
           // caiyanglv = comboBox2.Text;
            //cunchushengdu = comboBox3.Text;
           // ouhefangshi = comboBox4.Text;

            switch (init_flag)
            {
                case 0:
                    //AutoPanel2 autopanel = new AutoPanel2();
                    //autopanel.Show();
                    autocollect();



                    if (comboBox5.Text=="瞬时值")
                    {
                        AutoSaveFlag = 0;
                        flag_caiji = 0;
                    }
                    else
                    {
                        AutoSaveFlag = 1;
                        flag_caiji = 0;
                    }

                    if (qq == 0)
                    {
                        textBox5.Text = "存储完毕，等待下次采集";
                        textBox5.Update();

                        timer1.Enabled = true;
                        timer1.Interval = 1000;
                        timer1.Start();
                        shijian = Convert.ToInt16(textBox1.Text);
                    }

                    qq = 0;

                    break;
                case 1:
                    Message1 message1 = new Message1();
                    message1.Show();
                    break;
                case 3:
                    Message3 message3 = new Message3();
                    message3.Show();
                    break;
                case 4:
                    Message4 message4 = new Message4();
                    message4.Show();
                    break;
                case 5:
                    Message5 message5 = new Message5();
                    message5.Show();
                    break;
                case 9:
                    Message9 message9 = new Message9();
                    message9.Show();
                    break;
                case 10:
                    Message10 message10 = new Message10();
                    message10.Show();
                    break;
                case 11:
                    Message11 message11 = new Message11();
                    message11.Show();
                    break;
            }


        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            textBox5.Text = "采集停止";
            textBox5.Update();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ZedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }



        string filePathOne = "1", fileNameOne;


        public void autocollect()
        {

            textBox5.Text = "采集中，请勿操作";
            textBox5.Update();
            //Thread.Sleep(100);
            long i, size1;
            double sum = 0,sum2=0,root=0;
            byte[] current_C = new byte[30];
            double value = 0;
            //byte buf = new byte();
            string time, size, amplitude, couple, voltagelevel;
            long sampleCount1 = 1024;
            int sleep = 0;
            int qq = 0;
            // Mainform a = new Mainform();
            // a.Update();
            //this.Update();
            // comboBox1.Text = comboBox1.Text;
            //autocollectTimer.Interval = 60000;
            timer1.Enabled = false;
            timer1.Stop();

            //textBox7.Text = wenjian;
            //comboBox1.Text = liangcheng;
           // comboBox2.Text = caiyanglv;
          //  comboBox3.Text = cunchushengdu;
           // comboBox4.Text = ouhefangshi;

            // if (pictureBox1.Image != imageList1.Images[0])
            // {
           // pictureBox1.Image = imageList1.Images[0];
            //   }

            //  if (pictureBox2.Image != imageList1.Images[0])
            // {
           // pictureBox2.Image = imageList1.Images[0];
            //  }
            //textBox4.Text = Convert.ToString(nm_dy);
            //VerticalprogressBar.Value = Convert.ToInt16(nm_dy);
            // shijian--;

            //   textBox2.Text = Convert.ToString(shijian);
            //textBox2.Text = "1";
            //System.Threading.Thread.Sleep(200);

            //  if (shijian == 0)
            // {
            //    shijian = 59;
            //
            //  }
            flag = 1;
            acq_status(flag);

            if (flag_caiji == 0)
            {
                serialPort.PortName = Portname;
                time_next = atimeInterval;
                //serialPort.Write(buf5, 0, buf5.Length);

                // test_dianchi();

                short coupIndex = 1;

                if (comboBox4.Text == "直流耦合")
                {
                    coupIndex = 1;
                }
                if (comboBox4.Text == "交流耦合")
                {
                    coupIndex = 0;
                }
                ouhefangshi = comboBox4.Text;

                if (comboBox1.Text == "+/-1mA")
                {

                    Rangval = 3;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_100MV);
                }
                if (comboBox1.Text == "+/-2mA")
                {
                    Rangval = 4;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_200MV);
                }
                if (comboBox1.Text == "+/-5mA")
                {
                    Rangval = 5;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_500MV);
                }
                if (comboBox1.Text == "+/-10mA")
                {
                    Rangval = 6;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_1V);
                }
                if (comboBox1.Text == "+/-20mA")
                {
                    Rangval = 7;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_2V);
                }
                if (comboBox1.Text == "+/-50mA")
                {
                    Rangval = 8;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_5V);
                }
                if (comboBox1.Text == "+/-100mA")
                {
                    Rangval = 9;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_10V);
                }
                if (comboBox1.Text == "+/-200mA")
                {
                    Rangval = 10;
                    Imports.SetChannel(handle, Imports.Channel.ChannelA, 1, coupIndex, Imports.Range.Range_20V);
                }
                //liangcheng = comboBox1.Text;

                Imports.SetChannel(handle, Imports.Channel.ChannelB, 0, 1, Imports.Range.Range_100MV);
                // System.Threading.Thread.Sleep(200);

                switch (comboBox3.Text)
                {

                    case "1KB":
                        sampleCount1 = count_buf(0);
                        break;
                    case "2KB":
                        sampleCount1 = count_buf(1);
                        break;
                    case "4KB":
                        sampleCount1 = count_buf(2);
                        break;
                    case "8KB":
                        sampleCount1 = count_buf(3);
                        break;
                    case "16KB":
                        sampleCount1 = count_buf(4);
                        break;
                    case "32KB":
                        sampleCount1 = count_buf(5);
                        break;
                    case "64KB":
                        sampleCount1 = count_buf(6);
                        break;
                    case "128KB":
                        sampleCount1 = count_buf(7);
                        break;
                    case "256KB":
                        sampleCount1 = count_buf(8);
                        break;
                    case "512KB":
                        sampleCount1 = count_buf(9);
                        break;
                    case "1MB":
                        sampleCount1 = count_buf(10);
                        break;
                    case "2MB":
                        sampleCount1 = count_buf(11);
                        break;
                    case "4MB":
                        sampleCount1 = count_buf(12);
                        break;
                    case "8MB":
                        sampleCount1 = count_buf(13);
                        break;
                    case "16MB":
                        sampleCount1 = count_buf(14);
                        break;
                    case "32MB":
                        sampleCount1 = count_buf(15);
                        break;
                    case "64MB":
                        sampleCount1 = count_buf(16);
                        break;
                    case "128MB":
                        sampleCount1 = count_buf(17);
                        break;
                }
               // cunchushengdu = comboBox3.Text;

                if (sampleCount1 >= 134217728)
                { sampleCount1 = 134210000; }

                size1 = sampleCount1 / 4;
                long[] buffer1 = new long[sampleCount1];

                // System.Threading.Thread.Sleep(200);
                switch (comboBox2.Text)
                {

                    case "1K/S":

                        SampleVal = 125002;
                        break;
                    case "2K/S":
                        SampleVal = 62502;
                        break;
                    case "4K/S":
                        SampleVal = 31252;
                        break;
                    case "8K/S":
                        SampleVal = 15627;
                        break;
                    case "16K/S":
                        SampleVal = 7815;
                        break;
                    case "32K/S":
                        SampleVal = 3908;
                        break;
                    case "64K/S":
                        SampleVal = 1955;
                        break;
                    case "128K/S":
                        SampleVal = 978;
                        break;
                    case "256K/S":
                        SampleVal = 490;
                        break;
                    case "512K/S":
                        SampleVal = 246;
                        break;
                    case "1M/S":
                        SampleVal = 127;
                        break;
                    case "2M/S":
                        SampleVal = 64;
                        break;
                    case "2.5M/S":
                        SampleVal = 52;
                        break;
                    case "4M/S":
                        SampleVal = 33;
                        break;
                    case "5M/S":
                        SampleVal = 27;
                        break;
                    case "8.3M/S":
                        SampleVal = 17;
                        break;
                    case "12.5M/S":
                        SampleVal = 12;
                        break;
                    case "25M/S":
                        SampleVal = 7;
                        break;
                    case "62.5M/S":
                        SampleVal = 4;
                        break;
                    case "125M/S":
                        SampleVal = 3;
                        break;
                    case "250M/S":
                        SampleVal = 2;
                        break;
                    case "500M/S":
                        SampleVal = 1;
                        break;
                    case "1G/S":
                        SampleVal = 0;
                        break;
                }
               // caiyanglv = comboBox2.Text;

                Imports.GetTimebase(handle, SampleVal, sampleCount1, out timeInterval1, 1, out maxSamples, 0);
                // System.Threading.Thread.Sleep(200);
                g_ready = false;
                status = -1;
                callbackDelegate1 = BlockCallback;

                status = Imports.RunBlock(handle, 0, sampleCount1, SampleVal, 1, out timeIndisposed, 0, callbackDelegate1, IntPtr.Zero);



                while (!g_ready)
                {
                    Thread.Sleep(100);
                    sleep++;
                    if (sleep == 200)
                    {
                        sleep = 0;
                        g_ready = true;
                        textBox5.Text = "设备丢失";
                        textBox5.Update();
                        Message3 message3 = new Message3();
                        message3.Show();
                        qq = 1;
                    }

                    //callbackDelegate1=BlockCallback;
                    //callbackDelegate1(handle, status, IntPtr.Zero);
                }

                sleep = 0;
                // if (status != 0)
                // {
                //    Imports.Stop(_handle);
                //     return 1;
                //  }



                    Imports.SetDataBuffer(handle, (Imports.Channel)0, buffer1, sampleCount1);

                    Imports.Stop(handle);
                    //   if (g_ready)
                    //  {
                    short overflow;
                    sampleCount = sampleCount1;
                    status = Imports.GetValues(handle, 0, ref sampleCount, 1, Imports.DownSamplingMode.None, 0, out overflow);
                // System.Threading.Thread.Sleep(200);
                if (qq == 0)
                {
                    long[] buffer2 = new long[sampleCount1];

                    //TimeBase = Convert.ToInt16(comboBox2.Text);
                   // string TimeBase1;

                    switch (comboBox2.Text)
                    {

                        case "1K/S":
                            TimeBase = 125002;
                            //TimeBase1 = "1K/S";
                            break;
                        case "2K/S":
                            TimeBase = 62502;
                            //TimeBase1 = "1K/S";
                            break;
                        case "4K/S":
                            TimeBase = 31252;
                           // TimeBase1 = "1K/S";
                            break;
                        case "8K/S":
                            TimeBase = 15627;
                           // TimeBase1 = "1K/S";
                            break;
                        case "16K/S":
                            TimeBase = 7815;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "32K/S":
                            TimeBase = 3908;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "64K/S":
                            TimeBase = 1955;
                           // TimeBase1 = "1K/S";
                            break;
                        case "128K/S":
                            TimeBase = 978;
                           // TimeBase1 = "1K/S";
                            break;
                        case "256K/S":
                            TimeBase = 490;
                           // TimeBase1 = "1K/S";
                            break;
                        case "512K/S":
                            TimeBase = 246;
                           // TimeBase1 = "1K/S";
                            break;
                        case "1MB/S":
                            TimeBase = 127;
                           // TimeBase1 = "1K/S";
                            break;
                        case "2MB/S":
                            TimeBase = 64;
                           // TimeBase1 = "1K/S";
                            break;
                        case "2.5MB/S":
                            TimeBase = 52;
                           // TimeBase1 = "1K/S";
                            break;
                        case "4MB/S":
                            TimeBase = 33;
                           // TimeBase1 = "1K/S";
                            break;
                        case "5MB/S":
                            TimeBase = 27;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "8.3MB/S":
                            TimeBase = 17;
                           // TimeBase1 = "1K/S";
                            break;
                        case "12.5MB/S":
                            TimeBase = 12;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "25MB/S":
                            TimeBase = 7;
                           // TimeBase1 = "1K/S";
                            break;
                        case "62.5MB/S":
                            TimeBase = 4;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "125MB/S":
                            TimeBase = 3;
                          //  TimeBase1 = "1K/S";
                            break;
                        case "250MB/S":
                            TimeBase = 2;
                           // TimeBase1 = "1K/S";
                            break;
                        case "500MB/S":
                            TimeBase = 1;
                           // TimeBase1 = "1K/S";
                            break;
                        case "1G/S":
                            TimeBase = 0;
                          //  TimeBase1 = "1K/S";
                            break;
                    }

                   // caiyanglv = comboBox2.Text;
                    // Size = Convert.ToInt16(comboBox3.Text);
                    //  Amplitude = Convert.ToInt16(comboBox1.Text);
                    switch (comboBox1.Text)
                    {
                        case "+/-1mA":
                            Amplitude = 0;
                            break;
                        case "+/-2mA":
                            Amplitude = 1;
                            break;
                        case "+/-5mA":
                            Amplitude = 2;
                            break;
                        case "+/-10mA":
                            Amplitude = 3;
                            break;
                        case "+/-20mA":
                            Amplitude = 4;
                            break;
                        case "+/-50mA":
                            Amplitude = 5;
                            break;
                        case "+/-100mA":
                            Amplitude = 6;
                            break;
                        case "+/-200mA":
                            Amplitude = 7;
                            break;
                        default:
                            Amplitude = 0;
                            break;
                    }
                    //liangcheng = comboBox1.Text;
                    value = getRange(Amplitude);
                    double[] bufferTransfer = new double[sampleCount1];
                    double[] bufferTransfer2 = new double[sampleCount1];
                    for (i = 0; i < sampleCount1; i++)
                    {
                        buffer2[i] = buffer1[i] >> 56;
                        if (i < 8192 * 1024)
                        {
                            bufferTransfer[i] = (buffer2[i]) * value / 127.0;
                           
                            sum = sum + bufferTransfer[i];
                            sum2 = sum2 + Math.Pow((buffer2[i]) * value*4 / 127.0 , 2);
                        }
                        else
                        {
                            sum2 = sum2 + Math.Pow((buffer2[i]) * value *4/ 127.0 , 2);
                            sum = sum + (buffer2[i]) * value / 127.0;
                        }
                    }
                    root = Math.Sqrt(sum2 / sampleCount1);
                    textBox6.Text = Convert.ToString(root);
                    textBox9.Text = Convert.ToString(sum * 4 / sampleCount1);  //计算平均电晕电流    
                                                                               //System.Threading.Thread.Sleep(200);
                                                                               //this.ZedGraphControl1.
                    this.ZedGraphControl1.GraphPane.CurveList.Clear();
                    this.ZedGraphControl1.GraphPane.GraphObjList.Clear();
                    if (size1 > 8192 * 1024)
                    {
                        flag = 3;
                        acq_status(flag);
                        size1 = 8192 * 1024;
                    }

                    textBox5.Text = "图像绘制中，请勿操作";
                    textBox5.Update();
                    Random ran = new Random();
                    PointPairList list = new PointPairList();
                    LineItem myCurve;
                    this.ZedGraphControl1.GraphPane.Title.Text = "电晕电流图";
                    this.ZedGraphControl1.GraphPane.XAxis.Title.Text = "采样点";
                    this.ZedGraphControl1.GraphPane.YAxis.Title.Text = "电流";
                    //System.Threading.Thread.Sleep(200);
                    double y;

                    for (long k = 0; k < size1; k++)
                    {
                        //long x = k;
                       // double y;//double[] y = new double[sampleCount];
                        y = bufferTransfer[k];
                        list.Add(k, y);
                    }

                    myCurve = ZedGraphControl1.GraphPane.AddCurve("电流曲线", list, Color.Red, SymbolType.None);
                    this.ZedGraphControl1.AxisChange();

                    this.ZedGraphControl1.Refresh();
                    // System.Threading.Thread.Sleep(200);
                    //this.Refresh();
                    textBox9.Text = Convert.ToString(sum * 4 / sampleCount1);

                   // if (FileParaFlag == 1)
                  //  {
                     //   FileParaFlag = 0;
                        //string[] AutoSaveBuf = new string[200];
                        //string AutoSaveBuf = string.Format("采样率：{0}存储深度：{1}量程范围：{2}电压等级：{3}", TimeBase1, Size, Amplitude, VoltageLevel);
                        // sprintf(AutoSaveBuf, "采样率：%d\t存储深度：%d\t量程范围：%d\t电压等级：%d\n", TimeBase, Size, Amplitude, VoltageLevel);
                        // WriteFile(hFile0, AutoSaveBuf, strlen(AutoSaveBuf));
                       // string AutoSaveBuf = "采样率：" + comboBox2.Text + "存储深度:" + comboBox3.Text + "量程范围:" + comboBox3.Text + "电压等级:" + textBox6.Text;
                 //   }

                    textBox5.Text = "存储中，请勿操作";
                    textBox5.Update();

                    // if (shijian == 58)
                    //{
                    fileNameOne = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".txt";
                    filePathOne = System.IO.Path.Combine(textBox7.Text, fileNameOne);
                    //string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);
                    //System.IO.File.Create(filePathOne).Close();
                    //FileStream aFile = new FileStream(filePathOne, FileMode.CreateNew);
                    //StreamWriter sw = new StreamWriter(aFile);}
                    // }
                    // System.Threading.Thread.Sleep(200);

                    using (StreamWriter sw = File.AppendText(filePathOne))
                    {
                        //time = comboBox2.Text;
                        //time = System.Text.RegularExpressions.Regex.Replace(comboBox2.Text, @"[^0-9]+", "");
                        //size = comboBox3.Text;
                        //size = System.Text.RegularExpressions.Regex.Replace(comboBox3.Text, @"[^0-9]+", "");
                        //amplitude = comboBox1.Text;
                        //amplitude = System.Text.RegularExpressions.Regex.Replace(comboBox1.Text, @"[^0-9]+", "");
                        //couple = comboBox4.Text;
                        //couple = System.Text.RegularExpressions.Regex.Replace(comboBox4.Text, @"[^0-9]+", "");
                        //voltagelevel = textBox6.Text;
                        //voltagelevel = System.Text.RegularExpressions.Regex.Replace(textBox6.Text, @"[^0-9]+", "");


                        couple = "0";

                        if (comboBox4.Text == "直流耦合")
                        {
                            couple = "0";
                        }
                        if (comboBox4.Text == "交流耦合")
                        {
                            couple = "1";
                        }
                        // couple = System.Text.RegularExpressions.Regex.Replace(comboBox4.Text, @"[^0-9]+", "");
                        //voltagelevel = textBox6.Text;
                        voltagelevel = System.Text.RegularExpressions.Regex.Replace(textBox6.Text, @"[^0-9]+", "");

                        switch (comboBox2.Text)
                        {
                            case "1K/S": time = "0"; break;
                            case "2K/S": time = "1"; break;
                            case "4K/S": time = "2"; break;
                            case "8K/S": time = "3"; break;
                            case "16K/S": time = "4"; break;
                            case "32K/S": time = "5"; break;
                            case "64K/S": time = "6"; break;
                            case "128K/S": time = "7"; break;
                            case "256K/S": time = "8"; break;
                            case "512K/S": time = "9"; break;
                            case "1M/S": time = "10"; break;
                            case "2M/S": time = "11"; break;
                            case "2.5M/S": time = "12"; break;
                            case "4M/S": time = "13"; break;
                            case "5M/S": time = "14"; break;
                            case "8.3M/S": time = "15"; break;
                            case "12.5M/S": time = "16"; break;
                            case "25M/S": time = "17"; break;
                            case "62.5M/S": time = "18"; break;
                            case "125M/S": time = "19"; break;
                            case "250M/S": time = "20"; break;
                            case "500M/S": time = "21"; break;
                            case "1G/S": time = "22"; break;
                            default: time = ""; break;

                        }

                        switch (comboBox3.Text)
                        {
                            case "1KB": size = "0"; break;
                            case "2KB": size = "1"; break;
                            case "4KB": size = "2"; break;
                            case "8KB": size = "3"; break;
                            case "16KB": size = "4"; break;
                            case "32KB": size = "5"; break;
                            case "64KB": size = "6"; break;
                            case "128KB": size = "7"; break;
                            case "256KB": size = "8"; break;
                            case "512KB": size = "9"; break;
                            case "1MB": size = "10"; break;
                            case "2MB": size = "11"; break;
                            case "4MB": size = "12"; break;
                            case "8MB": size = "13"; break;
                            case "16MB": size = "14"; break;
                            case "32MB": size = "15"; break;
                            case "64MB": size = "16"; break;
                            case "128MB": size = "17"; break;
                            default: size = ""; break;
                        }

                        switch (comboBox1.Text)
                        {
                            case "+/-1mA": amplitude = "0"; break;
                            case "+/-2mA": amplitude = "1"; break;
                            case "+/-5mA": amplitude = "2"; break;
                            case "+/-10mA": amplitude = "3"; break;
                            case "+/-20mA": amplitude = "4"; break;
                            case "+/-50mA": amplitude = "5"; break;
                            case "+/-100mA": amplitude = "6"; break;
                            case "+/-200mA": amplitude = "7"; break;
                            default: amplitude = ""; break;
                        }

                        sw.Write(" " + time + " ");
                        sw.Write(" " + size + " ");

                        sw.Write(" " + amplitude + " ");
                        sw.Write(" " + couple + " ");
                        sw.Write(" " + voltagelevel + " ");
                        for (i = 0; i < sampleCount; i++)
                        {

                          //  sw.Write("\n");

                            sw.Write(" " + buffer2[i] + " ");

                        }
                        sw.Close();
                    }
                    if (qq == 0)
                    {
                        textBox5.Text = "存储完毕，等待下一次采集";
                        textBox5.Update();
                    }
                    else
                    {
                        textBox5.Text = "设备丢失";
                        textBox5.Update();
                    }
                    //qq = 0;
                    // System.Threading.Thread.Sleep(200);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             shijian--;

               textBox2.Text = Convert.ToString(shijian);
          //  textBox2.Text = "1";
            //System.Threading.Thread.Sleep(200);

             if (shijian == 0)
             {
                textBox5.Text = "采集中，请不要操作";
                textBox5.Update();
                autocollect();
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();

                shijian = Convert.ToInt16(textBox1.Text);
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
        

