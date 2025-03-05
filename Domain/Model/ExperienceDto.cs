using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Null indicates current position
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
