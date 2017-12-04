using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Thinktecture.IdentityModel.Mvc;
using IdentityServer3.Core.Models;
using SSOServer;

namespace SSOServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Client> clients = Clients.Get();
            return View(clients);
        }

        public ActionResult RefreshClient()
        {
            IEnumerable<Client> clients = Clients.Get();
            //Startup.factory.UseInMemoryClients(clients);
            return View("Index", clients);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View((User as ClaimsPrincipal).Claims);
        }

        [ResourceAuthorize("Read", "ContactDetails")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}