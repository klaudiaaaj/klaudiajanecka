using System;

namespace WebAPI.Dto
{
    public class PostOpenedIssueDto
    {
        public int IssueId { get; set; }
        public string _IssueName { get; set; }
        public string IssueDescription { get; set; }

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