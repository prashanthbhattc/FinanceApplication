using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using IdentityModel.Client;
using Fis.Services.Interfaces;
using Fis.Entities;
using System;

namespace Fis.Services.Implimentations
{
    public class MyService : IMyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public  MyService(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _clientFactory = clientFactory;
            _tokenService = tokenService;
            _httpClient = _clientFactory.CreateClient("default");
            
        }

        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            try
            {
                _httpClient.SetBearerToken(await _tokenService.GetAccessToken());
                var response = await _httpClient.GetAsync("weatherforecast/Get");
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await response.Content.ReadAsStringAsync());
                return result;
            }
            catch(Exception)
            {
                throw;
            }
           
        }
        public async Task SaveUserDetails(WeatherForecast weatherForecast)
        {
            try
            {
                _httpClient.SetBearerToken(await _tokenService.GetAccessToken());
                var json = JsonConvert.SerializeObject(weatherForecast);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("weatherforecast/SaveDetails", data);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task GetUserDeatils()
        {
            _httpClient.SetBearerToken(await _tokenService.GetAccessToken());
            var response = await _httpClient.GetAsync("weatherforecast/GetUserDeatils");
            response.EnsureSuccessStatusCode();
        }

       
    }
}
