using System;
using System;
using Xunit;
using WebAPI.Models;
using WebAPI.Controllers;
using System.Collections.Generic;
using WebAPI.Interfaces;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject
{
    public class TestHelper
    {
        private readonly kjaneckaContext _kjaneckaContext;

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<kjaneckaContext>();
            builder.UseInMemoryDatabase(databaseName: "kjanecka");
            var dbContextOptions = builder.Options;
            _kjaneckaContext = new kjaneckaContext(dbContextOptions);

            // Delete existing db before creating a new one
            _kjaneckaContext.Database.EnsureDeleted();
            _kjaneckaContext.Database.EnsureCreated();
            builder.EnableSensitiveDataLogging();
            
            //add to database test rows
            this.CreateDatabaseUser();
            this.CreateDatabaseIdToken();
        }
        public kjaneckaContext getContext()
        {
            return _kjaneckaContext;
        }

        public void CreateDatabaseIdToken()
        {
            GetTestSessionsIdToken().ForEach(x =>
            {
                _kjaneckaContext.IdTokens.Add(x);
            });
            _kjaneckaContext.SaveChangesAsync();
        }
        public void CreateDatabaseUser()
        {
            GetTestSessionsUser().ForEach(x =>
            {
                _kjaneckaContext.Users.Add(x);
            });
            _kjaneckaContext.SaveChangesAsync();
        }
        private List<User> GetTestSessionsUser()
        {
            var sessions = new List<User>();
            sessions.Add(new User()
            {
                UserId = 8,
                AppNickname = "test1",
                DiscordTokenId = null,
                GithubTokenId = null,
                Password = "1345"
            });
            sessions.Add(new User()
            {
                UserId = 4,
                AppNickname = "test2",
                DiscordTokenId = 567,
                GithubTokenId = null,
                Password = "1345"
            });
            sessions.Add(new User()
            {
                UserId = 5,
                AppNickname = "test3",
                DiscordTokenId = null,
                GithubTokenId = 6575,
                Password = "1345"
            });
            return sessions;
        }
        private List<IdToken> GetTestSessionsIdToken()
        {
            var sessions = new List<IdToken>();
            sessions.Add(new IdToken
            { 
              TokenId=12,
              Exp = 123454, 
              Iat = 123454, 
              Nickname = "Nickname",
              PlatformId = 1, 
              PlatformUserId = "23434",
              UserId = 231 
            });
            sessions.Add(new IdToken()
            {
                TokenId = 13,
                Exp = 123454,
                Iat = 123454,
                Nickname = "Nickname2",
                PlatformId = 1,
                PlatformUserId = "23434",
                UserId = 2311
            });
            sessions.Add(new IdToken()
            {
                TokenId = 1,
                Exp = 123454,
                Iat = 123454,
                Nickname = "Nickname3",
                PlatformId = 0,
                PlatformUserId = "23434",
                UserId = 2312
            });
            return sessions;
        }
    }

}
