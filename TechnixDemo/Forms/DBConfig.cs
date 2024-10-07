using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TechnixDemo.Forms
{
    public partial class DBConfig : Form
    {
        public string FormData { get;  set; }

        public DBConfig()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Config_Click(object sender, EventArgs e)
        {
            FormData = "Server=" + ServerTxt.Text + ";Database="+ DatabaseTxt.Text + ";Trusted_Connection=True;TrustServerCertificate=True;";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
