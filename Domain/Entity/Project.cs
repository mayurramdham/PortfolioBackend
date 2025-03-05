using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LiveUrl { get; set; }
        public string RepoUrl { get; set; }
        public string TechStack { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
