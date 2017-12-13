using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(WebApp.Startup))]
namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DCI.SSO.ClientLib.WebformClient client = new DCI.SSO.ClientLib.WebformClient(
                "webFormClient",
                "https://192.168.1.115:44319/identity/",
                "http://192.168.1.115/webformClient/"
                );
            client.Configuration(app);
        }
    }
}
