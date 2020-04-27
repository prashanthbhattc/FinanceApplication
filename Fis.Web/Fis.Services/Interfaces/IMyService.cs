using Fis.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fis.Services.Interfaces
{
    public interface IMyService
    {
        Task<IEnumerable<WeatherForecast>> Get();
        Task SaveUserDetails(WeatherForecast weatherForecast);
        Task GetUserDeatils();
    }
}