namespace 首頁
{
    partial class 登入頁
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
            this.btnNew = new System.Windows.Forms.Button();
            this.lbl提示字 = new System.Windows.Forms.Label();
            this.txtbx密碼 = new System.Windows.Forms.TextBox();
            this.txtxbx帳號 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnNew.Location = new System.Drawing.Point(243, 371);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(159, 47);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "註冊";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lbl提示字
            // 
            this.lbl提示字.AutoSize = true;
            this.lbl提示字.BackColor = System.Drawing.Color.Transparent;
            this.lbl提示字.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl提示字.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl提示字.Location = new System.Drawing.Point(204, 272);
            this.lbl提示字.Name = "lbl提示字";
            this.lbl提示字.Size = new System.Drawing.Size(122, 31);
            this.lbl提示字.TabIndex = 23;
            this.lbl提示字.Text = "輸入錯誤";
            this.lbl提示字.Visible = false;
            // 
            // txtbx密碼
            // 
            this.txtbx密碼.Font = new System.Drawing.Font("Lucida Fax", 13.97015F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx密碼.Location = new System.Drawing.Point(160, 198);
            this.txtbx密碼.Name = "txtbx密碼";
            this.txtbx密碼.Size = new System.Drawing.Size(409, 35);
            this.txtbx密碼.TabIndex = 22;
            this.txtbx密碼.UseSystemPasswordChar = true;
            // 
            // txtxbx帳號
            // 
            this.txtxbx帳號.Font = new System.Drawing.Font("Lucida Fax", 13.97015F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxbx帳號.Location = new System.Drawing.Point(160, 134);
            this.txtxbx帳號.Name = "txtxbx帳號";
            this.txtxbx帳號.Size = new System.Drawing.Size(409, 35);
            this.txtxbx帳號.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(72, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 31);
            this.label1.TabIndex = 20;
            this.label1.Text = "密碼：";
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.OliveDrab;
            this.btnLogIn.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(243, 319);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(159, 47);
            this.btnLogIn.TabIndex = 19;
            this.btnLogIn.Text = "登入";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(72, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 18;
            this.label2.Text = "帳號：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(160, 240);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "顯示密碼";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // 登入頁
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::首頁.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 584);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbl提示字);
            this.Controls.Add(this.txtbx密碼);
            this.Controls.Add(this.txtxbx帳號);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "登入頁";
            this.Text = "登入頁";
            this.Load += new System.EventHandler(this.登入頁_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lbl提示字;
        private System.Windows.Forms.TextBox txtbx密碼;
        private System.Windows.Forms.TextBox txtxbx帳號;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}