using Fis.Services.Interfaces;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fis.Services.Implimentations
{
    public class TokenService: ITokenService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ClientCredentialsTokenRequest _clientCredentialsTokenRequest;
        private readonly IMemoryCache _cache;
        
        public TokenService(IHttpClientFactory clientFactory, ClientCredentialsTokenRequest clientCredentialsTokenRequest, IMemoryCache cache)
        {
            _clientFactory = clientFactory;
            _clientCredentialsTokenRequest = clientCredentialsTokenRequest;
            _cache = cache;
        }
        public async Task<string> GetAccessToken1()
        {
            var client = _clientFactory.CreateClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(_clientCredentialsTokenRequest);
            return tokenResponse.AccessToken;

        }

        public async Task<string> GetAccessToken()
        {
            string token = string.Empty;

            if (!_cache.TryGetValue("TOKEN", out token))
            {
                var client = _clientFactory.CreateClient();
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(_clientCredentialsTokenRequest);
                if (!string.IsNullOrEmpty(tokenResponse.Error))
                    throw new Exception("Some thing went wrong");
                var tokenmodel = tokenResponse;
                var options = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(
                              TimeSpan.FromSeconds(tokenmodel.ExpiresIn));

                _cache.Set("TOKEN", tokenmodel.AccessToken, options);

                token = tokenmodel.AccessToken;
            }

            return token;
        }
    }
}
