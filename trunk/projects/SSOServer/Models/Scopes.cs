using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace SSOServer
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
                {
                    ////////////////////////
                    // identity scopes
                    ////////////////////////

                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    StandardScopes.Address,
                    StandardScopes.OfflineAccess,
                    StandardScopes.RolesAlwaysInclude,
                    StandardScopes.AllClaims,

                    ////////////////////////
                    // resource scopes
                    ////////////////////////

                    new Scope
                    {
                        Name = "logon",
                        DisplayName = "登陆",
                        Type = ScopeType.Identity,
                        Emphasize = false,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        },

                        Claims = new List<ScopeClaim> //用户信息
                        {
                            new ScopeClaim("userid"),
                            new ScopeClaim("username"),
                            new ScopeClaim("displayName"),
                            new ScopeClaim("shortName"),
                            new ScopeClaim("userTypeId"),
                            new ScopeClaim("createTime"),
                            new ScopeClaim("description"),
                            new ScopeClaim("isLockedOut"),
                            new ScopeClaim("email"),
                            new ScopeClaim("nickName"),
                            new ScopeClaim("updateTime"),
                            new ScopeClaim("weight"),
                            new ScopeClaim("userImages"),
                            new ScopeClaim("sIndex"),
                            new ScopeClaim("extraid")
                        }
                    },

                    new Scope
                    {
                        Name = "read",
                        DisplayName = "Read data",
                        Type = ScopeType.Resource,
                        Emphasize = false,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    new Scope
                    {
                        Name = "write",
                        DisplayName = "Write data",
                        Type = ScopeType.Resource,
                        Emphasize = true,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    new Scope
                    {
                        Name = "idmgr",
                        DisplayName = "IdentityManager",
                        Type = ScopeType.Resource,
                        Emphasize = true,
                        ShowInDiscoveryDocument = false,

                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim(Constants.ClaimTypes.Name),
                            new ScopeClaim(Constants.ClaimTypes.Role)
                        }
                    }
                };
        }
    }
}