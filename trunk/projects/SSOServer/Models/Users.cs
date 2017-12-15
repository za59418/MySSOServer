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
                                new Claim("userid", user.USERID.ToString()),
                                new Claim("username", null == user.USERNAME ? "" : user.USERNAME),
                                new Claim("displayName", null == user.DISPLAYNAME ? "" : user.DISPLAYNAME),
                                new Claim("shortName", null == user.SHORTNAME ? "" : user.SHORTNAME),
                                new Claim("userTypeId", null == user.USERTYPEID ? "" : user.USERTYPEID.ToString()),
                                new Claim("createTime", null == user.CREATETIME ? "" : user.CREATETIME),
                                new Claim("description", null == user.DESCRIPTION ? "" : user.DESCRIPTION),
                                new Claim("isLockedOut", null == user.ISLOCKEDOUT ? "false" : user.ISLOCKEDOUT.ToString()),
                                new Claim("email", null == user.EMAIL ? "" : user.EMAIL),
                                new Claim("nickName", null == user.NICKNAME ? "" :user.NICKNAME ),
                                new Claim("updateTime", null == user.UPDATETIME ? "" : user.UPDATETIME),
                                new Claim("weight", null == user.WEIGHT ? "" : user.WEIGHT.ToString()),
                                new Claim("userImages", null == user.USERIMAGES ? "" : user.USERIMAGES),
                                new Claim("sIndex", null == user.SINDEX ? "" : user.SINDEX.ToString()),
                                new Claim("extraid", null == user.EXTRAID ? "" : user.EXTRAID)
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