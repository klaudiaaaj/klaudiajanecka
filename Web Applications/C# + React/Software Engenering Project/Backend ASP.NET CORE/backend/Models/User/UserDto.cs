using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string OrcId { get; set; }
        public bool isAuthor { get; set; }
        public bool isReviewer { get; set; }
    }

    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string OrcId { get; set; }
        public string Password { get; set; }
        public bool isAuthor { get; set; }
        public bool isReviewer { get; set; }
        public ICollection<int> categoriesId { get; set; }
    }

    public class LoginUserDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class UserInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string OrcId { get; set; }
        public bool isAuthor { get; set; }
        public bool isReviewer { get; set; }
    }
}
