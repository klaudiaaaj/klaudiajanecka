using backend.Models;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string EmailAdress, string password);
        Task<bool> UserExists(string EmailAddress, string OrcId);
    }
}
