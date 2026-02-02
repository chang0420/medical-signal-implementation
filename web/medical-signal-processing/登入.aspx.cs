using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class 登入 : System.Web.UI.Page
{
    bool IsClose = false;
    OleDbConnectionStringBuilder ConnString = null;
    OleDbConnection conn;
    OleDbCommand cmd;
    string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
    int i;
    string dbVer;
    string user,userID;
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
        try
        {
            conn = new OleDbConnection(ConnString.ConnectionString);
            conn.Open();
            //Query CUS_ID of Specify Member
            string sqlcmd = string.Format("select 使用者姓名 from 使用者基本資料 where  身分證字號='{0}' and 電子信箱='{1}' ;", txtbxP.Text, txtbxAcc.Text);
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            da = new OleDbDataAdapter(sqlcmd, conn);
            da.Fill(dt);
            user = dt.Rows[0][0].ToString();
            dt.Dispose();
            if (da != null)
                da.Dispose();
            conn.Close();
            conn.Dispose();
            Session["userName"] = user;
            Session["userID"] = txtbxP.Text;
            Response.Redirect("SpO2.aspx");
        }
        catch
        {
            Label3.Visible = true;
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    protected void txtbxP_TextChanged(object sender, EventArgs e)
    {
        if(txtbxP.Text=="undifine")
        {
            txtbxP.Text = "";
        }
    }

    protected void btnNewAc_Click(object sender, EventArgs e)
    {
        Response.Redirect("註冊.aspx");
    }
}