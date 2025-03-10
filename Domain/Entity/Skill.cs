using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int Proficiency { get; set; } // 1-100 scale
        public string Category { get; set; } // Frontend, Backend, Database, etc.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
