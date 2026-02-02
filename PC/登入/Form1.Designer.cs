namespace 登入
{
    partial class Form1
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtxbx帳號 = new System.Windows.Forms.TextBox();
            this.txtbx密碼 = new System.Windows.Forms.TextBox();
            this.lbl提示字 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.OliveDrab;
            this.btnLogIn.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(290, 300);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(159, 47);
            this.btnLogIn.TabIndex = 12;
            this.btnLogIn.Text = "登入";
            this.btnLogIn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(190, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "帳號：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(190, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "密碼：";
            // 
            // txtxbx帳號
            // 
            this.txtxbx帳號.Font = new System.Drawing.Font("Lucida Fax", 13.97015F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxbx帳號.Location = new System.Drawing.Point(290, 116);
            this.txtxbx帳號.Name = "txtxbx帳號";
            this.txtxbx帳號.Size = new System.Drawing.Size(248, 35);
            this.txtxbx帳號.TabIndex = 14;
            // 
            // txtbx密碼
            // 
            this.txtbx密碼.Font = new System.Drawing.Font("Lucida Fax", 13.97015F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx密碼.Location = new System.Drawing.Point(290, 179);
            this.txtbx密碼.Name = "txtbx密碼";
            this.txtbx密碼.Size = new System.Drawing.Size(248, 35);
            this.txtbx密碼.TabIndex = 15;
            // 
            // lbl提示字
            // 
            this.lbl提示字.AutoSize = true;
            this.lbl提示字.BackColor = System.Drawing.Color.Transparent;
            this.lbl提示字.Font = new System.Drawing.Font("Lucida Fax", 15.04478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl提示字.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl提示字.Location = new System.Drawing.Point(315, 244);
            this.lbl提示字.Name = "lbl提示字";
            this.lbl提示字.Size = new System.Drawing.Size(122, 31);
            this.lbl提示字.TabIndex = 16;
            this.lbl提示字.Text = "輸入錯誤";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNew.Font = new System.Drawing.Font("Lucida Fax", 12.89552F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnNew.Location = new System.Drawing.Point(290, 352);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(159, 47);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "新增帳號";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::登入.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(747, 528);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbl提示字);
            this.Controls.Add(this.txtbx密碼);
            this.Controls.Add(this.txtxbx帳號);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtxbx帳號;
        private System.Windows.Forms.TextBox txtbx密碼;
        private System.Windows.Forms.Label lbl提示字;
        private System.Windows.Forms.Button btnNew;
    }
}

