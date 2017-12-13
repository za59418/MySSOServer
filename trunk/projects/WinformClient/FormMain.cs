using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IdentityModel.Client;

namespace WinformClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public string Result {
            set
            {
                this.textBox1.Text = value;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new WinformClient.FormLogin(ServerUrl);
            loginForm.mainForm = this;
            loginForm.ShowDialog();
        }

        public string ServerUrl {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ServerUrl = "https://192.168.1.115:44319/identity";
        }
    }
}
