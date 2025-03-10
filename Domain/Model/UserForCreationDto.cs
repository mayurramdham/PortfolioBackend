using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserForCreationDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } // Plain text for creation; will be hashed in the API

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
