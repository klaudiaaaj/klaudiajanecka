using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? DiscordTokenId { get; set; }
        public int? GithubTokenId { get; set; }
        public string AppNickname { get; set; }
        public string Password { get; set; }
    }
}
