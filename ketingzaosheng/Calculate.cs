using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ps5000example.ketingzaosheng
{
    public partial class Calculate : Form
    {
        public Calculate()
        {
            InitializeComponent();
        }
        DataTable dt_for_cal;
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

            strFileName8 = "D:\\开题\\shuju\\20120712_20m+\\1000\\2012-07-12-10_56_36.txt  ";
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
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_gaodu.Text = celiang_gaodu;
            label_Gmax.Text = G_max;
            label_Gbool.Text = G_bool;
            if(comboBox1.Text==null)
            {
                MessageBox.Show("请选择估算方法");
                return;
            }
            panel1.Visible = true;

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
    }
}
