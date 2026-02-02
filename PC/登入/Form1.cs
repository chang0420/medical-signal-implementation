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

namespace 登入
{
    static string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + "/employeeinfo.mdb";
    OleDbConnection dbcon = new OleDbConnection(constr);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
