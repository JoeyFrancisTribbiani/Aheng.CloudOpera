﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aheng.IdentityProvider
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Nick",
                    Password = "123",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name","Nick"),
                        new Claim("family_name","Carter")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Dave",
                    Password = "123",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name","Dave"),
                        new Claim("family)name","Mustaine")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "Mvc 客户端",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    //登陆后跳转到这
                    RedirectUris = {"https://localhost:5002/signin-oidc"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}