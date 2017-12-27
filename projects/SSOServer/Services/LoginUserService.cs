using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using SSOServer.Db;

namespace SSOServer
{
    public class LoginUserService : InMemoryUserService
    {
        IOwinContext ctx;

        public LoginUserService(List<InMemoryUser> users, OwinEnvironmentService env) : base(users)
        {
            ctx = new OwinContext(env.Environment);
        }

        public override async Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var form = await ctx.Request.ReadFormAsync();
            var password = form["password"];
            context.Password = Utils.md5Unicodebase64(password);

            await base.AuthenticateLocalAsync(context);
        }
    }
}