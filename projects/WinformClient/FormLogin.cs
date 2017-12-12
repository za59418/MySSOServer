using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

using DCI.SSO.ClientLib;


namespace WinformClient
{
    public partial class FormLogin : Form
    {
        public FormMain mainForm { get; set; }

        public FormLogin(string serverUrl)
        {
            InitializeComponent();
            this.ssoLoginCtrl1.Window = this;
            this.ssoLoginCtrl1.Init("winformClient", serverUrl, "http://localhost/wpf.hybrid"); //"https://localhost:44312/identity"
            this.ssoLoginCtrl1.Done += _login_Done;
            this.ssoLoginCtrl1.LoginAsync();
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

                mainForm.Result = sb.ToString();
            }
            else
            {
                mainForm.Result = e.ErrorMessage;
            }
        }
    }
}
