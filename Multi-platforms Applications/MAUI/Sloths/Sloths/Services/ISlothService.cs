using Sloths.Models;

namespace Sloths.Services
{
    public interface ISlothService
    {
        Task<IEnumerable<Sloth>> GetAllSloths();
    }
}
