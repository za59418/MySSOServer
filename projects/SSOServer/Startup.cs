using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using IdentityServer3.Core;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Configuration;
using IdentityModel.Client;
using IdentityServer3.Core.Models;
using SSOServer.Controllers;

[assembly: OwinStartup(typeof(SSOServer.Startup))]

namespace SSOServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //证书处理
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            var factory = new IdentityServerServiceFactory()
                        .UseInMemoryUsers(Users.Get())
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get());

            // Use the Mvc View Service instead of the default
            factory.ViewService = new Registration<IViewService, MvcViewService<LogonWorkflowController>>();

            // These registrations are also needed since these are dealt with using non-standard construction
            factory.Register(new Registration<HttpContext>(resolver => HttpContext.Current));
            factory.Register(new Registration<HttpContextBase>(resolver => new HttpContextWrapper(resolver.Resolve<HttpContext>())));
            factory.Register(new Registration<HttpRequestBase>(resolver => resolver.Resolve<HttpContextBase>().Request));
            factory.Register(new Registration<HttpResponseBase>(resolver => resolver.Resolve<HttpContextBase>().Response));
            factory.Register(new Registration<HttpServerUtilityBase>(resolver => resolver.Resolve<HttpContextBase>().Server));
            factory.Register(new Registration<HttpSessionStateBase>(resolver => resolver.Resolve<HttpContextBase>().Session));

            var options = new IdentityServerOptions
            {
                SiteName = "SSO 单点登陆系统",
                SigningCertificate = Certificate.Load(),
                Factory = factory
            };

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(options);
            });

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            XmlDocument doc = new XmlDocument();
            doc.Load(string.Format(@"{0}\bin\Models\ServerLogin.xml", AppDomain.CurrentDomain.BaseDirectory));
            string redirecturis = doc.SelectSingleNode("Client/RedirectUris").InnerText;
            string authority = redirecturis + "identity";
            string clientid = doc.SelectSingleNode("Client/ClientId").InnerText;

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = authority,
                ClientId = clientid,
                Scope = "openid profile roles",
                RedirectUri = redirecturis,
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        var id = n.AuthenticationTicket.Identity;
                        var nid = new ClaimsIdentity(id.AuthenticationType);

                        var niceName = id.FindFirst(Constants.ClaimTypes.NickName);
                        var sub = id.FindFirst(Constants.ClaimTypes.Subject);

                        nid.AddClaim(niceName);
                        nid.AddClaim(sub);
                        nid.AddClaim(new Claim("app_specific", "some data"));

                        //var userid = id.FindFirst("userid");
                        //var username = id.FindFirst("username");
                        //var DISPLAYNAME = id.FindFirst("DISPLAYNAME");
                        //var SHORTNAME = id.FindFirst("SHORTNAME");
                        //var USERTYPEID = id.FindFirst("USERTYPEID");
                        //var CREATETIME = id.FindFirst("CREATETIME");
                        //var DESCRIPTION = id.FindFirst("DESCRIPTION");
                        //var ISLOCKEDOUT = id.FindFirst("ISLOCKEDOUT");
                        //var EMAIL = id.FindFirst("EMAIL");
                        //var NICKNAME = id.FindFirst("NICKNAME");
                        //var UPDATETIME = id.FindFirst("UPDATETIME");
                        //var WEIGHT = id.FindFirst("WEIGHT");
                        //var USERIMAGES = id.FindFirst("USERIMAGES");
                        //var SINDEX = id.FindFirst("SINDEX");
                        //var EXTRAID = id.FindFirst("EXTRAID");

                        //nid.AddClaim(username);
                        //nid.AddClaim(DISPLAYNAME);
                        //nid.AddClaim(SHORTNAME);
                        //nid.AddClaim(USERTYPEID);
                        //nid.AddClaim(CREATETIME);
                        //nid.AddClaim(DESCRIPTION);
                        //nid.AddClaim(ISLOCKEDOUT);
                        //nid.AddClaim(EMAIL);
                        //nid.AddClaim(NICKNAME);
                        //nid.AddClaim(UPDATETIME);
                        //nid.AddClaim(WEIGHT);
                        //nid.AddClaim(USERIMAGES);
                        //nid.AddClaim(SINDEX);
                        //nid.AddClaim(EXTRAID);

                        n.AuthenticationTicket = new AuthenticationTicket(
                            nid,
                            n.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    }
                }
            });
        }

        //证书处理
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }
}