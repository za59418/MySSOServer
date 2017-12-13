using Owin;
using Microsoft.Owin;
using DCI.SSO.ClientLib;

[assembly: OwinStartup(typeof(WebformClient.Startup))]
namespace WebformClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SSOProvider sso = new SSOProvider(
                "webFormClient",
                "https://192.168.1.115:44319/identity/",
                "http://192.168.1.115/webformClient/"
                );
            sso.Configuration(app);
        }
    }
}
