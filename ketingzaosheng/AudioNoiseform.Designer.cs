﻿namespace ps5000example
{
    partial class AudioNoiseform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioNoiseform));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_voltage0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Fs0 = new System.Windows.Forms.TextBox();
            this.textBox_size_n0 = new System.Windows.Forms.TextBox();
            this.textBox_filename0 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_data_voltage = new System.Windows.Forms.Panel();
            this.textBox_voltage8 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Fs8 = new System.Windows.Forms.TextBox();
            this.textBox_size_n8 = new System.Windows.Forms.TextBox();
            this.textBox_filename8 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel_figure = new System.Windows.Forms.Panel();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_data_voltage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_figure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 519);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel_data_voltage);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(312, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件处理";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "基本参数";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.textBox_voltage0);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.textBox_Fs0);
            this.panel3.Controls.Add(this.textBox_size_n0);
            this.panel3.Controls.Add(this.textBox_filename0);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(6, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 182);
            this.panel3.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "基本参数";
            // 
            // textBox_voltage0
            // 
            this.textBox_voltage0.Location = new System.Drawing.Point(101, 144);
            this.textBox_voltage0.Name = "textBox_voltage0";
            this.textBox_voltage0.Size = new System.Drawing.Size(172, 21);
            this.textBox_voltage0.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "电压等级：";
            // 
            // textBox_Fs0
            // 
            this.textBox_Fs0.Location = new System.Drawing.Point(101, 22);
            this.textBox_Fs0.Name = "textBox_Fs0";
            this.textBox_Fs0.Size = new System.Drawing.Size(172, 21);
            this.textBox_Fs0.TabIndex = 7;
            // 
            // textBox_size_n0
            // 
            this.textBox_size_n0.Location = new System.Drawing.Point(101, 63);
            this.textBox_size_n0.Name = "textBox_size_n0";
            this.textBox_size_n0.Size = new System.Drawing.Size(172, 21);
            this.textBox_size_n0.TabIndex = 6;
            // 
            // textBox_filename0
            // 
            this.textBox_filename0.Location = new System.Drawing.Point(101, 105);
            this.textBox_filename0.Name = "textBox_filename0";
            this.textBox_filename0.Size = new System.Drawing.Size(172, 21);
            this.textBox_filename0.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "文件名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "数据点数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "采样率：";
            // 
            // panel_data_voltage
            // 
            this.panel_data_voltage.Controls.Add(this.textBox_voltage8);
            this.panel_data_voltage.Controls.Add(this.label5);
            this.panel_data_voltage.Controls.Add(this.textBox_Fs8);
            this.panel_data_voltage.Controls.Add(this.textBox_size_n8);
            this.panel_data_voltage.Controls.Add(this.textBox_filename8);
            this.panel_data_voltage.Controls.Add(this.label3);
            this.panel_data_voltage.Controls.Add(this.label2);
            this.panel_data_voltage.Controls.Add(this.label1);
            this.panel_data_voltage.Location = new System.Drawing.Point(6, 111);
            this.panel_data_voltage.Name = "panel_data_voltage";
            this.panel_data_voltage.Size = new System.Drawing.Size(294, 181);
            this.panel_data_voltage.TabIndex = 2;
            // 
            // textBox_voltage8
            // 
            this.textBox_voltage8.Location = new System.Drawing.Point(101, 141);
            this.textBox_voltage8.Name = "textBox_voltage8";
            this.textBox_voltage8.Size = new System.Drawing.Size(172, 21);
            this.textBox_voltage8.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "电压等级：";
            // 
            // textBox_Fs8
            // 
            this.textBox_Fs8.Location = new System.Drawing.Point(101, 22);
            this.textBox_Fs8.Name = "textBox_Fs8";
            this.textBox_Fs8.Size = new System.Drawing.Size(172, 21);
            this.textBox_Fs8.TabIndex = 6;
            // 
            // textBox_size_n8
            // 
            this.textBox_size_n8.Location = new System.Drawing.Point(101, 60);
            this.textBox_size_n8.Name = "textBox_size_n8";
            this.textBox_size_n8.Size = new System.Drawing.Size(172, 21);
            this.textBox_size_n8.TabIndex = 5;
            // 
            // textBox_filename8
            // 
            this.textBox_filename8.Location = new System.Drawing.Point(101, 100);
            this.textBox_filename8.Name = "textBox_filename8";
            this.textBox_filename8.Size = new System.Drawing.Size(172, 21);
            this.textBox_filename8.TabIndex = 4;
            this.textBox_filename8.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "文件名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据点数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "采样率：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 88);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("宋体", 10F);
            this.button1.Location = new System.Drawing.Point(3, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择电晕电流文件";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("宋体", 10F);
            this.button3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button3.Location = new System.Drawing.Point(3, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 33);
            this.button3.TabIndex = 2;
            this.button3.Text = "选择电晕电流背景文件";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 609);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 75);
            this.button4.TabIndex = 4;
            this.button4.Text = "查看波形";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel_figure
            // 
            this.panel_figure.Controls.Add(this.zedGraphControl4);
            this.panel_figure.Controls.Add(this.zedGraphControl3);
            this.panel_figure.Controls.Add(this.zedGraphControl2);
            this.panel_figure.Controls.Add(this.zedGraphControl1);
            this.panel_figure.Location = new System.Drawing.Point(352, 13);
            this.panel_figure.Margin = new System.Windows.Forms.Padding(4);
            this.panel_figure.Name = "panel_figure";
            this.panel_figure.Size = new System.Drawing.Size(1426, 774);
            this.panel_figure.TabIndex = 7;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Location = new System.Drawing.Point(706, 394);
            this.zedGraphControl4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(706, 371);
            this.zedGraphControl4.TabIndex = 5;
            this.zedGraphControl4.Visible = false;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(706, 21);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(706, 374);
            this.zedGraphControl3.TabIndex = 4;
            this.zedGraphControl3.Visible = false;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 394);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(706, 371);
            this.zedGraphControl2.TabIndex = 3;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 21);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(706, 374);
            this.zedGraphControl1.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 702);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 85);
            this.button5.TabIndex = 8;
            this.button5.Text = "电晕电流信号处理";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "加压信号时域波形",
            "加压信号离散频谱"});
            this.comboBox2.Location = new System.Drawing.Point(35, 565);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(161, 20);
            this.comboBox2.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(22, 814);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(187, 83);
            this.button6.TabIndex = 12;
            this.button6.Text = "计算电晕电流1/3倍频程";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 794);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(387, 227);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1014, 855);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(181, 83);
            this.button7.TabIndex = 14;
            this.button7.Text = "计算可听噪声A声级";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(792, 855);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(181, 83);
            this.button8.TabIndex = 15;
            this.button8.Text = "保存数据";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10F);
            this.button2.Location = new System.Drawing.Point(25, 933);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 77);
            this.button2.TabIndex = 16;
            this.button2.Text = "选择文件夹";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // AudioNoiseform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel_figure);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AudioNoiseform";
            this.Text = "电晕电流处理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AudioNoiseform_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_data_voltage.ResumeLayout(false);
            this.panel_data_voltage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_figure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel_data_voltage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel_figure;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox_filename0;
        private System.Windows.Forms.TextBox textBox_size_n8;
        private System.Windows.Forms.TextBox textBox_filename8;
        private System.Windows.Forms.TextBox textBox_Fs0;
        private System.Windows.Forms.TextBox textBox_size_n0;
        private System.Windows.Forms.TextBox textBox_voltage8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Fs8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_voltage0;
        private System.Windows.Forms.Label label11;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button2;
    }
}