using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(SSOApi.Startup))]

namespace SSOApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44318/identity",
                RequiredScopes = new[] { "logon" },

                // client credentials for the introspection endpoint
                ClientId = "write",
                ClientSecret = "secret"
            });

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}