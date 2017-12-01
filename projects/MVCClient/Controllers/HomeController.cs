using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DCI.SSO.ClientLib;

namespace MVCClient.Controllers
{
    public class HomeController : Controller
    {

        SSOProvider obj = new SSOProvider(
            "mvcClient",
            "https://192.168.1.115:44319/identity",
            "http://localhost/mvcClient/Home/SignInCallback"
        );

        public ActionResult Index()
        {
            string ssoUrl = obj.CreateUrl(this);
            return Redirect(ssoUrl);
        }

        [HttpPost]
        public async Task<ActionResult> SignInCallback()
        {
            obj.ValidateAndSignIn(this);
            return View("Index");
        }
    }
}