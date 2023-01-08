using Sloths.Models;
using Sloths.Repositories;

namespace Sloths.Services
{
    public class SlothService: ISlothService
    {
        public readonly ISlothRepository repository;

        public SlothService(ISlothRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Sloth>> GetAllSloths()
        {
                var result=await this.repository.GetAllSloths();
            return result;

        }
    }
}
