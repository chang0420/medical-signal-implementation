using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;



namespace 首頁
{
    public partial class 註冊 : Form
    {
        //ACCESS
        OleDbConnectionStringBuilder ConnString = null;
        OleDbConnection conn;
        OleDbCommand cmd;
        string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
        string dbVer;
        int i;
        public 註冊()
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

        private void txtbxID_Enter(object sender, EventArgs e)
        {

        }

        private void txtbxID_MouseLeave(object sender, EventArgs e)
        {
            if (txtbxID.Text.Length != 0 && txtbxID.Text.Length == 10)
            {
                string ID = txtbxID.Text;
                bool IDcheck = Regex.IsMatch(ID, @"[A-Z][1-2]{1}[0-9]{8}$");
                if (IDcheck)
                {
                    ID = ID.Substring(1, 1);
                    if (ID == "2")
                    {

                        cmbobx性別.Text = "女";
                    }
                    else
                    {

                        cmbobx性別.Text = "男";
                    }
                    //sqlcmd = Cmd0 + string.Format(cmds[0], txtbxID.Text);
                }
                else
                {
                    lblXXID.Text = "身分證格式錯誤！";
                    return;
                }

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtbxName.Text == "")
            {
                lblXXAddress.Text = "請輸入姓名！";
                lblXXAddress.Visible = true;
                return;
            }

            if (txtbxID.Text.Length != 0 && txtbxID.Text.Length == 10)
            {
                string ID = txtbxID.Text;
                bool IDcheck = Regex.IsMatch(ID, @"[A-Z][1-2]{1}[0-9]{8}$");
                if (IDcheck)
                {
                    ID=ID.Substring(1, 1);
                    if(ID=="2")
                    {
                     
                        cmbobx性別.Text = "女";
                    }
                    else
                    {
                        
                        cmbobx性別.Text = "男";
                    }
                    //sqlcmd = Cmd0 + string.Format(cmds[0], txtbxID.Text);
                }
                else
                {
                    lblXXID.Text = "身分證格式錯誤！";
                    lblXXID.Visible = true;
                    return;
                }
                
            }

            else
            {
                lblXXID.Text = "請輸入身分證字號";
                lblXXID.Visible = true;
                return;
            }
            if(BD.Value.ToString() == BD.MaxDate.ToString())
            {
                lblXXBD.Text = "請選擇生日！";
                lblXXBD.Visible = true;
                return;
            }
            if (txtbxAddress.Text == "")
            {
                lblXXBD.Text = "請輸入地址！";
                lblXXAddress.Visible = true;
                return;
            }
            if (txtbxEmail.Text == "")
            {
                lblXXBD.Text = "請輸入信箱！";
                lblXXEmail.Visible = true;
                return;
            }
            conn = new OleDbConnection(ConnString.ConnectionString);
            conn.Open();
            string sqlcmd = string.Format("INSERT INTO 使用者基本資料 VALUES('{0}', '{1}', '{2}', '{3}','{4}', '{5}', ' ');",txtbxID.Text,txtbxName.Text,cmbobx性別.Text,BD.Value.ToString("yyyy/MM/dd"),txtbxAddress.Text,txtbxEmail.Text);
            OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Close();
            
        }
       
    }
}
