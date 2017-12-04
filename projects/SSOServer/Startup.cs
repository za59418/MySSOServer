using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Web.Helpers;
using IdentityServer3.Core;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Configuration;
using IdentityModel.Client;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Security;

[assembly: OwinStartup(typeof(SSOServer.Startup))]
namespace SSOServer
{
    public class Startup
    {
        public static IdentityServerServiceFactory factory = null;

        public void Configuration(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            factory = new IdentityServerServiceFactory()
                            .UseInMemoryUsers(Users.Get())
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get());

            //自定义登陆界面
            factory.ViewService = new Registration<IViewService, MvcViewService<LogonWorkflowController>>();

            factory.Register(new Registration<HttpContext>(resolver => HttpContext.Current));
            factory.Register(new Registration<HttpContextBase>(resolver => new HttpContextWrapper(resolver.Resolve<HttpContext>())));
            factory.Register(new Registration<HttpRequestBase>(resolver => resolver.Resolve<HttpContextBase>().Request));
            factory.Register(new Registration<HttpResponseBase>(resolver => resolver.Resolve<HttpContextBase>().Response));
            factory.Register(new Registration<HttpServerUtilityBase>(resolver => resolver.Resolve<HttpContextBase>().Server));
            factory.Register(new Registration<HttpSessionStateBase>(resolver => resolver.Resolve<HttpContextBase>().Session));

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "SSO 单点登陆系统",
                    SigningCertificate = LoadCertificate(),
                    Factory = factory
                });
                //证书处理
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            });

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://192.168.1.115:44319/identity",
                ClientId = "mvc",
                Scope = "openid profile roles",
                RedirectUri = "https://192.168.1.115:44319/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        var id = n.AuthenticationTicket.Identity;

                        // we want to keep first name, last name, subject and roles
                        var niceName = id.FindFirst(Constants.ClaimTypes.NickName);
                        var sub = id.FindFirst(Constants.ClaimTypes.Subject);

                        // create new identity and set name and role claim type
                        var nid = new ClaimsIdentity(id.AuthenticationType);

                        nid.AddClaim(niceName);
                        nid.AddClaim(sub);

                        // add some other app specific claim
                        nid.AddClaim(new Claim("app_specific", "some data"));

                        n.AuthenticationTicket = new AuthenticationTicket(
                            nid,
                            n.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    }
                }
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\identityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }

        //证书处理
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }
}