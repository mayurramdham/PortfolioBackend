﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string PortfolioUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
