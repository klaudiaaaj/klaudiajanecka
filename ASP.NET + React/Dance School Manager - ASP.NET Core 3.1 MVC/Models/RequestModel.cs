using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^[A-Z][a-z]{1,30}$", ErrorMessage ="The name has to start with capital letter and be in range from 1 to 30 characters")]
        public string Name { get; set; }

      
        [Required]
        [StringLength(40)]
        [RegularExpression(@"^[A-Z][a-z]+(-[A-Z][a-z]+)?$", ErrorMessage = "Surname has to start from capital letter, it can consist of 2 surnames, but second surname has to be separated by '-' character")]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public decimal Phonenr { get; set; }

    }
}
