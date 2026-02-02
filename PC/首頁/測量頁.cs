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
using System.IO.Ports;
using System.Diagnostics;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using myTools;
using Microsoft.VisualBasic;
using System.Threading;
using ex3_3_pc;
//using System.Data.SqlClient;
using System.Data.OleDb;


namespace 首頁
{
    public partial class 測量頁 : Form
    {
        //BT 
        BluetoothAddress addr;
        BluetoothEndPoint ep;
        BluetoothClient clnt;
        BluetoothAddress[] MACs;
        Stream btStream;
        Thread RxBT;
        //
        delegate void DisplayG();
        delegate void FindHR();
        delegate void FindTemp();
        delegate void SpO2();
        SpO2 findSpO2;
        FindTemp findTemp;
        FindHR findHR;
        DisplayG dispG;
        ComPortConfigForm setupComPort;
        StringBuilder res, res2;
        int i, iS, iE, LenRead, len, len2, iR0, iR1, cnt, cnt2;
        int val, valHR, valT, val2, valHR2, valT2, val3;
        bool bBT, bCOM;
        List<byte> raw;
        string Item;
        List<int> iRaw;
        bool bRx;
        byte[] RxBuf, buffer;
        string b;
        int cmbBxBT = -1;
        double sigma = 1.0;
        const int bufLen = 2048;
        //bool bBT, bCOM;
        Stopwatch sw;
        //byte val;
        myWaveBMP myWave;
        Guid serviceClass;
        int i0;
        Image img, img2;
        //ACCESS
        OleDbConnectionStringBuilder ConnString = null;
        OleDbConnection conn;
        OleDbCommand cmd;
        string dbPath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\", dbName = "健康測量.accdb";
        string dbVer;
        private void COM_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            serialPortR.PortName = e.ClickedItem.Text;
            btnHR.Enabled = true;
            btnECG.Enabled = true;
            btnTemp.Enabled = true;
            btnSpO2.Enabled = true;
            bCOM = true;

        }

