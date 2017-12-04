using System.Linq;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;
using SSOServer.Db;

namespace SSOServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            List<Client> result = null;
            using (DbEntities db = new Db.DbEntities())
            {
                List<SYSTEMINFO> clients = db.SYSTEMINFO.Take<SYSTEMINFO>(5000).ToList<SYSTEMINFO>();
                if (null != clients && clients.Count > 0)
                {
                    result = new List<Client>();
                    foreach (SYSTEMINFO client in clients)
                    {
                        Client c = new Client
                        {
                            ClientId = client.CLIENTID,
                            ClientName = client.CLIENTNAME,
                            Flow = Flows.Implicit,

                            ClientUri = client.CLIENTURI,

                            RequireConsent = bool.Parse(client.REQUIRECONSENT),
                            AllowRememberConsent = bool.Parse(client.ALLOWREMEMBERCONSENT),

                            RedirectUris = new List<string>
                            {
                                client.REDIRECTURIS
                            },

                            AllowedScopes = client.ALLOWEDSCOPES.Split(',').ToList<string>(),
                            AccessTokenType = AccessTokenType.Reference
                        };

                        if (null != client.CLIENTSECRETS)
                        {
                            c.ClientSecrets = new List<Secret>
                            {
                                new Secret(client.CLIENTSECRETS.Sha256())
                            };
                        }
                        result.Add(c);
                    }
                }
            }
            return result;
        }
    }
}