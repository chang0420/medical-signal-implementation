using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class 註冊 : System.Web.UI.Page
{
    bool IsClose = false;
    OleDbConnectionStringBuilder ConnString = null;
    OleDbConnection conn;
    OleDbCommand cmd;
    string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
    int i;
    string dbVer;
    string user;
    string 性別;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
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

        if (txtbxName.Text == "")
        {
            lblName.Text = "請輸入姓名！";
            lblName.Visible = true;
            return;
        }

        if (txtbxID.Text.Length != 0 && txtbxID.Text.Length == 10)
        {
            string ID = txtbxID.Text;
            bool IDcheck = Regex.IsMatch(ID, @"[A-Z][1-2]{1}[0-9]{8}$");
            if (IDcheck)
            {
                性別 = ID.Substring(1, 1);
                if (ID == "2")
                {
                    性別 = "女";
                }
                else
                {

                    性別 = "男";
                }
                //sqlcmd = Cmd0 + string.Format(cmds[0], txtbxID.Text);
            }
            else
            {
                lblID.Text = "身分證格式錯誤！";
                lblID.Visible = true;
                return;
            }

        }

        else
        {
            lblID.Text = "請輸入身分證字號";
            lblID.Visible = true;
            return;
        }
        if (txtbxBD.Text=="")
        {
            lblBD.Text = "請依照格式輸入！";
            lblBD.Visible = true;
            return;
        }
        if (txtbxAddress.Text == "")
        {
            lblAddress.Text = "請輸入地址！";
            lblAddress.Visible = true;
            return;
        }
        if (txtbxEMail.Text == "")
        {
            lblEmail.Text = "請輸入信箱！";
            lblEmail.Visible = true;
            return;
        }
        conn = new OleDbConnection(ConnString.ConnectionString);
        conn.Open();
        string sqlcmd = string.Format("INSERT INTO 使用者基本資料 VALUES('{0}', '{1}', '{2}', '{3}','{4}', '{5}', ' ');", txtbxID.Text, txtbxName.Text,性別, txtbxBD.Text, txtbxAddress.Text, txtbxEMail.Text);
        OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        Response.Redirect("登入.aspx");

    }
    string Email, MyName;
    public void sendGmail()
    {
        string t1 = string.Format("{0}", DateTime.Now);
        Email = txtbxEMail.Text;
        MyName = txtbxName.Text;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("enya0874@gmail.com", "健康紀錄小幫手");//前面是發信email後面是顯示的名稱
        mail.To.Add(Email);//收信者email
        mail.Priority = MailPriority.Normal; //設定優先權
        mail.Subject = "帳號註冊成功"; //標題
        mail.Body = "您好," + MyName + " 先生/小姐<br/>您已在" + t1 + "完成健康紀錄帳號註冊，祝平安健康。";//內容
        mail.IsBodyHtml = true; //內容使用html
        SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);//設定gmail的smtp (這是google的)
        MySmtp.Credentials = new System.Net.NetworkCredential("demo@gmail.com", "demodemo");//您在gmail的帳號密碼
        MySmtp.EnableSsl = true;//開啟ssl
        MySmtp.Send(mail); //發送郵件
        MySmtp = null; //放掉宣告出來的MySmtp
        mail.Dispose(); //放掉宣告出來的mail
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("登入.aspx");
    }
}
   
