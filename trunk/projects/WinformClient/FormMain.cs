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
        FormLogin _login;

        public FormMain()
        {
            InitializeComponent();

            _login = new FormLogin();
            _login.Done += _login_Done;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _login.Owner = this;
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var settings = new OidcSettings
            {
                Authority = "https://localhost:44318/identity",
                ClientId = "wpf.hybrid",
                ClientSecret = "secret",
                RedirectUri = "http://localhost/wpf.hybrid",
                Scope = "openid profile write",
                LoadUserProfile = true
            };

            await _login.LoginAsync(settings);
        }

        void _login_Done(object sender, LoginResult e)
        {
            if (e.Success)
            {
                var sb = new StringBuilder(128);

                foreach (var claim in e.User.Claims)
                {
                    sb.AppendLine($"{claim.Type}: {claim.Value}");
                }

                sb.AppendLine();

                sb.AppendLine($"Identity token: {e.IdentityToken}");
                sb.AppendLine($"Access token: {e.AccessToken}");
                sb.AppendLine($"Access token expiration: {e.AccessTokenExpiration}");
                sb.AppendLine($"Refresh token: {e?.RefreshToken ?? "none" }");

                textBox1.Text = sb.ToString();
            }
            else
            {
                textBox1.Text = e.ErrorMessage;
            }
        }
    }
}
