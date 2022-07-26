using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class IdToken
    {
        public int TokenId { get; set; }
        public int? UserId { get; set; }
        public int PlatformId { get; set; }
        public string Nickname { get; set; }
        public string PlatformUserId { get; set; }
        public int? Exp { get; set; }
        public int? Iat { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
