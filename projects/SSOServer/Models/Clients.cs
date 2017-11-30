using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace SSOServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                /////////////////////////////////////////////////////////////
                // WPF Client with Hybrid Flow and PKCE and PoP
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "WPF Client with Hybrid Flow and PKCE and PoP",
                    ClientId = "wpf.hybrid.pop",
                    Flow = Flows.HybridWithProofKey,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = new List<string>
                    {
                        "http://localhost/wpf.hybrid.pop"
                    },

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.OfflineAccess.Name,
                        "read", "write"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },
                
                
                /////////////////////////////////////////////////////////////
                // WPF Client with Hybrid Flow and PKCE
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "WPF Client with Hybrid Flow and PKCE",
                    ClientId = "wpf.hybrid",
                    Flow = Flows.HybridWithProofKey,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = new List<string>
                    {
                        "http://localhost/wpf.hybrid"
                    },

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        "read", "write"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },

                /////////////////////////////////////////////////////////////
                // WPF WebView Client Sample
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "WPF WebView Client Sample",
                    ClientId = "wpf.webview.client",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "oob://localhost/wpf.webview.client",
                    }
                },

                
                /////////////////////////////////////////////////////////////
                // WebForms OWIN Implicit Client
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "WebForms OWIN Implicit Client",
                    ClientId = "webforms.owin.implicit",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost:5969/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:5969/"
                    }
                },
                
                /////////////////////////////////////////////////////////////
                // JavaScript Implicit Client - OAuth only
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "js.simple",
                    ClientId = "js.simple",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/sso3/index.html",
                    }
                },


                /////////////////////////////////////////////////////////////
                // JavaScript Implicit Client - Manual
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "JavaScript Implicit Client - Manual",
                    ClientId = "js.manual",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/sso1/index.html",
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost/sso1"
                    }
                },

                /////////////////////////////////////////////////////////////
                // JavaScript Implicit Client - TokenManager
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "JavaScript Implicit Client - UserManager",
                    ClientId = "js.usermanager",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost:21575/index.html",
                        "http://localhost:21575/silent_renew.html",
                        "http://localhost:21575/callback.html",
                        "http://localhost:21575/frame.html",
                        "http://localhost:21575/popup.html",
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:21575/index.html",
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:21575",
                    },

                    AccessTokenLifetime = 3600,
                    AccessTokenType = AccessTokenType.Jwt
                },
                
                /////////////////////////////////////////////////////////////
                // Console Client Credentials Sample
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "Client Credentials Flow Client",
                    Enabled = true,
                    ClientId = "clientcredentials.client",
                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256()),
                        new Secret
                        {
                            Value = "61B754C541BBCFC6A45A9E9EC5E47D8702B78C29",
                            Type = Constants.SecretTypes.X509CertificateThumbprint,
                            Description = "Client Certificate"
                        },
                    },

                    AllowedScopes = new List<string>
                    {
                        "read",
                        "write"
                    },

                    Claims = new List<Claim>
                    {
                        new Claim("location", "datacenter")
                    }
                },
                
                /////////////////////////////////////////////////////////////
                // Console Custom Grant Type Sample
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "Custom Grant Client",
                    ClientId = "customgrant.client",
                    Flow = Flows.Custom,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "read",
                        "write"
                    },

                    AllowedCustomGrantTypes = new List<string>
                    {
                        "custom"
                    }
                },
                
                /////////////////////////////////////////////////////////////
                // Resource Owner Flow Samples
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "Resource Owner Flow Client",
                    ClientId = "ro.client",
                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "read",
                        "write",
                        "address",
                        "offline_access" 
                    },

                    // used by JS resource owner sample
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:13048"
                    },

                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3600,

                    // refresh token settings
                    AbsoluteRefreshTokenLifetime = 86400,
                    SlidingRefreshTokenLifetime = 43200,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },
                
                
                /////////////////////////////////////////////////////////////
                // MVC CodeFlowClient Manual
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "Code Flow Client Demo",
                    ClientId = "codeclient",
                    Flow = Flows.AuthorizationCode,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    ClientUri = "https://identityserver.io",

                    RedirectUris = new List<string>
                    {
                        "http://localhost/sso2/callback",
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess,
                        "read",
                        "write"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },
                /////////////////////////////////////////////////////////////
                // MVC No Library Client
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "OpenID Connect without Client Library Sample",
                    ClientId = "nolib.client",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/sso4/account/signInCallback",
                    }
                },

                /////////////////////////////////////////////////////////////
                // MVC OWIN Hybrid Client
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "MVC OWIN Hybrid Client",
                    ClientId = "mvc.owin.hybrid",
                    Flow = Flows.Hybrid,
                    AllowAccessTokensViaBrowser = false,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess,
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Reference,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44300/"
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44300/"
                    },

                    LogoutUri = "https://localhost:44300/Home/OidcSignOut",
                    LogoutSessionRequired = true
                },


                /////////////////////////////////////////////////////////////
                // MVC OWIN Implicit Client
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientName = "MVC OWIN Implicit Client",
                    ClientId = "mvc.owin.implicit",
                    Flow = Flows.Implicit,
                    AllowAccessTokensViaBrowser = false,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44301/"
                    },

                    LogoutUri = "https://localhost:44301/Home/SignoutCleanup",
                    LogoutSessionRequired = true
                },


                new Client
                {
                    Enabled = true,
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,

                    RequireConsent = false,

                    RedirectUris = new List<string>
                    {
                        "https://192.168.1.115:44319/"
                    },

                    AllowAccessToAllScopes = true
                },


                #region 测试
                //sso js Client
                new Client
                {
                    ClientName = "jsClient",
                    ClientId = "jsClient",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        "logon"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/jsClient/index.html",
                    }
                },

                //sso mvc Client
                new Client
                {
                    ClientName = "mvcClient",
                    ClientId = "mvcClient",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/mvcClient/Home/SignInCallback",
                    }
                },

                new Client
                {
                    ClientName = "WebFormClient",
                    ClientId = "webformClient",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.Address,
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://localhost/webformClient/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost/webformClient/"
                    }
                },

                //62CLIENT
                new Client
                {
                    ClientName = "js.simple62",
                    ClientId = "js.simple62",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        "read",
                        "write"
                    },

                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        "http://192.168.1.62/jsClient/index.html",
                    }
                }
                #endregion 测试

            };
        }
    }
}