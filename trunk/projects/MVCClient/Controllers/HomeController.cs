using IdentityModel.Client;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Request.GetOwinContext().Authentication.SignOut("Cookies");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string scopes)
        {
            var state = Guid.NewGuid().ToString("N");
            var nonce = Guid.NewGuid().ToString("N");
            SetTempState(state, nonce);

            var request = new AuthorizeRequest("https://192.168.1.115:44319/identity/connect/authorize");

            var url = request.CreateAuthorizeUrl(
                clientId: "codeclient",
                responseType: "code",
                scope: scopes,
                redirectUri: "http://localhost/MVCClient",
                state: state,
                nonce: nonce);

            return Redirect(url);
        }

        private void SetTempState(string state, string nonce)
        {
            var tempId = new ClaimsIdentity("TempState");
            tempId.AddClaim(new Claim("state", state));
            tempId.AddClaim(new Claim("nonce", nonce));

            Request.GetOwinContext().Authentication.SignIn(tempId);
        }
    }
}