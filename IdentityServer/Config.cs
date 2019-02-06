// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {               
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                //new IdentityResource("dataeventrecordsscope",new []{ "role", "admin", "user", "dataEventRecords", "dataEventRecords.admin" , "dataEventRecords.user" } ),
                //new IdentityResource("securedfilesscope",new []{ "role", "admin", "user", "securedFiles", "securedFiles.admin", "securedFiles.user"} )

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "API-1"){
                    ApiSecrets =
                    {
                        new Secret("api1Secret".Sha256())
                    }
                },
                //new ApiResource("securedFiles")
                //{
                //    ApiSecrets =
                //    {
                //        new Secret("securedFilesSecret".Sha256())
                //    },
                //    Scopes =
                //    {
                //        new Scope
                //        {
                //            Name = "securedfiles.scope",
                //            DisplayName = "Scope for the securedFiles ApiResource"
                //        }
                //    },
                //    UserClaims = { "role", "admin", "user", "securedFiles", "securedFiles.admin", "securedFiles.user" }
                //},
                //new ApiResource("dataEventRecords")
                //{
                //    ApiSecrets =
                //    {
                //        new Secret("dataEventRecordsSecret".Sha256())
                //    },
                //    Scopes =
                //    {
                //        new Scope
                //        {
                //            Name = "dataeventrecords.scope",
                //            DisplayName = "Scope for the dataEventRecords ApiResource"
                //        }
                //    },
                //    UserClaims = { "role", "admin", "user", "dataEventRecords", "dataEventRecords.admin", "dataEventRecords.user" }
                //}
                
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                //new Client
                //{
                //    ClientId = "client",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,

                //    ClientSecrets = 
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "api1" }
                //},

                //// resource owner password grant client
                //new Client
                //{
                //    ClientId = "ro.client",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                //    ClientSecrets = 
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "api1" }
                //},

                //// OpenID Connect hybrid flow and client credentials client (MVC)
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",
                //    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                //    RequireConsent = true,

                //    ClientSecrets = 
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1",
                //        "dataEventRecords",
                //    },
                //    AllowOfflineAccess = true
                //},new Client
                //{
                //    ClientName = "angularjsclient",
                //    ClientId = "angularjsclient",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,
                //    RedirectUris = new List<string>
                //    {
                //        "https://localhost:44376/authorized"
                //    },
                //    PostLogoutRedirectUris = new List<string>
                //    {
                //        "https://localhost:44346/unauthorized.html"
                //    },
                //    AllowedCorsOrigins = new List<string>
                //    {
                //        "https://localhost:44346"
                //    },
                //    AllowedScopes = new List<string>
                //    {
                //        "openid",
                //        "email",
                //        "profile",
                //        "dataEventRecords",
                //        "dataeventrecordsscope",
                //        "securedFiles",
                //        "securedfilesscope",
                //    }
                //},
                new Client
                {
                    ClientName = "angularclient",
                    ClientId = "angularclient",
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,                   
                    RequireConsent = false,                    
                    //RedirectUris = new List<string>
                    //{
                    //    "https://localhost:44311",
                    //    "https://localhost:44311/silent-renew.html"

                    //},
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200/auth-callback",
                        "http://localhost:4200",
                        "http://localhost:4200/silent-renew.html",
                        "http://localhost:4200/assets/silent-redirect.html",
                        "http://localhost:4200/assets/popup.html",
                        "http://localhost:4200/?postLogout=true",                       

                    },
                    //PostLogoutRedirectUris = new List<string>
                    //{
                    //    "https://localhost:44311/unauthorized",
                    //    "https://localhost:44311"
                    //},
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/logout-callback",
                        "http://localhost:4200/unauthorized",
                        "http://localhost:4200"
                    },
                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "https://localhost:44311",
                    //    "http://localhost:44311"
                    //},
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4200",
                        "http://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        //"dataEventRecords",
                        //"dataeventrecordsscope",
                        //"securedFiles",
                        //"securedfilesscope",
                        "api1",
                        "role",
                        "profile",
                        "email"
                    }
                },
                //new Client
                //{
                //    ClientName = "angularclientidtokenonly",
                //    ClientId = "angularclientidtokenonly",
                //    AccessTokenType = AccessTokenType.Reference,
                //    AccessTokenLifetime = 360,// 120 seconds, default 60 minutes
                //    IdentityTokenLifetime = 30,
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AlwaysIncludeUserClaimsInIdToken = true,
                //    AllowAccessTokensViaBrowser = true,
                //    RedirectUris = new List<string>
                //    {
                //        "https://localhost:44372",
                //        "https://localhost:44372/silent-renew.html"

                //    },
                //    PostLogoutRedirectUris = new List<string>
                //    {
                //        "https://localhost:44372/Unauthorized"
                //    },
                //    AllowedCorsOrigins = new List<string>
                //    {
                //        "https://localhost:44372",
                //        "http://localhost:44372"
                //    },
                //    AllowedScopes = new List<string>
                //    {
                //        "openid",
                //        "dataEventRecords",
                //        "dataeventrecordsscope",
                //        "securedFiles",
                //        "securedfilesscope",
                //        "role",
                //        "profile",
                //        "email"
                //    }
                //}
            };
        }

        //public static List<TestUser> GetUsers()
        //{
        //    return new List<TestUser>
        //    {
        //        new TestUser
        //        {
        //            SubjectId = "1",
        //            Username = "alice",
        //            Password = "password"
        //        },
        //        new TestUser
        //        {
        //            SubjectId = "2",
        //            Username = "bob",
        //            Password = "password"
        //        }
        //    };
        //}
    }
}