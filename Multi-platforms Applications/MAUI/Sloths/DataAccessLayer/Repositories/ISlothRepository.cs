using Sloths.Models;

namespace Sloths.Repositories
{
    public interface ISlothRepository
    {
        Task<IEnumerable<Sloth>> GetAllSloths();
    }
}
