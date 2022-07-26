namespace WebAPI.Interfaces
{
    public interface IGitHubService
    {
        public void GetDataFromPayLoadOpened(string body);
        public void GetDataFromPayLoadAssigned(string body);
        public void getAction(string body);

    }
}
