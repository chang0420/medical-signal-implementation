using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 首頁
{
    public partial class 登入頁 : Form
    {
        //ACCESS
        OleDbConnectionStringBuilder ConnString = null;
        OleDbConnection conn;
        OleDbCommand cmd;
        string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
        string dbVer;
        int i;
        public static string user,acc;
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtxbx帳號.Text == "" && txtxbx帳號.Text == "")
            {
                lbl提示字.Text = "帳號密碼不可為空!";
                lbl提示字.Visible = true;
                return;
            }
            if (txtbx密碼.Text=="")
            {
                lbl提示字.Text = "密碼不可為空!";
                lbl提示字.Visible = true;
                return;
            }
            if (txtxbx帳號.Text == "")
            {
                lbl提示字.Text = "帳號不可為空!";
                lbl提示字.Visible = true;
                return;
            }
            try
            {
                conn = new OleDbConnection(ConnString.ConnectionString);
                conn.Open();
                //Query CUS_ID of Specify Member
                string sqlcmd = string.Format("select 使用者姓名,身分證字號 from 使用者基本資料 where 電子信箱='{0}' and 身分證字號='{1}';",txtxbx帳號.Text,txtbx密碼.Text);
                OleDbDataAdapter da = null;
                DataTable dt = new DataTable();
                da = new OleDbDataAdapter(sqlcmd, conn);
                da.Fill(dt);
                user = dt.Rows[0][0].ToString();
                acc = dt.Rows[0][1].ToString();
                dt.Dispose();
                if (da != null)
                    da.Dispose();
                conn.Close();
                conn.Dispose();
                Close();
            }
            catch
            {
                lbl提示字.Text = "請再重新輸入一次!";
                lbl提示字.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtbx密碼.UseSystemPasswordChar ^= true;
        }

        private void 登入頁_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            註冊 fm2 = new 註冊();
            fm2.ShowDialog();
        }

        public 登入頁()
        {
            InitializeComponent();
            ConnString = new OleDbConnectionStringBuilder();
            ConnString.DataSource = dbPath + dbName;
            i = dbName.LastIndexOf(".");
            dbVer = dbName.Substring(i + 1);
            dbName.ToLower();
            if (dbVer.CompareTo("mdb") == 0)
                ConnString.Provider = "Microsoft.Jet.OleDB.4.0";
            else if (dbVer.CompareTo("accdb") == 0)
                ConnString.Provider = "Microsoft.ACE.OleDB.12.0";
            else
            {
                //MessageBox.Show("Error for ACESS's format :" + dbVer, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
