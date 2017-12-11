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
            FormLogin loginForm = new WinformClient.FormLogin();
            loginForm.mainForm = this;
            loginForm.ShowDialog();
        }        
    }
}
