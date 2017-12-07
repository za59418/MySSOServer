using System.Linq;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;
using SSOServer.Db;
using System.Xml;
using System;

namespace SSOServer
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(string.Format(@"{0}\bin\Models\ServerLogin.xml", AppDomain.CurrentDomain.BaseDirectory));
            string redirecturis = doc.SelectSingleNode("Client/RedirectUris").InnerText;
            string authority = redirecturis + "identity";
            string clientid = doc.SelectSingleNode("Client/ClientId").InnerText;
            string clientname = doc.SelectSingleNode("Client/ClientName").InnerText;
            string clienturi = doc.SelectSingleNode("Client/ClientUri").InnerText;
            bool AllowAccessToAllScopes = bool.Parse(doc.SelectSingleNode("Client/AllowAccessToAllScopes").InnerText);

            List<Client> result = null;
            using (DBEntities db = new Db.DBEntities())
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

                            AllowedScopes = client.ALLOWEDSCOPES.Split(',').ToList<string>()
                        };

                        if (null != client.CLIENTSECRETS)
                        {
                            c.ClientSecrets = new List<Secret>
                            {
                                new Secret(client.CLIENTSECRETS.Sha256())
                            };
                        }

                        if (null != client.ACCESSTOKENTYPE)
                        {
                            c.AccessTokenType = AccessTokenType.Reference;
                        }

                        result.Add(c);
                    }

                    result.Add(
                        new Client
                        {
                            ClientName = clientname,
                            ClientId = clientid,
                            Flow = Flows.Implicit,

                            RequireConsent = false,
                            ClientUri = clienturi,
                            RedirectUris = new List<string>
                            {
                                redirecturis
                            },
                            AllowAccessToAllScopes = AllowAccessToAllScopes
                        }
                    );
                }
            }
            return result;
        }
    }
}