using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net.Http;
using WebAPI.Dto;
using WebAPI.Interfaces;

namespace WebAPI.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IConfiguration _cfg;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IUserService _userRepo;


        public GitHubService(IConfiguration configuration, IHttpClientFactory clientFactory, IUserService userRepo)
        {
            _cfg = configuration;
            _clientFactory = clientFactory;
            _userRepo = userRepo;
        }

        public async void GetDataFromPayLoadOpened(string body)
        {
            var issuee = JsonConvert.DeserializeObject<JObject>(body);

            PostOpenedIssueDto dto = new PostOpenedIssueDto
            {
                IssueId = ((int)issuee["issue"]["id"]),
                IssueName = issuee["issue"]["title"].ToString(),
                IssueDescription = issuee["issue"]["body"].ToString(),
            };
       
            var content = $"_bot createtextchannel {dto.IssueId} {dto.IssueName}";
            ExecuteRequest(content);
        }

        public async void GetDataFromPayLoadAssigned(string body)
        {
            try
            {
                var fromBody = JsonConvert.DeserializeObject<JObject>(body);
                var userAssigned = await _userRepo.GetUserDiscordIdFromGithub(fromBody);

                var content = $"_bot assignuser {userAssigned.issueId} {userAssigned.IssueName} {userAssigned.discordUserId}";

                ExecuteRequest(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void getAction(string body)
        {
            var method = JsonConvert.DeserializeObject<JObject>(body)["action"].ToString();

            switch (method)
            {
                case "opened":
                    GetDataFromPayLoadOpened(body);
                    break;
                case "assigned":
                    GetDataFromPayLoadAssigned(body);
                    break;
                default:
                    new NullReferenceException();
                    break;
            }

        }
        public RestRequest createRequest(String content)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Cookie", "__cfruid=73479a1a950aa3f5a235aa7a50dfc838e428048d-1638054450; __dcfduid=f5885c41448f11ec88b642010a0a0080; __sdcfduid=f5885c41448f11ec88b642010a0a00806627f9458ff4ff63c90ecb7170ddf137be27538dbc6ec44d8aad15a4031cc97f");

            var body2 = @"{
                            " + "\n" +
                            @$"  ""content"": ""{ content}""
                            " + "\n" +
                        @"}";

            request.AddParameter("application/json", body2, ParameterType.RequestBody);

            return request;
        }

        public IRestResponse ExecuteRequest(string content)
        {
            var client = new RestClient(_cfg.GetSection("WebHookDiscord").Value);
            return client.Execute(createRequest(content));
        }
    }
}
