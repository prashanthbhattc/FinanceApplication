using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace Fis.WebApi
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            new ApiResource("api1", "My API1"),
            new ApiResource("api3", "My API2")
        };

        public static IEnumerable<Client> Clients =>

             new List<Client>
          {
        new Client
        {
            ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes =
            { OidcConstants.GrantTypes.ClientCredentials
            },

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".ToSha256())
            },

            // scopes that client has access to
            AllowedScopes = { "api3", "api1" }
        }
    };
    }
}
