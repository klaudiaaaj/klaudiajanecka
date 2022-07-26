namespace WebAPI.Interfaces
{
    public interface IAuthorizationService
    {
        public bool IsGithubPushAllowed(string payload, string eventName, string signatureWithPrefix);
    }
}
