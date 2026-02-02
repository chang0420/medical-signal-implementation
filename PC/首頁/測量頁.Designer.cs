
namespace 首頁
{
    partial class 測量頁
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.COM = new System.Windows.Forms.ToolStripMenuItem();
            this.藍芽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortR = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHR測量值 = new System.Windows.Forms.Label();
            this.lbl濕度測量中 = new System.Windows.Forms.Label();
            this.lbl溫度測量中 = new System.Windows.Forms.Label();
            this.lbl濕度Max = new System.Windows.Forms.Label();
            this.lbl濕度Min = new System.Windows.Forms.Label();
            this.lbl溫度Max = new System.Windows.Forms.Label();
            this.lbl溫度Min = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblSpO2 = new System.Windows.Forms.Label();
            this.progressBarSpO2 = new System.Windows.Forms.ProgressBar();
            this.btnSpO2 = new System.Windows.Forms.Button();
            this.btnHR = new System.Windows.Forms.Button();
            this.btnECG = new System.Windows.Forms.Button();
            this.btnTemp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnlog = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.OliveDrab;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.20895F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COM,
            this.藍芽ToolStripMenuItem,
            this.comPortConfigToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 172);
            // 
            // COM
            // 
            this.COM.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.20895F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.COM.ForeColor = System.Drawing.Color.LemonChiffon;
            this.COM.ImageTransparentColor = System.Drawing.Color.Green;
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(217, 28);
            this.COM.Text = "COM";
            this.COM.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.COM_DropDownItemClicked);
            this.COM.Click += new System.EventHandler(this.COM_Click);
            // 
            // 藍芽ToolStripMenuItem
            // 
            this.藍芽ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.20895F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.藍芽ToolStripMenuItem.ForeColor = System.Drawing.Color.LemonChiffon;
            this.藍芽ToolStripMenuItem.Name = "藍芽ToolStripMenuItem";
            this.藍芽ToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.藍芽ToolStripMenuItem.Text = "藍芽";
            this.藍芽ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.藍芽ToolStripMenuItem_DropDownItemClicked);
            this.藍芽ToolStripMenuItem.Click += new System.EventHandler(this.藍芽ToolStripMenuItem_Click);
            // 
            // comPortConfigToolStripMenuItem
            // 
            this.comPortConfigToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.comPortConfigToolStripMenuItem.Name = "comPortConfigToolStripMenuItem";
            this.comPortConfigToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.comPortConfigToolStripMenuItem.Text = "ComPortConfig";
            this.comPortConfigToolStripMenuItem.Click += new System.EventHandler(this.comPortConfigToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.ForeColor = System.Drawing.Color.LightYellow;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.LightYellow;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.LightYellow;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // serialPortR
            // 
            this.serialPortR.ReadBufferSize = 8192;
            this.serialPortR.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortR_DataReceived);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 288);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1081, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHR測量值
            // 
            this.lblHR測量值.AutoSize = true;
            this.lblHR測量值.BackColor = System.Drawing.Color.Transparent;
            this.lblHR測量值.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lblHR測量值.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblHR測量值.Location = new System.Drawing.Point(218, 71);
            this.lblHR測量值.Name = "lblHR測量值";
            this.lblHR測量值.Size = new System.Drawing.Size(126, 23);
            this.lblHR測量值.TabIndex = 3;
            this.lblHR測量值.Text = "  beats/min";
            // 
            // lbl濕度測量中
            // 
            this.lbl濕度測量中.AutoSize = true;
            this.lbl濕度測量中.BackColor = System.Drawing.Color.Transparent;
            this.lbl濕度測量中.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl濕度測量中.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl濕度測量中.Location = new System.Drawing.Point(415, 153);
            this.lbl濕度測量中.Name = "lbl濕度測量中";
            this.lbl濕度測量中.Size = new System.Drawing.Size(29, 23);
            this.lbl濕度測量中.TabIndex = 4;
            this.lbl濕度測量中.Text = "0 ";
            // 
            // lbl溫度測量中
            // 
            this.lbl溫度測量中.AutoSize = true;
            this.lbl溫度測量中.BackColor = System.Drawing.Color.Transparent;
            this.lbl溫度測量中.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl溫度測量中.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl溫度測量中.Location = new System.Drawing.Point(149, 151);
            this.lbl溫度測量中.Name = "lbl溫度測量中";
            this.lbl溫度測量中.Size = new System.Drawing.Size(23, 23);
            this.lbl溫度測量中.TabIndex = 5;
            this.lbl溫度測量中.Text = "0";
            // 
            // lbl濕度Max
            // 
            this.lbl濕度Max.AutoSize = true;
            this.lbl濕度Max.BackColor = System.Drawing.Color.Transparent;
            this.lbl濕度Max.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl濕度Max.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl濕度Max.Location = new System.Drawing.Point(415, 188);
            this.lbl濕度Max.Name = "lbl濕度Max";
            this.lbl濕度Max.Size = new System.Drawing.Size(29, 23);
            this.lbl濕度Max.TabIndex = 3;
            this.lbl濕度Max.Text = "0 ";
            // 
            // lbl濕度Min
            // 
            this.lbl濕度Min.AutoSize = true;
            this.lbl濕度Min.BackColor = System.Drawing.Color.Transparent;
            this.lbl濕度Min.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl濕度Min.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl濕度Min.Location = new System.Drawing.Point(415, 225);
            this.lbl濕度Min.Name = "lbl濕度Min";
            this.lbl濕度Min.Size = new System.Drawing.Size(29, 23);
            this.lbl濕度Min.TabIndex = 4;
            this.lbl濕度Min.Text = "0 ";
            // 
            // lbl溫度Max
            // 
            this.lbl溫度Max.AutoSize = true;
            this.lbl溫度Max.BackColor = System.Drawing.Color.Transparent;
            this.lbl溫度Max.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl溫度Max.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl溫度Max.Location = new System.Drawing.Point(149, 187);
            this.lbl溫度Max.Name = "lbl溫度Max";
            this.lbl溫度Max.Size = new System.Drawing.Size(23, 23);
            this.lbl溫度Max.TabIndex = 5;
            this.lbl溫度Max.Text = "0";
            // 
            // lbl溫度Min
            // 
            this.lbl溫度Min.AutoSize = true;
            this.lbl溫度Min.BackColor = System.Drawing.Color.Transparent;
            this.lbl溫度Min.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lbl溫度Min.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl溫度Min.Location = new System.Drawing.Point(149, 223);
            this.lbl溫度Min.Name = "lbl溫度Min";
            this.lbl溫度Min.Size = new System.Drawing.Size(23, 23);
            this.lbl溫度Min.TabIndex = 3;
            this.lbl溫度Min.Text = "0";
            // 
            // lblSpO2
            // 
            this.lblSpO2.AutoSize = true;
            this.lblSpO2.BackColor = System.Drawing.Color.Transparent;
            this.lblSpO2.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.lblSpO2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblSpO2.Location = new System.Drawing.Point(166, 34);
            this.lblSpO2.Name = "lblSpO2";
            this.lblSpO2.Size = new System.Drawing.Size(36, 23);
            this.lblSpO2.TabIndex = 3;
            this.lblSpO2.Text = "  %";
            // 
            // progressBarSpO2
            // 
            this.progressBarSpO2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBarSpO2.Location = new System.Drawing.Point(599, 217);
            this.progressBarSpO2.Maximum = 60;
            this.progressBarSpO2.Name = "progressBarSpO2";
            this.progressBarSpO2.Size = new System.Drawing.Size(478, 30);
            this.progressBarSpO2.TabIndex = 6;
            // 
            // btnSpO2
            // 
            this.btnSpO2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSpO2.Enabled = false;
            this.btnSpO2.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpO2.ForeColor = System.Drawing.Color.White;
            this.btnSpO2.Location = new System.Drawing.Point(599, 100);
            this.btnSpO2.Name = "btnSpO2";
            this.btnSpO2.Size = new System.Drawing.Size(113, 101);
            this.btnSpO2.TabIndex = 10;
            this.btnSpO2.Text = "SpO2";
            this.btnSpO2.UseVisualStyleBackColor = false;
            this.btnSpO2.Click += new System.EventHandler(this.btnSpO2_Click);
            // 
            // btnHR
            // 
            this.btnHR.BackColor = System.Drawing.Color.Peru;
            this.btnHR.Enabled = false;
            this.btnHR.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHR.ForeColor = System.Drawing.Color.White;
            this.btnHR.Location = new System.Drawing.Point(720, 100);
            this.btnHR.Name = "btnHR";
            this.btnHR.Size = new System.Drawing.Size(113, 101);
            this.btnHR.TabIndex = 11;
            this.btnHR.Text = "Heart Rate";
            this.btnHR.UseVisualStyleBackColor = false;
            this.btnHR.Click += new System.EventHandler(this.btnHR_Click);
            // 
            // btnECG
            // 
            this.btnECG.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnECG.Enabled = false;
            this.btnECG.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnECG.ForeColor = System.Drawing.Color.White;
            this.btnECG.Location = new System.Drawing.Point(843, 100);
            this.btnECG.Name = "btnECG";
            this.btnECG.Size = new System.Drawing.Size(113, 101);
            this.btnECG.TabIndex = 12;
            this.btnECG.Text = "ECG";
            this.btnECG.UseVisualStyleBackColor = false;
            this.btnECG.Click += new System.EventHandler(this.btnECG_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.BackColor = System.Drawing.Color.Olive;
            this.btnTemp.Enabled = false;
            this.btnTemp.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemp.ForeColor = System.Drawing.Color.White;
            this.btnTemp.Location = new System.Drawing.Point(964, 100);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(113, 101);
            this.btnTemp.TabIndex = 13;
            this.btnTemp.Text = "環境測量";
            this.btnTemp.UseVisualStyleBackColor = false;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(309, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "◆ Humidity（%）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(46, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "◆ Temperature（℃）";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label13.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label13.Location = new System.Drawing.Point(48, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 23);
            this.label13.TabIndex = 17;
            this.label13.Text = "◆ SpO2： ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label14.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label14.Location = new System.Drawing.Point(48, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 23);
            this.label14.TabIndex = 18;
            this.label14.Text = "◆ Heart Rate：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(335, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "最低：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(335, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "平均：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label7.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label7.Location = new System.Drawing.Point(335, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "最高：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(69, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "最高：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(69, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "平均：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Lucida Fax", 11.8209F);
            this.label15.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label15.Location = new System.Drawing.Point(69, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 23);
            this.label15.TabIndex = 25;
            this.label15.Text = "最低：";
            // 
            // btnlog
            // 
            this.btnlog.BackColor = System.Drawing.Color.Olive;
            this.btnlog.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlog.ForeColor = System.Drawing.Color.White;
            this.btnlog.Location = new System.Drawing.Point(942, 34);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(135, 47);
            this.btnlog.TabIndex = 13;
            this.btnlog.Text = "登入";
            this.btnlog.UseVisualStyleBackColor = false;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Olive;
            this.button1.Font = new System.Drawing.Font("Lucida Fax", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(801, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "登出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 測量頁
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::首頁.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1115, 274);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnlog);
            this.Controls.Add(this.btnTemp);
            this.Controls.Add(this.btnECG);
            this.Controls.Add(this.btnHR);
            this.Controls.Add(this.btnSpO2);
            this.Controls.Add(this.progressBarSpO2);
            this.Controls.Add(this.lbl溫度Max);
            this.Controls.Add(this.lbl溫度測量中);
            this.Controls.Add(this.lbl濕度Min);
            this.Controls.Add(this.lbl濕度測量中);
            this.Controls.Add(this.lbl溫度Min);
            this.Controls.Add(this.lbl濕度Max);
            this.Controls.Add(this.lblSpO2);
            this.Controls.Add(this.lblHR測量值);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "測量頁";
            this.Text = "測量頁";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem COM;
        private System.Windows.Forms.ToolStripMenuItem 藍芽ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortConfigToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPortR;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHR測量值;
        private System.Windows.Forms.Label lbl濕度測量中;
        private System.Windows.Forms.Label lbl溫度測量中;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.Label lbl濕度Max;
        private System.Windows.Forms.Label lbl濕度Min;
        private System.Windows.Forms.Label lbl溫度Max;
        private System.Windows.Forms.Label lbl溫度Min;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblSpO2;
        private System.Windows.Forms.ProgressBar progressBarSpO2;
        private System.Windows.Forms.Button btnSpO2;
        private System.Windows.Forms.Button btnHR;
        private System.Windows.Forms.Button btnECG;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnlog;
        private System.Windows.Forms.Button button1;
    }
}

