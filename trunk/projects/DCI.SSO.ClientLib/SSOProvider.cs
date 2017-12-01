using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel;
using System.IdentityModel.Tokens;

using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace DCI.SSO.ClientLib
{
    public class SSOProvider
    {
        //public ActionResult Index(Controller controller)
        //{
        //    SSOProvider obj = new SSOProvider(
        //        "mvcClient", 
        //        "https://192.168.1.115:44319/identity", 
        //        "http://localhost/mvcClient/Home/SignInCallback"
        //        );
        //    string ssoUrl = obj.CreateUrl(controller);

        //    return controller.Redirect(url);
        //}

        //[HttpPost]
        //public async Task<ActionResult> SignInCallback(Controller controller)
        //{
        //    ValidateAndSignIn(controller);
        //    return controller.View("Index");
        //}

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

        /// <summary>
        /// 配置身份验证方式
        /// </summary>
        /// <param name="app">Startup中的IAppBuilder</param>
        public static void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "TempCookie",
                AuthenticationMode = AuthenticationMode.Passive
            });
        }

        /// <summary>
        /// 生成单点登陆服务器完整地址
        /// </summary>
        /// <param name="controller">MVC控制器</param>
        /// <returns>登陆地址</returns>
        public string CreateUrl(Controller controller)
        {
            var state = Guid.NewGuid().ToString("N");
            var nonce = Guid.NewGuid().ToString("N");

            var url = this.ServerUrl + "/connect/authorize" +
                "?client_id=" + this.ClientId +
                "&response_type=id_token" +
                "&scope=openid" +
                "&redirect_uri=" + this.ClientUrl +
                "&response_mode=form_post" +
                "&state=" + state +
                "&nonce=" + nonce;
            SetTempCookie(controller, state, nonce);
            return url;
        }

        /// <summary>
        /// 验证身份并登陆
        /// </summary>
        /// <param name="controller">MVC控制器</param>
        public async void ValidateAndSignIn(Controller controller)
        {
            var claims = await ValidateIdentityTokenAsync(controller);
            var id = new ClaimsIdentity(claims, "Cookies");
            controller.Request.GetOwinContext().Authentication.SignIn(id);
        }

        private async Task<IEnumerable<Claim>> ValidateIdentityTokenAsync(Controller controller)
        {
            var token = controller.Request.Form["id_token"];
            var state = controller.Request.Form["state"];

            var certString = "MIIDBTCCAfGgAwIBAgIQNQb+T2ncIrNA6cKvUA1GWTAJBgUrDgMCHQUAMBIxEDAOBgNVBAMTB0RldlJvb3QwHhcNMTAwMTIwMjIwMDAwWhcNMjAwMTIwMjIwMDAwWjAVMRMwEQYDVQQDEwppZHNydjN0ZXN0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqnTksBdxOiOlsmRNd+mMS2M3o1IDpK4uAr0T4/YqO3zYHAGAWTwsq4ms+NWynqY5HaB4EThNxuq2GWC5JKpO1YirOrwS97B5x9LJyHXPsdJcSikEI9BxOkl6WLQ0UzPxHdYTLpR4/O+0ILAlXw8NU4+jB4AP8Sn9YGYJ5w0fLw5YmWioXeWvocz1wHrZdJPxS8XnqHXwMUozVzQj+x6daOv5FmrHU1r9/bbp0a1GLv4BbTtSh4kMyz1hXylho0EvPg5p9YIKStbNAW9eNWvv5R8HN7PPei21AsUqxekK0oW9jnEdHewckToX7x5zULWKwwZIksll0XnVczVgy7fCFwIDAQABo1wwWjATBgNVHSUEDDAKBggrBgEFBQcDATBDBgNVHQEEPDA6gBDSFgDaV+Q2d2191r6A38tBoRQwEjEQMA4GA1UEAxMHRGV2Um9vdIIQLFk7exPNg41NRNaeNu0I9jAJBgUrDgMCHQUAA4IBAQBUnMSZxY5xosMEW6Mz4WEAjNoNv2QvqNmk23RMZGMgr516ROeWS5D3RlTNyU8FkstNCC4maDM3E0Bi4bbzW3AwrpbluqtcyMN3Pivqdxx+zKWKiORJqqLIvN8CT1fVPxxXb/e9GOdaR8eXSmB0PgNUhM4IjgNkwBbvWC9F/lzvwjlQgciR7d4GfXPYsE1vf8tmdQaY8/PtdAkExmbrb9MihdggSoGXlELrPA91Yce+fiRcKY3rQlNWVd4DOoJ/cPXsXwry8pWjNCo5JD8Q+RQ5yZEy7YPoifwemLhTdsBz3hlZr28oCGJ3kbnpW0xGvQb3VHSTVVbeei0CfXoW6iz1";
            var cert = new X509Certificate2(Convert.FromBase64String(certString));

            var result = await controller.Request
                .GetOwinContext()
                .Authentication
                .AuthenticateAsync("TempCookie");

            if (result == null)
            {
                throw new InvalidOperationException("No temp cookie");
            }

            if (state != result.Identity.FindFirst("state").Value)
            {
                throw new InvalidOperationException("invalid state");
            }

            var parameters = new TokenValidationParameters
            {
                ValidAudience = this.ClientId,
                ValidIssuer = this.ServerUrl,
                IssuerSigningToken = new X509SecurityToken(cert)
            };

            var handler = new JwtSecurityTokenHandler();
            SecurityToken jwt; 
             var id = handler.ValidateToken(token, parameters, out jwt);

            if (id.FindFirst("nonce").Value !=
                result.Identity.FindFirst("nonce").Value)
            {
                throw new InvalidOperationException("Invalid nonce");
            }

            controller.Request.GetOwinContext().Authentication.SignOut("TempCookie");

            return id.Claims;
        }

        private void SetTempCookie(Controller controller, string state, string nonce)
        {
            var tempId = new ClaimsIdentity("TempCookie");
            tempId.AddClaim(new Claim("state", state));
            tempId.AddClaim(new Claim("nonce", nonce));

            controller.Request.GetOwinContext().Authentication.SignIn(tempId);
        }
    }
}
