namespace ps5000example.ketingzaosheng
{
    partial class Calculate
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
        public void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.启动设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Gbool = new System.Windows.Forms.Label();
            this.label_Gmax = new System.Windows.Forms.Label();
            this.label_gaodu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_AN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 716);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 83);
            this.button2.TabIndex = 15;
            this.button2.Text = "计算可听噪声A声级";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(471, 801);
            this.dataGridView1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 922);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 83);
            this.button1.TabIndex = 17;
            this.button1.Text = "读取电晕电流1/3倍频程数值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(45, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "电晕电流1/3倍频程对数功率谱幅值";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(513, 99);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(706, 371);
            this.zedGraphControl1.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 35);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 启动设置ToolStripMenuItem
            // 
            this.启动设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动设置ToolStripMenuItem1});
            this.启动设置ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.启动设置ToolStripMenuItem.Name = "启动设置ToolStripMenuItem";
            this.启动设置ToolStripMenuItem.Size = new System.Drawing.Size(64, 31);
            this.启动设置ToolStripMenuItem.Text = "开始";
            // 
            // 启动设置ToolStripMenuItem1
            // 
            this.启动设置ToolStripMenuItem1.Name = "启动设置ToolStripMenuItem1";
            this.启动设置ToolStripMenuItem1.Size = new System.Drawing.Size(130, 32);
            this.启动设置ToolStripMenuItem1.Text = "文件";
            this.启动设置ToolStripMenuItem1.Click += new System.EventHandler(this.启动设置ToolStripMenuItem1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(568, 532);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 83);
            this.button3.TabIndex = 21;
            this.button3.Text = "参数设定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "电晕电流A计权值法",
            "1kHz-20kHz频谱相关性法",
            "1.6kHz-8kHz频谱相关性法",
            "不同斜率频谱相关性法"});
            this.comboBox1.Location = new System.Drawing.Point(568, 663);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 23);
            this.comboBox1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_AN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label_Gbool);
            this.panel1.Controls.Add(this.label_Gmax);
            this.panel1.Controls.Add(this.label_gaodu);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(811, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 245);
            this.panel1.TabIndex = 23;
            this.panel1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(73, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "可听噪声A声级：";
            // 
            // label_Gbool
            // 
            this.label_Gbool.AutoSize = true;
            this.label_Gbool.Font = new System.Drawing.Font("宋体", 14F);
            this.label_Gbool.Location = new System.Drawing.Point(268, 132);
            this.label_Gbool.Name = "label_Gbool";
            this.label_Gbool.Size = new System.Drawing.Size(22, 24);
            this.label_Gbool.TabIndex = 27;
            this.label_Gbool.Text = "0";
            // 
            // label_Gmax
            // 
            this.label_Gmax.AutoSize = true;
            this.label_Gmax.Font = new System.Drawing.Font("宋体", 14F);
            this.label_Gmax.Location = new System.Drawing.Point(268, 89);
            this.label_Gmax.Name = "label_Gmax";
            this.label_Gmax.Size = new System.Drawing.Size(22, 24);
            this.label_Gmax.TabIndex = 26;
            this.label_Gmax.Text = "0";
            // 
            // label_gaodu
            // 
            this.label_gaodu.AutoSize = true;
            this.label_gaodu.Font = new System.Drawing.Font("宋体", 14F);
            this.label_gaodu.Location = new System.Drawing.Point(268, 46);
            this.label_gaodu.Name = "label_gaodu";
            this.label_gaodu.Size = new System.Drawing.Size(22, 24);
            this.label_gaodu.TabIndex = 25;
            this.label_gaodu.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(18, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "计算结果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(92, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "是否起晕：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(82, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "表面最大场强\r\n   (kV/cm)：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(82, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "导线高度(m)：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F);
            this.label9.Location = new System.Drawing.Point(605, 641);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "选择计算方法";
            // 
            // label_AN
            // 
            this.label_AN.AutoSize = true;
            this.label_AN.Font = new System.Drawing.Font("宋体", 14F);
            this.label_AN.Location = new System.Drawing.Point(268, 180);
            this.label_AN.Name = "label_AN";
            this.label_AN.Size = new System.Drawing.Size(22, 24);
            this.label_AN.TabIndex = 29;
            this.label_AN.Text = "0";
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Name = "Calculate";
            this.Text = "计算可听噪声";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Calculate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 启动设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动设置ToolStripMenuItem1;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Gbool;
        private System.Windows.Forms.Label label_Gmax;
        private System.Windows.Forms.Label label_gaodu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_AN;
    }
}