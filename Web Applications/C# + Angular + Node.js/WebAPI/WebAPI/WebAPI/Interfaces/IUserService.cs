using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;

namespace WebAPI.Interfaces
{
    public interface IUserService
    {
        public Task<PostAssignedIssue> GetUserDiscordIdFromGithub(JObject fromBody);
    }
}
