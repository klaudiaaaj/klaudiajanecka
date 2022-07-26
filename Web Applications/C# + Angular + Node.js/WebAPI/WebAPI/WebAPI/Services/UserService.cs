using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserService : IUserService
    {
        private readonly kjaneckaContext _context = null;

        public UserService(kjaneckaContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }

        public async Task<PostAssignedIssue> GetUserDiscordIdFromGithub(JObject fromBody)
        {
            var githubUserId = fromBody["assignee"]["id"].ToString();
            var githubTokenId = _context.IdTokens.AsQueryable().Where(x => x.PlatformUserId == githubUserId).FirstOrDefault();
            if (githubTokenId == null)
            {
                throw new ArgumentNullException(paramName: nameof(githubTokenId), message: "User with this github account does not exist in the databas  ");
            };
            Console.WriteLine("User token id", githubTokenId);

            var user = _context.Users.ToArray().Where(x => x.UserId == githubTokenId.UserId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentNullException(paramName: nameof(user), message: "User is not assigned to the following IdToken");
            }

            var discordTokenId = _context.IdTokens.AsQueryable().Where(x => x.TokenId == user.DiscordTokenId).FirstOrDefault();
            if (discordTokenId == null)
            {
                throw new ArgumentNullException(paramName: nameof(discordTokenId), message: "There is not such as IdToken");
            }

            return new PostAssignedIssue
            {
                user = user,
                discordUserId = discordTokenId.PlatformUserId,
                githubUserId = githubUserId,
                issueId = ((int)fromBody["issue"]["id"]), 
                IssueName = ((string)fromBody["issue"]["title"])
            };
        }
    }
}
