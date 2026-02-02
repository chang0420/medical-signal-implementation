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
using ex3_3_pc;
using System.Threading;

namespace ex02
{
    public partial class Form1 : Form
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
        DisplayG dispG;
        DisplayG dispG2;
        ComPortConfigForm setupComPort;
        StringBuilder res,res2;
        int i, iS, iE, LenRead, len, iS2, iE2,cnt,cnt2,n,n2;
        int val, valHR, valT,val2,valHR2,valT2;
        List<byte> raw,raw2;
        bool bRx;
        byte[] RxBuf, buffer;
        const int bufLen = 2048;
        //bool bBT, bCOM;
        Stopwatch sw;
        //byte val;
        myWaveBMP myWave, myWave2;
        Guid serviceClass;
        int i0;
        Image img,img2;
        private void timer1_Tick(object sender, EventArgs e)
        {//顯使正在接收資料
            Text = DateTime.Now.ToString();
            Application.DoEvents();
        }
        void ConnectBtMedicalDevice()
        {
            try
            {
                serviceClass = BluetoothService.SerialPort;
                addr = MACs[cmbBxBT.SelectedIndex];
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Connecting BlueTooth!");
            }
        }
        private void ReceivingPacket()
        {
            try
            {
                while (bRx)
                {
                    LenRead = 0;
                    if (btStream.CanRead)
                        LenRead = btStream.Read(RxBuf, 0, bufLen);
                    if (LenRead == 0)
                        continue;
                    for (i0 = 0; i0 < LenRead; i0++)
                        raw2.Add(RxBuf[i0]);
                    BeginInvoke(dispG2, new object[] { });
                }
            }
            catch(Exception ex)
            {
                Text = ex.ToString();
            }
            finally
            {

            }
        }
        private void btnRx_Click(object sender, EventArgs e)
        {
            
            serialPortR.PortName = cmboBxPort.SelectedItem.ToString();
            if (buffer != null)
                buffer = null;
            buffer = new byte[serialPortR.ReadBufferSize];
            initialStart();
            bRx = true;
            ConnectBtMedicalDevice();
            serialPortR.Open();
            Text = "Devicec is connected!";
            timer1.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            serialPortR.Close();
            saveFileDialog1.FileName = string.Format("BT_COM2PC_{0:D4}{1:D2}{2:D2}_{3_D2}{4:D2}{5:D2}_{6}ms.txt",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, sw.ElapsedMilliseconds);
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < raw.Count; i++)
                sb.AppendLine(raw[i].ToString());
            File.AppendAllText(saveFileDialog1.FileName, sb.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            setupComPort.ComPortConfig(ref serialPortR);
            setupComPort.ShowDialog();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bRx = false;
            btnRx.Enabled = true;
            btnStop.Enabled = false;
            btnSave.Enabled = true;
            if (serialPortR.IsOpen)
                serialPortR.Close();
            DisconnectBt();
            sw.Stop();
            timer1.Stop();
            Text += string.Format("\r\n\r\nDevice is disconneted! Elapsed {0}ms: Got {1} measuremens ({2} bytes/s)!!", sw.ElapsedMilliseconds, raw.Count, raw.Count * 1000 / sw.ElapsedMilliseconds);
            Application.DoEvents();
        }
        void DisconnectBt()
        {
            if(clnt!=null)
            {
                clnt.Close();
                clnt.Dispose();
                clnt = null;
            }
            if (RxBT != null)
                RxBT.Join();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortR.IsOpen)
                serialPortR.Close();
            serialPortR.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dispG = new DisplayG(displayG);
            raw = new List<byte>();
            dispG2 = new DisplayG(displayG2);
            raw2 = new List<byte>();
            res = new StringBuilder();
            res2 = new StringBuilder();
            configPorts();
            //res = new StringBuilder();
            setupComPort = new ComPortConfigForm(ref serialPortR);
            //buffer = new byte[serialPortR.ReadBufferSize];
            //
            bRx = false;
        }
        public Form1()
        {
            InitializeComponent();
            sw = new Stopwatch();
        }
        private void configPorts()
        {
            cmboBxPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
            {
                if (cmboBxPort.Items.Count > 0 && cmboBxPort.Items[cmboBxPort.Items.Count - 1].ToString().Contains(port))
                    continue;
                cmboBxPort.Items.Add(port);
            }
            cmboBxPort.SelectedIndex = cmboBxPort.Items.Count - 1;
            btnGet.Enabled = true;
            serialPortR.PortName = cmboBxPort.SelectedIndex.ToString();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            configPorts();
        }

        private void serialPortR_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (bRx && serialPortR.BytesToRead > 0)
            {
                len = serialPortR.Read(buffer, 0, buffer.Length);
                for (i = 0; i < len; i++)
                    raw.Add(buffer[i]);
                BeginInvoke(dispG, new object[] { });
            }
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            MACs = new BluetoothAddress[devices.Length];
            i = 0;
            cmbBxBT.Items.Clear();
            foreach(BluetoothDeviceInfo device in devices)
            {
                cmbBxBT.Items.Add(string.Format("{0}: {1}",device.DeviceName, device.DeviceAddress));
                MACs[i++] = device.DeviceAddress;
            }
            cmbBxBT.SelectedIndex = 0;
            Cursor = Cursors.Arrow;
            if (devices.Length > 0)
                btnRx.Enabled = true;
        }
        private void displayG()
        {
            iE = raw.Count - 1;
            while (iS <= iE - 6)
            {
                if (raw[iS] == 255 && raw[iS + 1] == 255 && raw[iS + 4] == 254 && raw[iS + 5] == 254)
                {
                    val = raw[iS + 3] * 256 + raw[iS + 2];
                    myWave.update(val);
                    iS += 5;
                }
                else if (raw[iS] ==11 && raw[iS + 1] !=0 && raw[iS + 2] == 255 && raw[iS+3]==255)
                {
                    iS++;
                    cnt++;
                    valHR += raw[iS];
                    if (cnt % 60 == 0)
                    {
                        label1.Text = string.Format("HR:{0}", valHR / 60);
                        cnt = 0;
                        valHR = 0;
                    }
                    //iS++;
                }
                else if(raw[iS]!=0&&raw[iS+1]!=0 && raw[iS + 2] == 13 && raw[iS + 3] == 10 )
                {
                    valT = raw[iS];
                    res.AppendFormat("{0}", (char)valT);
                    valT = raw[iS+1];
                    res.AppendFormat("{0}",(char) valT);
                    label3.Text = res.ToString();
                    res.Clear();                  
                    if (raw[iS + 4] != 0 && raw[iS + 5] != 0)
                    {
                        valT = raw[iS + 4];
                        res.AppendFormat("{0}", (char)valT);
                        valT = raw[iS + 5];
                        res.AppendFormat("{0}", (char)valT);
                        label4.Text = res.ToString();
                        res.Clear();
                    }
                    iS += 7;
                }
                iS++;
            }
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
            img = myWave.getBMP();
            pictureBox1.Image = img;
        }
        private void displayG2()
        {
            iE2 = raw.Count - 1;
            while (iS2 <= iE2 - 5)
            {
                if (raw[iS2] == 255 && raw[iS2 + 1] == 255 && raw[iS2 + 4] == 254 && raw[iS2 + 5] == 254)
                {
                    val2 = raw[iS2 + 3] * 256 + raw[iS2 + 2];
                    myWave2.update(val2);
                    iS2 += 5;
                }
                else if (raw[iS2] == 11 && raw[iS2 + 1] != 0 && raw[iS2 + 2] == 255 && raw[iS2 + 3] == 255)
                {
                    iS2++;
                    cnt2++;
                    valHR2 += raw[iS2];
                    if (cnt2 % 60 == 0)
                    {
                        label2.Text = string.Format("HR:{0}", valHR2 / 60);
                        cnt2 = 0;
                        valHR2 = 0;
                    }

                }
                //else
                //{
                //    valT2 = raw[iS2];
                //    res2.AppendFormat("{0}", (char)valT2);
                //}
                iS2++;
            }
            if (img2 != null)
            {
                img2.Dispose();
                img2 = null;
            }
            img2 = myWave2.getBMP();
            pictureBox2.Image = img2;
        }
        private void initialStart()
        {
            btnStop.Enabled = true;
            btnRx.Enabled = false;
            btnSave.Enabled = false;
            iS = 0;
            iE = 0;       
            iS2 = 0;
            iE2 = 0;
            myWave = new myWaveBMP(750);
            myWave2 = new myWaveBMP(750);
            if (img!=null)
            {
                img.Dispose();
                img = null;
            }
            img = myWave.getBMP();
            pictureBox1.Image = img;
            if (img2 != null)
            {
                img2.Dispose();
                img2 = null;
            }
            img2 = myWave2.getBMP();
            pictureBox2.Image = img2;
            raw.Clear();
            raw2.Clear();
            sw.Restart();
        }
    }
}
