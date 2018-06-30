using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


namespace ps5000example.ketingzaosheng
{
    public partial class Calculate : Form
    {
        public Calculate()
        {
            InitializeComponent();
        }
        DataTable dt_for_cal;
        DataTable A_xishu;
        DataTable Jisuancanshu, JisuancanshuFor_1_3;

        public static string celiang_gaodu = "";
        public static string G_max = "";
        public static string G_bool = "";

        public void get_data(DataTable dt)
        {
            this.dt_for_cal = dt;
        }

        public void setcanshu(string str1, string str2, string str3)
        {
            celiang_gaodu = str1;
            G_max = str2;
            G_bool= str3;
        }

        private void Calculate_Load(object sender, EventArgs e)
        {
            if(dt_for_cal!=null)
            {
                data_fresh();
            }  
            else
            {
                //dataGridView1.Visible = false;
            }
        }

        private void data_fresh()
        {
            this.dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderCell.Value = "序号";
            dataGridView1.Columns[1].HeaderCell.Value = "中心频率(HZ)";
            dataGridView1.Columns[2].HeaderCell.Value = "幅值(dB)";

            for (int i = 0; i < 31; i++)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = dt_for_cal.Rows[i][0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = dt_for_cal.Rows[i][1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = dt_for_cal.Rows[i][2].ToString();
            }

            GraphPane myPane_1_3 = zedGraphControl1.GraphPane;
            myPane_1_3.Title.Text = "电晕电流1/3倍频程对数功率谱";
            myPane_1_3.XAxis.Title.Text = "频率(kHZ)";
            myPane_1_3.YAxis.Title.Text = "幅值";
            zedGraphControl1.GraphPane.CurveList.Clear();
            PointPairList list3 = new PointPairList();

            for (int i = 0; i < 31; i++)
            {

                list3.Add(Convert.ToDouble(dt_for_cal.Rows[i][1].ToString()) / 1000, Convert.ToDouble(dt_for_cal.Rows[i][2].ToString()));

            }
            LineItem mCure_1_3 = myPane_1_3.AddCurve("", list3, Color.Red, SymbolType.Circle);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();//重新刷新
            zedGraphControl1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFileName8 = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            //strFileName8 = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
                // return;

            }
            
            strFileName8 = ofd.FileName;
            ps5000example.ExcelHelp excelhelp = new ExcelHelp();
            //MessageBox.Show("您当前选择数据为" + strFileName8.ToString());
            dt_for_cal=excelhelp.LoadDataFromExcel(strFileName8);
            if (dt_for_cal != null)
           {
                if (dataGridView1.DataSource != null)
                {
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    dt.Rows.Clear();
                    dataGridView1.DataSource = dt;
                }  else
                {
                    dataGridView1.Rows.Clear();
                }
                data_fresh();
            }else
            {
                MessageBox.Show("读取数据失败");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_gaodu.Text = celiang_gaodu;
            label_Gmax.Text = G_max;
            label_Gbool.Text = G_bool;
            if(comboBox1.Text=="")
            {
                MessageBox.Show("请选择估算方法");
                return;
            }
            get_ANbydiffway();

            panel1.Visible = true;

        }
        

        public double get_ANbydiffway()
        {
            switch(comboBox1.Text)
            {
                
                case "电晕电流A计权值法":
                    label_AN.Text = get_ANby1_3data().ToString().Substring(0, 5) + "  dB";
                     break; 
                case "1kHz-20kHz频谱相关性法":
                    label_AN.Text = get_ANby1_20KHZdata().ToString().Substring(0, 5) + "  dB";
                    break; 
                case "1.6kHz-8kHz频谱相关性法":
                    label_AN.Text = get_ANby1_6_8KHZdata().ToString().Substring(0, 5) + "  dB";
                    break; 
                case "不同斜率频谱相关性法":
                    label_AN.Text = get_ANbydiff_xielvdata().ToString().Substring(0, 5) + "  dB";
                    break;
                default: /* 可选的 */
                    //statement(s);
                    break;
            }
            
            
            

            return 0;
        }

        private double get_ANby1_3data()
        {
            double[] data_1_3 = new double[31];
            double[] a_xishu = new double[31];
            for (int i = 0; i < 31; i++)
            {
                data_1_3[i] = Convert.ToDouble(dt_for_cal.Rows[i][2].ToString());
                a_xishu[i] = Convert.ToDouble(A_xishu.Rows[i][1].ToString());
            }
            double tmp = 0;
            double Ym = 0;
            double An = 0;
            for (int i = 19; i < 26; i++)
            {
                tmp += Math.Pow(10, (data_1_3[i] + a_xishu[i]) * 0.1);//10的(Y(f)+A)*0.1次方
            }
            Ym = 10 * Math.Log10(tmp);
            if (label_Gbool.Text == "否")
            {
                
                    
                   An = Convert.ToDouble(JisuancanshuFor_1_3.Rows[0][0].ToString()) * Ym + Convert.ToDouble(JisuancanshuFor_1_3.Rows[0][1].ToString());
            }
            else if (label_Gbool.Text == "是")
            {
                   An = Convert.ToDouble(JisuancanshuFor_1_3.Rows[0][2].ToString()) * Ym + Convert.ToDouble(JisuancanshuFor_1_3.Rows[0][3].ToString());
            }
            An = An - Math.Log10(Convert.ToDouble(label_gaodu.Text));
            return An;
        }

        private double get_ANby1_20KHZdata()
        {
            double[] data_1_3 = new double[31];
            double[] a_xishu = new double[31];
            double[] xielv_xishu = new double[31];
            double[] jieju_weak_xishu = new double[31];
            double[] jieju_strong_xishu = new double[31];
            double[] jieju_for_calu_xishu = new double[31];

            for (int i = 0; i < 31; i++)
            {
                data_1_3[i] = Convert.ToDouble(dt_for_cal.Rows[i][2].ToString());
                a_xishu[i] = Convert.ToDouble(A_xishu.Rows[i][1].ToString());
            }
            for (int i = 0; i < 14; i++)
            {
                xielv_xishu[i+17] = Convert.ToDouble(Jisuancanshu.Rows[i][1].ToString());
                jieju_weak_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][2].ToString());
                jieju_strong_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][3].ToString());
            }

            double tmp = 0;
            double Ym = 0;
            double An = 0;

            if (label_Gbool.Text == "是")
            {
                jieju_for_calu_xishu= jieju_strong_xishu;
            }
            else if (label_Gbool.Text == "否")
            {
                jieju_for_calu_xishu = jieju_weak_xishu;
            }

            for (int i = 17; i < 31; i++)
            {
                Ym = data_1_3[i] * xielv_xishu[i] + jieju_for_calu_xishu[i];
                tmp += Math.Pow(10, (Ym + a_xishu[i]) * 0.1);//10的(Y(f)+A)*0.1次方
            }
            An = 10 * Math.Log10(tmp);

            
            An = An - Math.Log10(Convert.ToDouble(label_gaodu.Text) / 5.0);
            return An;
        }

        private double get_ANby1_6_8KHZdata()
        {
            double[] data_1_3 = new double[31];
            double[] a_xishu = new double[31];
            double[] xielv_xishu = new double[31];
            double[] jieju_weak_xishu = new double[31];
            double[] jieju_strong_xishu = new double[31];
            double[] jieju_for_calu_xishu = new double[31];

            for (int i = 0; i < 31; i++)
            {
                data_1_3[i] = Convert.ToDouble(dt_for_cal.Rows[i][2].ToString());
                a_xishu[i] = Convert.ToDouble(A_xishu.Rows[i][1].ToString());
            }
            for (int i = 0; i < 14; i++)
            {
                xielv_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][1].ToString());
                jieju_weak_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][2].ToString());
                jieju_strong_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][3].ToString());
            }

            double tmp = 0;
            double Ym = 0;
            double An = 0;

            if (label_Gbool.Text == "是")
            {
                jieju_for_calu_xishu = jieju_strong_xishu;
            }
            else if (label_Gbool.Text == "否")
            {
                jieju_for_calu_xishu = jieju_weak_xishu;
            }

            for (int i = 19; i < 27; i++)
            {
                Ym = data_1_3[i] * xielv_xishu[i] + jieju_for_calu_xishu[i];
                tmp += Math.Pow(10, (Ym + a_xishu[i]) * 0.1);//10的(Y(f)+A)*0.1次方
            }
            An = 10 * Math.Log10(tmp);


            An = An - Math.Log10(Convert.ToDouble(label_gaodu.Text) / 5.0);
            return An;
        }

        private double get_ANbydiff_xielvdata()
        {
            double[] data_1_3 = new double[31];
            double[] a_xishu = new double[31];
            double[] xielv_weak_xishu = new double[31];
            double[] xielv_strong_xishu = new double[31];
            double[] jieju_weak_xishu = new double[31];
            double[] jieju_strong_xishu = new double[31];
            double[] jieju_for_calu_xishu = new double[31];
            double[] xielv_for_calu_xishu = new double[31];

            for (int i = 0; i < 31; i++)
            {
                data_1_3[i] = Convert.ToDouble(dt_for_cal.Rows[i][2].ToString());
                a_xishu[i] = Convert.ToDouble(A_xishu.Rows[i][1].ToString());
            }
            for (int i = 0; i < 14; i++)
            {
                xielv_weak_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][5].ToString());
                jieju_weak_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][6].ToString());

                xielv_strong_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][7].ToString());
                jieju_strong_xishu[i + 17] = Convert.ToDouble(Jisuancanshu.Rows[i][8].ToString());
            }

            double tmp = 0;
            double Ym = 0;
            double An = 0;

            if (label_Gbool.Text == "是")
            {
                jieju_for_calu_xishu = jieju_strong_xishu;
                xielv_for_calu_xishu = xielv_strong_xishu;
            }
            else if (label_Gbool.Text == "否")
            {
                jieju_for_calu_xishu = jieju_weak_xishu;
                xielv_for_calu_xishu = xielv_weak_xishu;
            }
        
            for (int i = 19; i < 31; i++)
            {
                Ym = data_1_3[i] * xielv_for_calu_xishu[i] + jieju_for_calu_xishu[i];
                tmp += Math.Pow(10, (Ym + a_xishu[i]) * 0.1);//10的(Y(f)+A)*0.1次方
            }
            An = 10 * Math.Log10(tmp);


            An = An - Math.Log10(Convert.ToDouble(label_gaodu.Text)/5.0);
            return An;
        }



        private void 启动设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button1_Click(this,null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setcanshu setcanshu = new setcanshu();
            setcanshu.Show();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            
            string strFileA_xishu = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            //strFileA_xishu = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
                // return;

            }

            strFileA_xishu = ofd.FileName;
            ps5000example.ExcelHelp excelhelp = new ExcelHelp();
            //MessageBox.Show("您当前选择数据为" + strFileName8.ToString());
            A_xishu = excelhelp.LoadDataFromExcel(strFileA_xishu);
            try
            {

            
           
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[3].HeaderCell.Value = "A加权系数";

            for (int i = 0; i < 31; i++)
            {
                
                this.dataGridView1.Rows[i].Cells[3].Value = A_xishu.Rows[i][1].ToString();
                
            }
            this.dataGridView1.Columns[0].FillWeight = 60;
            this.dataGridView1.Columns[1].FillWeight = 60;
             MessageBox.Show("读取数据成功");
            }catch
            {
                MessageBox.Show("读取数据失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strFile_jisuancanshu = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\开题\\shuju";
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            //strFileA_xishu = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
            if (ofd.ShowDialog() != DialogResult.OK)
            {

                MessageBox.Show("请选择数据文件");
                // return;

            }

            strFile_jisuancanshu = ofd.FileName;
            ps5000example.ExcelHelp excelhelp = new ExcelHelp();
            //MessageBox.Show("您当前选择数据为" + strFileName8.ToString());
            Jisuancanshu = excelhelp.LoadDataFromExcel(strFile_jisuancanshu);
            JisuancanshuFor_1_3 = excelhelp.LoadDataFromExcel_sheel2(strFile_jisuancanshu);

            if (Jisuancanshu!=null && JisuancanshuFor_1_3 != null)
               MessageBox.Show("读取数据成功");
        }
    }
}
