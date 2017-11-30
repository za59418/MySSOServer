using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Security.Claims;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebformClient
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            // now you can fix up you session object from
            // if you use session state (which makes me sad if you do)
            var cp = (ClaimsPrincipal)HttpContext.Current.User;

        }

    }
}