using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace SSOApi.Controller
{
    [Authorize]
    public class UserController : ApiController
    {
        public dynamic Get()
        {
            var principal = User as ClaimsPrincipal;
            var claim = principal.Identities.First().FindFirst("userinfo");
            return claim.Value;

            //return from c in 
            //return principal.Identities.First().FindFirst("userinfo"); //.Claims
            //select new
            //{
            //    c.Type,
            //    c.Value
            //};
        }
    }
}