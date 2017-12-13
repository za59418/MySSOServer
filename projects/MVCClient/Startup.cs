using Owin;
using Microsoft.Owin;
using DCI.SSO.ClientLib;

[assembly: OwinStartup(typeof(MVCClient.Startup))]
namespace MVCClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SSOProvider sso = new SSOProvider(
                "mvcClient",
                "https://192.168.1.115:44319/identity/",
                "http://192.168.1.115/mvcClient/"
                );
            sso.Configuration(app);
        }
    }
}
