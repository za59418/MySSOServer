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
                Scope = "openid logon",
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

                        var userid = id.FindFirst("userid");
                        var username = id.FindFirst("username");
                        var displayName = id.FindFirst("displayName");
                        var shortName = id.FindFirst("shortName");
                        var userTypeId = id.FindFirst("userTypeId");
                        var createTime = id.FindFirst("createTime");
                        var description = id.FindFirst("description");
                        var isLockedOut = id.FindFirst("isLockedOut");
                        var email = id.FindFirst("email");
                        var nickName = id.FindFirst("nickName");
                        var updateTime = id.FindFirst("updateTime");
                        var weight = id.FindFirst("weight");
                        var userImages = id.FindFirst("userImages");
                        var sIndex = id.FindFirst("sIndex");
                        var extraid = id.FindFirst("extraid");

                        nid.AddClaim(userid);
                        nid.AddClaim(username);
                        nid.AddClaim(displayName);
                        nid.AddClaim(shortName);
                        nid.AddClaim(userTypeId);
                        nid.AddClaim(createTime);
                        nid.AddClaim(description);
                        nid.AddClaim(isLockedOut);
                        nid.AddClaim(email);
                        nid.AddClaim(nickName);
                        nid.AddClaim(updateTime);
                        nid.AddClaim(weight);
                        nid.AddClaim(userImages);
                        nid.AddClaim(sIndex);
                        nid.AddClaim(extraid);

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