        private void serialPortR_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (bCOM && serialPortR.BytesToRead > 0)
            {
                len = serialPortR.Read(buffer, 0, buffer.Length);
                for (i = 0; i < len; i++)
                    raw.Add(buffer[i]);
                if (Item == "ECG")
                    BeginInvoke(dispG, new object[] { });
                //    timer1.Start();
                else if (Item == "HR")
                    BeginInvoke(findHR, new object[] { });
                else if (Item == "Temp")
                    BeginInvoke(findTemp, new object[] { });
                else if (Item == "SpO2")
                    BeginInvoke(findSpO2, new object[] { });
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortR.IsOpen)
                serialPortR.Close();
            serialPortR.Dispose();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bBT = false;
            bCOM = false;
            sw.Stop();
            Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
            Thread.Sleep(1000);
            //btnStop.Enabled = false;
            //btnSave.Enabled = true;
            if (serialPortR.IsOpen)
                serialPortR.Close();
            DisconnectBt();
            Application.DoEvents();
            timer1.Stop();
            btnECG.Enabled = true;
            btnHR.Enabled = true;
            btnTemp.Enabled = true;
            btnSpO2.Enabled = true;
        }

        private void 藍芽ToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            bBT = true;
            string b;
            int a = 0;
            b = e.ClickedItem.Text;
            while (a <= 藍芽ToolStripMenuItem.DropDownItems.Count - 1)
            {
                if (藍芽ToolStripMenuItem.DropDownItems[a].ToString() == b)
                {
                    cmbBxBT = a;
                    btnECG.Enabled = true;
                    btnHR.Enabled = true;
                    btnTemp.Enabled = true;
                    btnSpO2.Enabled = true;
                    return;
                }
                a++;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString();
            //if (Item == "ECG")
            //    showFiltering();
            Application.DoEvents();
            
        }

        private void btnHR_Click(object sender, EventArgs e)
        {
            Item = "HR";
            this.progressBarSpO2.Visible = true;
            this.progressBarSpO2.Maximum = 60;
            this.progressBarSpO2.Value = 1;
            if (buffer != null)
                buffer = null;
            buffer = new byte[serialPortR.ReadBufferSize];
            initialStart();
            if (bBT)
            {
                if (serialPortR.IsOpen)
                    serialPortR.Close();
                ConnectBtMedicalDevice();
                bBT = true;
                bCOM = false;
            }
            if (bCOM)
            {
                if (bBT)
                    DisconnectBt();
                serialPortR.Open();
                bBT = false;
                bCOM = true;
            }
            btnHR.Enabled = false;
            btnECG.Enabled = false;
            btnSpO2.Enabled = false;
            btnTemp.Enabled = false;
            Text = "Devicec is connected!";
            timer1.Start();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (serialPortR.IsOpen)
            //    serialPortR.Close();
            //bBT = true;
            //bCOM = false;
            //initialStart();
            //ConnectBtMedicalDevice();
            //timer1.Start();
        }

        private void setBar()
        {

        }
        private void btnTemp_Click(object sender, EventArgs e)
        {
            //    setBar();
            this.progressBarSpO2.Visible = true;
            this.progressBarSpO2.Maximum = 30;
            this.progressBarSpO2.Value = 1;
            Item = "Temp";
            lbl濕度測量中.Text = "";
            lbl溫度測量中.Text = "";
            lbl濕度Max.Text = "";
            lbl濕度Min.Text = "";
            lbl溫度Min.Text = "";
            lbl溫度Max.Text = "";
            if (buffer != null)
                buffer = null;
            buffer = new byte[serialPortR.ReadBufferSize];
            initialStart();
            if (bBT)
            {
                if (serialPortR.IsOpen)
                    serialPortR.Close();
                ConnectBtMedicalDevice();
                bBT = true;
                bCOM = false;
            }
            if (bCOM)
            {
                if (bBT)
                    DisconnectBt();
                serialPortR.Open();
                bBT = false;
                bCOM = true;
            }
            btnHR.Enabled = false;
            btnECG.Enabled = false;
            btnSpO2.Enabled = false;
            btnTemp.Enabled = false;
            Text = "Devicec is connected!";
            timer1.Start();
        }


        public 測量頁()
        {
            InitializeComponent();
            sw = new Stopwatch();
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
        private void configPorts()
        {
            COM.DropDownItems.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
            {
                if (COM.DropDownItems.Count > 0 && COM.DropDownItems[COM.DropDownItems.Count - 1].ToString().Contains(port))
                    continue;
                COM.DropDownItems.Add(port);
            }
            //comPortConfigToolStripMenuItem.Checked = cmboBxPort.Items.Count - 1;
            //btnGet.Enabled = true;
            //serialPortR.PortName = string.Format(comPortConfigToolStripMenuItem.Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dispG = new DisplayG(displayG);
            findHR = new FindHR(displayHR);
            findTemp = new FindTemp(displayTemp);
            findSpO2 = new SpO2(displaySpO2);
            raw = new List<byte>();
            //dispG2 = new DisplayG(displayG2);
            iRaw = new List<int>();
            res = new StringBuilder();
            res2 = new StringBuilder();
            configPorts();
            //res = new StringBuilder();
            setupComPort = new ComPortConfigForm(ref serialPortR);
            //buffer = new byte[serialPortR.ReadBufferSize];
            //
            bRx = false;
            bBT = false;
            bCOM = false;
        }

      
        void DisconnectBt()
        {
            if (clnt != null)
            {
                clnt.Close();
                clnt.Dispose();
                clnt = null;
            }
            if (RxBT != null)
                RxBT.Join();
        }
        private void COM_Click(object sender, EventArgs e)
        {
            configPorts();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            登入頁 fm2 = new 登入頁();
            fm2.ShowDialog();
            if(登入頁.user!=null)
                Text= 登入頁.user+" 登入中";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Text = "未登入使用者!不會紀錄資料";
            登入頁.user = null;
            登入頁.acc = null;
        }

        private void btnECG_Click(object sender, EventArgs e)
        {
            測量頁.ActiveForm.Size = new Size(850, 600);
            this.progressBarSpO2.Visible = true;
            this.progressBarSpO2.Maximum = 9000;
            this.progressBarSpO2.Value = 1;
            Item = "ECG";
            myTools.Filtering.initGaussian(sigma);
            len2 = Filtering.GaussianFilter.Length / 2;
            iR0 = 0;
            iR1 = -1;
            if (buffer != null)
                buffer = null;
            buffer = new byte[serialPortR.ReadBufferSize];
            initialStart();
            if (bBT)
            {
                if (serialPortR.IsOpen)
                    serialPortR.Close();
                ConnectBtMedicalDevice();
                bBT = true;
                bCOM = false;
            }
            if (bCOM)
            {
                if (bBT)
                    DisconnectBt();
                serialPortR.Open();
                bBT = false;
                bCOM = true;
            }
            if (!bBT && !bCOM)
                return;
            btnHR.Enabled = false;
            btnECG.Enabled = false;
            btnSpO2.Enabled = false;
            btnTemp.Enabled = false;
            Text = "Devicec is connected!";
            timer1.Start();
        }

        private void btnSpO2_Click(object sender, EventArgs e)
        {
            Item = "SpO2";
            this.progressBarSpO2.Visible = true;
            this.progressBarSpO2.Value = 60;
            this.progressBarSpO2.Value = 1;
            if (buffer != null)
                buffer = null;
            buffer = new byte[serialPortR.ReadBufferSize];
            initialStart();
            if (bBT)
            {
                if (serialPortR.IsOpen)
                    serialPortR.Close();
                ConnectBtMedicalDevice();
                bBT = true;
                bCOM = false;
            }
            if (bCOM)
            {
                if (bBT)
                    DisconnectBt();
                serialPortR.Open();
                bBT = false;
                bCOM = true;
            }
            btnHR.Enabled = false;
            btnECG.Enabled = false;
            btnSpO2.Enabled = false;
            btnTemp.Enabled = false;
            Text = "Devicec is connected!";
            timer1.Start();
        }

        private void comPortConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupComPort.ComPortConfig(ref serialPortR);
            setupComPort.ShowDialog();
        }

        private void 藍芽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];
            i = 0;
            藍芽ToolStripMenuItem.DropDownItems.Clear();
            foreach (BluetoothDeviceInfo device in devices)
            {
                藍芽ToolStripMenuItem.DropDownItems.Add(string.Format("{0}: {1}", device.DeviceName, device.DeviceAddress));
                MACs[i++] = device.DeviceAddress;
            }
            //cmbBxBT.SelectedIndex = 0;
            Cursor = Cursors.Arrow;
            //if (devices.Length > 0)
            //    btnRx.Enabled = true;
        }

        void ConnectBtMedicalDevice()
        {
            try
            {
                serviceClass = BluetoothService.SerialPort;
                addr = MACs[cmbBxBT];
                if (ep != null)
                    ep = null;
                ep = new BluetoothEndPoint(addr, serviceClass);
                if (clnt != null)
                {
                    clnt.Close();
                    clnt.Dispose();
                    clnt = null;
                }
                clnt = new BluetoothClient();
                clnt.Connect(ep);
                btStream = clnt.GetStream();
                RxBuf = new byte[bufLen];
                RxBT = new Thread(ReceivingPacket);
                RxBT.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Connecting BlueTooth!");
            }
        }
        private void initialStart()
        {
            //btnStop.Enabled = true;
            //btnRx.Enabled = false;
            //btnSave.Enabled = false;
            iS = 0;
            iE = 0;
            cnt = 0;
            cnt2 = 0;
            if (Item == "ECG")
            {
                myWave = new myWaveBMP(750);
                if (img != null)
                {
                    img.Dispose();
                    img = null;
                }
                img = myWave.getBMP();
                pictureBox1.Image = img;
            }
            //pictureBox2.Image = img2;
            raw.Clear();
            res.Clear();
            sw.Restart();
        }
        private void ReceivingPacket()
        {
            while (bBT)
            {
                LenRead = 0;
                if (!btStream.CanRead)
                    break;
                else if (bBT)
                    LenRead = btStream.Read(RxBuf, 0, bufLen);
                else
                    break;
                if (LenRead == 0)
                    continue;
                for (i0 = 0; i0 < LenRead; i0++)
                    raw.Add(RxBuf[i0]);
                if (Item == "ECG")
                    BeginInvoke(dispG, new object[] { });
                else if (Item == "HR")
                    BeginInvoke(findHR, new object[] { });
                else if (Item == "Temp")
                    BeginInvoke(findTemp, new object[] { });
                else if (Item == "SpO2")
                    BeginInvoke(findSpO2, new object[] { });
            }

        }
        bool go;
        //string conStr = "Data Source=LAPTOP-HNL37TP2;Initial Catalog=醫療訊號;Integrated Security=True";
        private void 寫入資料()
        {
            
            conn = new OleDbConnection(ConnString.ConnectionString);
            conn.Open();
            //Query CUS_ID of Specify Member
            //string v0 = dataGV檢驗.Rows[i].Cells[0].Value.ToString();
            if (Item == "HR")
            {
                string sqlcmd = string.Format("INSERT INTO 使用者紀錄 VALUES('{0}', '{1}', 'HR', '{2}');", 登入頁.acc, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), HRValue);
                OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            else if (Item == "SpO2")
            {
                string sqlcmd = string.Format("INSERT INTO 使用者紀錄 VALUES('{0}', '{1}', 'SpO2', '{2}');", 登入頁.acc, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), SpO2Value);
                OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            else if (Item == "Temp")
            {
                if (Huy != 0)
                {
                    string sqlcmd = string.Format("INSERT INTO 使用者紀錄 VALUES('{0}', '{1}', '濕度', '{2}');", 登入頁.acc, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Huy);
                    OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                   cmd.ExecuteNonQuery();
                 
                }
                if (Temp != 0)
                {
                 
                    string sqlcmd = string.Format("INSERT INTO 使用者紀錄 VALUES('{0}', '{1}', '溫度', '{2}');", 登入頁.acc, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Temp);
                    OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }

            }
            else if (Item == "ECG")
            {
                string sqlcmd = string.Format("INSERT INTO 使用者紀錄 VALUES('{0}', '{1}', 'ECG', '{2}');", 登入頁.acc, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ECGpath);
                OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            Item = "";
        }
        int HRValue,SpO2Value,Temp,Huy;
        string ECGpath;
        private void displaySpO2()
        {
            iE = raw.Count - 1;
            while (iS <= iE - 2)
            {

                if (raw[iS] == 53 && raw[iS + 1] != 0 && raw[iS + 2] == 53)
                {
                    cnt++;
                    val += raw[iS+1];
                    progressBarSpO2.Increment(1);
                    if (cnt % 60 == 0)
                    {
                        lblSpO2.Text = string.Format("SpO2：{0} %", val / 60);
                        SpO2Value = val / 60;
                        cnt = 0;
                        val = 0;
                        bBT = false;
                        bCOM = false;
                        sw.Stop();
                        //Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
                        Thread.Sleep(1000);
                        //btnStop.Enabled = false;
                        //btnSave.Enabled = true;
                        if (serialPortR.IsOpen)
                            serialPortR.Close();
                        DisconnectBt();
                        //Application.DoEvents();
                        timer1.Stop();
                        Text = 登入頁.user+" 登入中";
                        btnECG.Enabled = true;
                        btnHR.Enabled = true;
                        btnTemp.Enabled = true;
                        btnSpO2.Enabled = true;
                        if(登入頁.user!=null)
                           寫入資料();
                        progressBarSpO2.Increment(1);
                        if (this.progressBarSpO2.Value == 60)
                            progressBarSpO2.Visible = false;
                        break;
                    }
                    else
                    {
                        lblSpO2.Text = string.Format("測量中..");
                    }
                    iS++;

                }
                iS++;
            }
            iS++;

        }
    
        private void displayHR()
        {
            iE = raw.Count - 1;
            while (iS <= iE - 2)
            {

                if (raw[iS] == 11 && raw[iS + 1] != 0 && raw[iS + 2] == 11)
                {
                    iS++;
                    cnt++;
                    valHR += raw[iS];
                    progressBarSpO2.Increment(1);
                    if (cnt % 60 == 0)
                    {
                        lblHR測量值.Text = string.Format(" {0} beats/min", valHR / 60);
                        HRValue = valHR / 60;
                        cnt = 0;
                        valHR = 0;
                        bBT = false;
                        bCOM = false;
                        sw.Stop();
                        //Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
                        Thread.Sleep(1000);
                        //btnStop.Enabled = false;
                        //btnSave.Enabled = true;
                        if (serialPortR.IsOpen)
                            serialPortR.Close();
                        DisconnectBt();
                        //Application.DoEvents();
                        timer1.Stop();
                        Text = 登入頁.user + " 登入中";
                        btnECG.Enabled = true;
                        btnHR.Enabled = true;
                        btnTemp.Enabled = true;
                        btnSpO2.Enabled = true;
                        progressBarSpO2.Increment(1);
                        if (this.progressBarSpO2.Value == 60)
                            progressBarSpO2.Visible = false;
                        if (登入頁.user != null)
                            寫入資料();
                        break;
                    }
                    else
                    {
                        lblHR測量值.Text = string.Format("測量中..");
                    }
                    iS++;
                }
                iS++;
            }
            iS++;

        }
        private void displayTemp()
        {
            iE = raw.Count - 1;
            while (iS <= iE - 5)
            {

                if (raw[iS] == 48 && raw[iS + 1] != 0 && raw[iS + 2] != 0 && raw[iS + 3] !=0  && raw[iS + 4] != 0 && raw[iS + 5] == 48)
                {
                    valT = raw[iS + 1];  
                    res.AppendFormat("{0}", (char)valT);
                    valT = raw[iS + 2];
                    res.AppendFormat("{0}", (char)valT);
                    val += int.Parse(res.ToString());
                    getMaxMin(res.ToString());
                    res.Clear();
                    cnt++;
                    valT = raw[iS + 3];
                    res.AppendFormat("{0}", (char)valT);
                    valT = raw[iS + 4];
                    res.AppendFormat("{0}", (char)valT);
                    val2 += int.Parse(res.ToString());
                    getMaxMin2(res.ToString());
                    res.Clear();
                    progressBarSpO2.Increment(1);
                    if (cnt % 30 == 0)
                    {
                        lbl濕度測量中.Text = string.Format(" {0} %", val / 30);
                        Huy = val / 30;
                        cnt = 0;
                        val = 0;
                        max = 0;
                        min = 0;
                        lbl溫度測量中.Text = string.Format(" {0} ℃", val2 / 30);
                        Temp = val2 / 30;
                        cnt2 = 0;
                        val2 = 0;
                        max2 = 0;
                        min2 = 0;
                        res.Clear();
                        bBT = false;
                        bCOM = false;
                        sw.Stop();
                        //Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
                        Thread.Sleep(1000);
                        raw.Clear();
                        res.Clear();
                        //btnStop.Enabled = false;
                        //btnSave.Enabled = true;
                        if (serialPortR.IsOpen)
                            serialPortR.Close();
                        DisconnectBt();
                        //Application.DoEvents();
                        timer1.Stop();
                        Text = 登入頁.user + " 登入中";
                        btnECG.Enabled = true;
                        btnHR.Enabled = true;
                        btnTemp.Enabled = true;
                        btnSpO2.Enabled = true;
                        if (登入頁.user != null)
                            寫入資料();
                        progressBarSpO2.Increment(1);
                        if (this.progressBarSpO2.Value == 30)
                            progressBarSpO2.Visible = false;
                        break;
                        
                    }
                    else
                    {
                        lbl濕度測量中.Text = string.Format("測量中..");
                        lbl溫度測量中.Text = string.Format("測量中..");
                        
                        Application.DoEvents();
                    }
                    iS += 5;
                }
                iS++;
            }
            iS++;
        }

        int max, min, max2, min2;
        
        private void  getMaxMin(string s)
        {
            int num = int.Parse(s);
            if (min == 0)
                min = num;
            if (num > max)
                max = num;
            if (num < min)
                min = num;
            lbl濕度Max.Text = string.Format(" {0} %", max);
            lbl濕度Min.Text = string.Format(" {0} %", min);

        }
        private void getMaxMin2(string s)
        {
            int num = int.Parse(s);
            if (min2 == 0)
                min2 = num;
            if (num > max2)
                max2 = num;
            if (num < min2)
                min2 = num;         
            lbl溫度Max.Text = string.Format(" {0} ℃", max2);
            lbl溫度Min.Text = string.Format(" {0} ℃", min2);

        }
        private void displayG()
        {
            iE = raw.Count - 1;
            while (iS <= iE - 6)
            {
                if (raw[iS] == 255 && raw[iS + 1] == 255 && raw[iS + 4] == 254 && raw[iS + 5] == 254)
                {
                    val = raw[iS + 3] * 256 + raw[iS + 2];
                    iRaw.Add(val);
                    cnt++;
                    progressBarSpO2.Increment(1);
                    //showFiltering();
                    if (cnt % 9000 == 0)
                    {
                        progressBarSpO2.Increment(1);
                        if (this.progressBarSpO2.Value == 9000)
                            progressBarSpO2.Visible = false;
                        //label1.Text = string.Format("HR:{0}", valHR / 60);
                        HRValue = valHR / 60;
                        cnt = 0;
                        valHR = 0;
                        bBT = false;
                        bCOM = false;
                        sw.Stop();
                        //Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
                        Thread.Sleep(1000);
                        //btnStop.Enabled = false;
                        //btnSave.Enabled = true;
                        if (serialPortR.IsOpen)
                            serialPortR.Close();
                        DisconnectBt();
                        //Application.DoEvents();
                        timer1.Stop();
                        Text = 登入頁.user + " 登入中";
                        btnECG.Enabled = true;
                        btnHR.Enabled = true;
                        btnTemp.Enabled = true;
                        btnSpO2.Enabled = true;
                        //寫入資料();serialPortR.Close();
                        ECG紀錄();
                        if (登入頁.user != null)
                            寫入資料();

                        break;
                    }
                    iS += 5;
                }
              
                iS++;
              
            }
            showFiltering();
            //if (img != null)
            //{
            //    img.Dispose();
            //    img = null;
            //}
            //img = myWave.getBMP();
            //pictureBox1.Image = img;
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
                    val = (int)Filtering.doGaussian(iRaw, iR0);
                    myWave.update(val);
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
        private void ECG紀錄()
        {
            /* 判段等於false 表示資料夾不存在 */
            string Folder_Name = "ECG";
            if (Directory.Exists(@"D:\醫療訊號測量\" + Folder_Name) == false)
            {
                /* 資料夾不存在 新增資料夾 */
                Directory.CreateDirectory(@"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\" + Folder_Name);
            }
            saveFileDialog1.FileName = string.Format("ECG_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.jpg",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    return;
            img.Save(@"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\ECG\" + saveFileDialog1.FileName);

            //儲存成文字檔
            /*StringBuilder sb = new StringBuilder();
            for (int i = 0; i < raw.Count; i++)
                sb.AppendLine(raw[i].ToString());
            File.AppendAllText(@"D:\醫療訊號測量\ECG\"+saveFileDialog1.FileName, sb.ToString());*/
            ECGpath = @"D:\醫療訊號\醫療訊號期末\網頁\醫療訊號\ECG\"+saveFileDialog1.FileName;
        }
    }
   
}
