﻿using System.Linq;
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
                            Subject = user.USERID.ToString(),
                            Username = user.USERNAME,
                            Password = user.PASSWORD,
                            Claims = new[]
                            {
                                new Claim("userinfo", Newtonsoft.Json.JsonConvert.SerializeObject(user))
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