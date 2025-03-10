using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserProfileForUpdateDto
    {
        [Required]
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string PortfolioUrl { get; set; }
    }
}
