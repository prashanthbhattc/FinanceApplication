using System.Threading.Tasks;

namespace Fis.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetAccessToken();
    }
}
