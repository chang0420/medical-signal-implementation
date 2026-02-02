using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using myTools;
using System.Data.SqlClient;
using linebotdemo;
namespace ex01
{
    public partial class Form1 : Form
    {
        delegate void dispg();
        dispg DispG;
        int iStart, iEnd, len, i, len2, iR0, iR1;
        byte[] buf;
        List<byte> raw;
        List<int> iRaw;
        Pen PG;
        Graphics g1;
        Bitmap bmp;
        int val, val2;
        double sigma = 1.0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            displayG();
            
        }

        myWaveBMP myWave, myWave2;
        Image img, img2;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i =int.Parse(textBox1.Text);
          
            iStart = 0;
            iEnd = -1;
            sigma = 1;
            myTools.Filtering.initGaussian(sigma);
            len2 = Filtering.GaussianFilter.Length / 2;
            iR0 = 0;
            iR1 = -1;
            //btnStop.Enabled = true;
            //btnSave.Enabled = false;
            //raw.Clear();
            myWave = new myTools.myWaveBMP(750);
            //myWave2 = new myTools.myWaveBMP(750);
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
            timer1.Start();
        }
        string fileName;

        private void Form1_Load(object sender, EventArgs e)
        {
            raw = new List<byte>();
            iRaw = new List<int>();
            //buf = new byte[serialPortR.ReadBufferSize];
            PG = new Pen(Color.Green, 2);
            尋找檔案();
            讀取檔案();
            iStart = 0;
            iEnd = -1;
            sigma = 1;
            myTools.Filtering.initGaussian(sigma);
            len2 = Filtering.GaussianFilter.Length / 2;
            iR0 = 0;
            iR1 = -1;
            //btnStop.Enabled = true;
            //btnSave.Enabled = false;
            //raw.Clear();
            myWave = new myTools.myWaveBMP(750);
            //myWave2 = new myTools.myWaveBMP(750);
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
            timer1.Start();
        }
        string conStr = "Data Source=LAPTOP-HNL37TP2;Initial Catalog=醫療訊號;Integrated Security=True";
        private void 尋找檔案()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = @"select top 1 測量值 from 使用者紀錄 where 測量項目='ECG' order by 測量時間 desc ;";
            SqlCommand cmd = new SqlCommand(sql, con);
            IDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            fileName = dt.Rows[0][0].ToString();
            cmd.ExecuteNonQuery();
            con.Close();
          
        }
        private void 讀取檔案()
        {
            //string path = "C:\\File\\file.txt";
            //using (StreamReader readtext = new StreamReader(path))
            //{
            //    string readText = readtext.ReadLine();
            //    Console.WriteLine(readText);
            //}
            //if (openFileDialog1.ShowDialog() != DialogResult.OK)
            //    return;
            string[] strs = File.ReadAllLines(fileName);
            byte bt;
            foreach (string str in strs)
            {
                bt = byte.Parse(str);
                raw.Add(bt);
            }
        }
        int cnt;
        private void displayG()
        {
            //bmp = new Bitmap(raw.Count, 340);
            iEnd = raw.Count - 1;
            while (iStart <= iEnd - 5)
            {
                if (raw[iStart] == 255 && raw[iStart + 1] == 255 && raw[iStart + 4] == 254 && raw[iStart + 5] == 254)
                {
                    val = raw[iStart + 3] * 256 + raw[iStart + 2];
                    iRaw.Add(val);
                    cnt++;
                    //showFiltering();
                    //if (cnt % 9000 == 0)
                    //{
                    //    timer1.Stop();
                    //}
                        //myWave.update(val);
                        iStart += 5;
                }
                iStart++;
            }
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
            showFiltering();
            //
            //if (iStart > iEnd - 5)
            //{
            //    timer1.Stop();
            //    //    img = myWave.getBMP();
            //    //    pictureBox1.Image = img;
            //    //    Application.DoEvents();
            //}


        }
        private void showFiltering()
        {
            if (iRaw.Count < 1)
                return;
            iR1 = iRaw.Count - 1;
            if (iR0 < len2 + 1)
            {
                while (iR0 < len2 + 1)
                {
                    myWave.update(iRaw[iR0]);
                    iR0++;
                }
            }
            else
            {
                while (iR0 > len2 && iR1 - iR0 > 2 * len2)
                {
                    val2 = (int)Filtering.doGaussian(iRaw, iR0);
                    myWave.update(val2);
                    iR0++;
                }
            }
            if (img != null)
            {
                img.Dispose();
                img = null;
            }

            img = myWave.getBMP();
            pictureBox1.Image = img;
            Application.DoEvents();
        }
    }
}
