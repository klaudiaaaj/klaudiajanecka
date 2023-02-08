using Microsoft.EntityFrameworkCore;
using Sloths.Models;

namespace Sloths.Repositories
{
    public class SlothRepository : ISlothRepository
    {
        readonly public SlothDbContetxt context;

        public SlothRepository(SlothDbContetxt context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Sloth>> GetAllSloths()
        {
            var result = await context.Sloth
                  .ToArrayAsync();

            return result;
        }
    }
}
