using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnixDemo.Model;

namespace TechnixDemo
{
    public partial class DatabaseConfig : Form
    {
        private CodeG _parentForm;
        public DatabaseConfig(CodeG parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            DbConfigModel dbConfigModel = new DbConfigModel()
            {
                ServerName=ServerNameTxt.Text,
                UserName=UserNameTxt.Text,
                Password=PasswordTxt.Text,
                DbName=DbNameTxt.Text,
            };
            _parentForm.UpdateConfig(dbConfigModel);

            this.Close();
        }
    }
}
