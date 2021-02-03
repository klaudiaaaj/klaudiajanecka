using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string OrcId { get; set; }
        public bool isAuthor { get; set; }
        public bool isReviewer { get; set; }
        public ICollection<CategoryReviewer> categoriesRange { get; set;}    

        public List<ArticleReviewer> ArticleReviewers { get; set; }
    }
}
