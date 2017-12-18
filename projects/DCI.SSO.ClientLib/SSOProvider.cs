using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;

namespace DCI.SSO.ClientLib
{
    public class SSOProvider
    {
        private string ClientId = null;
        private string ServerUrl = null;
        private string ClientUrl = null;

        private string Token = null;

        /// <summary>
        /// 单点登陆构造器
        /// </summary>
        /// <param name="ClientId">客户端ID，须与单点登陆服务器注册的地址匹配</param>
        /// <param name="ServerUrl">单点登陆服务器基地址</param>
        /// <param name="ClientUrl">客户端首页地址，须与单点登陆服务器注册的地址匹配</param>
        public SSOProvider(string ClientId, string ServerUrl, string ClientUrl)
        {
            this.ClientId = ClientId;
            this.ServerUrl = ServerUrl;
            this.ClientUrl = ClientUrl;
        }

        public void Configuration(IAppBuilder app)
        {
            //证书处理
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies",
                ExpireTimeSpan = TimeSpan.FromMinutes(10),
                SlidingExpiration = true
            });

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "oidc",
                SignInAsAuthenticationType = "Cookies",
                Authority = ServerUrl,
                ClientId = ClientId,
                RedirectUri = ClientUrl,
                PostLogoutRedirectUri = ClientUrl,
                ResponseType = "id_token token",
                Scope = "openid logon",
                UseTokenLifetime = false,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = async n =>
                    {

                        var id = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);

                        var userInfoClient = new UserInfoClient(new Uri(ServerUrl + "/connect/userinfo"), n.ProtocolMessage.AccessToken);
                        var userInfoResponse = await userInfoClient.GetAsync();

                        var userInfoClaims = userInfoResponse.GetClaimsIdentity().Claims
                            .Where(x => x.Type != "sub")
                            .Select(x => new Claim(x.Type, x.Value));
                        id.AddClaims(userInfoClaims);

                        if (n.ProtocolMessage.AccessToken != null)
                        {
                            //初使化TOKEN
                            this.Token = n.ProtocolMessage.AccessToken;
                            id.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                        }

                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(
                        new ClaimsIdentity(id.Claims, n.AuthenticationTicket.Identity.AuthenticationType),
                        n.AuthenticationTicket.Properties);

                    },
                    RedirectToIdentityProvider = n =>
                    {
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var id_token = n.OwinContext.Authentication.User.FindFirst("id_token")?.Value;
                            n.ProtocolMessage.IdTokenHint = id_token;
                        }

                        return Task.FromResult(0);
                    }
                }
            });
            app.UseStageMarker(PipelineStage.Authenticate);
        }

        public async static Task<string> GetUser(string token, string apiUrl)
        {
            if (null != token)
            {
                var client = new HttpClient();
                client.SetBearerToken(token);
                var result = await client.GetStringAsync(apiUrl);

                return result;
            }
            else
            {
                return "{\"error\":\"token获取失败！\"}";
            }
        }

        public async Task<string> GetUser(string apiUrl)
        {
            if (null != this.Token)
            {
                var client = new HttpClient();
                client.SetBearerToken(this.Token);
                var result = await client.GetStringAsync(apiUrl);

                return result;
            }
            else
            {
                return "{\"error\":\"token获取失败！\"}";
            }
        }
        
        //证书处理
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }
}
