using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
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
                Scope = "openid profile email",
                UseTokenLifetime = false,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = async n =>
                    {
                        var claims_to_exclude = new[]
                        {
                            "aud", "iss", "nbf", "exp", "nonce", "iat", "at_hash"
                        };

                        var claims_to_keep =
                            n.AuthenticationTicket.Identity.Claims
                            .Where(x => false == claims_to_exclude.Contains(x.Type)).ToList();
                        claims_to_keep.Add(new Claim("id_token", n.ProtocolMessage.IdToken));

                        if (n.ProtocolMessage.AccessToken != null)
                        {
                            claims_to_keep.Add(new Claim("access_token", n.ProtocolMessage.AccessToken));

                            var userInfoClient = new UserInfoClient(new Uri(ServerUrl + "/connect/userinfo"), n.ProtocolMessage.AccessToken);
                            var userInfoResponse = await userInfoClient.GetAsync();
                            var userInfoClaims = userInfoResponse.Claims
                                .Where(x => x.Item1 != "sub") // filter sub since we're already getting it from id_token
                                .Select(x => new Claim(x.Item1, x.Item2));
                            claims_to_keep.AddRange(userInfoClaims);
                        }

                        var ci = new ClaimsIdentity(
                            n.AuthenticationTicket.Identity.AuthenticationType,
                            "name", "role");
                        ci.AddClaims(claims_to_keep);

                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(
                            ci, n.AuthenticationTicket.Properties
                        );
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

        //证书处理
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }
}
