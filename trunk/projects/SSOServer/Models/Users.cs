﻿using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace SSOServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
        {
            new InMemoryUser
            {
                Username = "bob",
                Password = "secret",
                Subject = "1",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.Name, "Bob Smith"),
                    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                    new Claim(Constants.ClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(Constants.ClaimTypes.Role, "Developer"),
                    new Claim(Constants.ClaimTypes.Role, "Geek"),
                    new Claim(Constants.ClaimTypes.WebSite, "http://bob.com"),
                    new Claim(Constants.ClaimTypes.Address, @"{ ""street_address"": ""One Hacker Way"", ""locality"": ""Heidelberg"", ""postal_code"": 69118, ""country"": ""Germany"" }", Constants.ClaimValueTypes.Json)
                }
            }
        };
        }
    }
}