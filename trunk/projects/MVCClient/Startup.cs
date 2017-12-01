using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using DCI.SSO.ClientLib;

[assembly: OwinStartup(typeof(MVCClient.Startup))]
namespace MVCClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SSOProvider.Configuration(app);
        }
    }
}