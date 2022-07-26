using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WebAPI.Extensions;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class GithubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;
        private readonly IAuthorizationService _authorizationService;
        public IConfiguration _cfg { get; set; }

        public GithubController( IConfiguration cfg, IGitHubService gitHubService, IAuthorizationService authorizationService)
        {
            _cfg = cfg;
            _gitHubService = gitHubService;
            _authorizationService = authorizationService;
        }

        [GitHubWebHook(EventName = "issues")]
        public async Task<IActionResult> GitIssueHandler( JObject data)
        {
            var request = this.HttpContext.Request;

            var requestBodyContent = await GetRequestBody.ReadRequestBodyAsync(request);
            Request.Headers.TryGetValue("X-Hub-Signature", out StringValues signature);
            if (!this._authorizationService.IsGithubPushAllowed(requestBodyContent, "issues", signature))
            {
                return Unauthorized();
            }
            _gitHubService.getAction(requestBodyContent);

            return Ok("works with configured secret!");
        }

    }
}
