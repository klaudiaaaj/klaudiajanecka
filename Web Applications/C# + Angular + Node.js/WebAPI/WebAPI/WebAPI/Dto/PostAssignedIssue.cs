using WebAPI.Models;

namespace WebAPI.Dto
{
    public class PostAssignedIssue
    {
        public User user { get; set; }
        public string discordUserId { get; set; }
        public int issueId { get; set; }
        public string githubUserId { get; set; }
        public string _IssueName { get; set; }
        public string IssueName
        {
            get => _IssueName;
            set
            {
                value = value.Replace(" ", "-");
                _IssueName = value.Length > 8 ? value.Substring(0, 8) : value;
            }
        }
    }
}
