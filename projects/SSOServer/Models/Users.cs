using System.Linq;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;
using SSOServer.Db;

namespace SSOServer
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            List<InMemoryUser> result = null;
            using (DBEntities db = new DBEntities())
            {
                List<USERINFO> users = db.USERINFO.Take<USERINFO>(5000).ToList<USERINFO>();
                if (null != users && users.Count > 0)
                {
                    result = new List<InMemoryUser>();
                    foreach (USERINFO user in users)
                    {
                        InMemoryUser u = new InMemoryUser
                        {
                            Username = user.USERNAME,
                            Password = user.PASSWORD,
                            Subject = "1",
                            Claims = new[]
                            {
                            new Claim(Constants.ClaimTypes.Name, user.DISPLAYNAME),
                            new Claim(Constants.ClaimTypes.NickName, user.NICKNAME),
                            new Claim(Constants.ClaimTypes.Email, user.EMAIL)
                        }
                        };
                        result.Add(u);
                    }
                }
            }
            return result;
        }
    }
}