using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Configuration;
using System.Net.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SSOApi.Startup))]
namespace SSOApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //证书处理
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            //从配置文件中读取单点登陆服务器地址
            string ssoServer = ConfigurationManager.AppSettings["ssoServer"].ToString();
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = ssoServer,
                RequiredScopes = new[] { "logon" },

                // client credentials for the introspection endpoint
                ClientId = "write",
                ClientSecret = "secret"
            });

            app.UseWebApi(WebApiConfig.Register());
        }

        //证书处理
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

    }
}