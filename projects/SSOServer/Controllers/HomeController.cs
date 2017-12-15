using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Thinktecture.IdentityModel.Mvc;
using SSOServer.Db;

namespace SSOServer.Controllers
{
    public class HomeController : Controller
    {
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            IEnumerable<SYSTEMINFO> clients = null;
            clients = db.SYSTEMINFO.Take(5000).OrderBy(s => s.SYSTEMID);
            return View(clients);
        }

        public ActionResult RegistClient()
        {
            List<SelectListItem> consents = new List<SelectListItem>();
            consents.Add(new SelectListItem { Value = "false", Text = "否" });
            consents.Add(new SelectListItem { Value = "true", Text = "是" });
            this.ViewData["consents"] = consents;

            SYSTEMINFO model = new SYSTEMINFO();
            model.ALLOWEDSCOPES = "openid,logon";
            return View(model);
        }

        [HttpPost]
        public ActionResult DoRegistClient(SYSTEMINFO model)
        {
            model.FLOW = "Implicit";
            model.ALLOWREMEMBERCONSENT = "false";
            model.CLIENTURI = "https://identityserver.io";

            db.SYSTEMINFO.Add(model);
            db.SaveChanges();

            return Redirect("Index");
        }

        public ActionResult DeleteClient(int SYSTEMID)
        {
            SYSTEMINFO entity = db.SYSTEMINFO.Find(SYSTEMID);
            db.SYSTEMINFO.Remove(entity);
            db.SaveChanges();
            return Redirect("Index");
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
            return Redirect("Index");
        }
    }
}