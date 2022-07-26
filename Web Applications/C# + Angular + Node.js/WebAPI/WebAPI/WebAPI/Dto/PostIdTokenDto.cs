using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class PostIdTokenDto
    {
        public int? UserId { get; set; }
        public int PlatformId { get; set; }
        public string Nickname { get; set; }
        public string PlatformUserId { get; set; }
        public int? Exp { get; set; }
        public int? Iat { get; set; }
    }
}
