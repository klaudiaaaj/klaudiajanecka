using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class PostUserDto
    {
        public int? DiscordTokenId { get; set; }
        public int? GithubTokenId { get; set; }
        public string AppNickname { get; set; }
        public string Password { get; set; }
    }
}
