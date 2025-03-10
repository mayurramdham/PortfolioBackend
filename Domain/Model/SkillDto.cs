using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int Proficiency { get; set; } // 1 to 100 scale
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
