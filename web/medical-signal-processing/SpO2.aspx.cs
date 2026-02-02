using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using myTools;
using System.Data;


public partial class SpO2HR : System.Web.UI.Page
{
    bool IsClose = false;
    OleDbConnectionStringBuilder ConnString = null;
    OleDbConnection conn;
    OleDbCommand cmd;
    string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
    int i;
    string dbVer;
    string ECG;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text =(string) Session["userName"];
        //Image1.ImageUrl= @"..\..\ECG\ECG_20220621_113134.jpg";
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
        conn = new OleDbConnection(ConnString.ConnectionString);
        conn.Open();
        //Query CUS_ID of Specify Member
        string  sqlcmd = string.Format("select top 1 測量值 from 使用者紀錄 where 測量項目='ECG' and 身分證字號='{0}' order by 測量時間 desc ;", "A238948847");
        OleDbDataAdapter da = null;
        DataTable dt = new DataTable();
        da = new OleDbDataAdapter(sqlcmd, conn);
        da.Fill(dt);
        ECG=dt.Rows[0][0].ToString();
        dt.Dispose();
        if (da != null)
            da.Dispose();
        conn.Close();
        conn.Dispose();
        ECG = ECG.Substring(26);
        Image1.ImageUrl = @"..\..\ECG\" +ECG;
    }
   
    
    protected void ChartSpO2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < ChartSpO2.Series[0].Points.Count; i++)
        {
            //如果數列的YValue的值>200的話，將數列的顏色變為紅色
            if (ChartSpO2.Series[0].Points[i].YValues[0] <= 90)
            {
                ChartSpO2.Series[0].Points[i].MarkerColor = System.Drawing.Color.Red;
            }
            else if(ChartSpO2.Series[0].Points[i].YValues[0] <= 94)
            {
                ChartSpO2.Series[0].Points[i].MarkerColor = System.Drawing.Color.Blue;
            }
        }
    }

    protected void ChartHR_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < ChartHR.Series[0].Points.Count; i++)
        {
            //如果數列的YValue的值>200的話，將數列的顏色變為紅色
            if (ChartHR.Series[0].Points[i].YValues[0] > 100)
            {
                ChartHR.Series[0].Points[i].MarkerColor = System.Drawing.Color.Red;
            }
            else if (ChartHR.Series[0].Points[i].YValues[0] >= 86)
            {
                ChartHR.Series[0].Points[i].MarkerColor = System.Drawing.Color.Blue;
            }
            else if (ChartHR.Series[0].Points[i].YValues[0] >= 60)
            {
                ChartHR.Series[0].Points[i].MarkerColor = System.Drawing.Color.Green;
            }
            else 
            {
                ChartHR.Series[0].Points[i].MarkerColor = System.Drawing.Color.Orange;
            }
        }
    }

    protected void GVspo2_DataBound(object sender, EventArgs e)
    {
        
    }

    protected void GVspo2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
                
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void ChartTem_DataBound(object sender, EventArgs e)
    {

    }

    protected void ChartHumi_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < ChartHumi.Series[0].Points.Count; i++)
        {
            if (ChartHumi.Series[0].Points[i].YValues[0] <= 60 && ChartHumi.Series[0].Points[i].YValues[0] >= 50)
            {
                ChartHumi.Series[0].Points[i].MarkerColor = System.Drawing.Color.Orange;
            }
        }
    }

    protected void ChartSpO2_Load(object sender, EventArgs e)
    {

    }
}