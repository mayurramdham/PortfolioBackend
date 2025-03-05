using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SkillForCreationDto
    {
        [Required]
        public string SkillName { get; set; }

        [Range(1, 100)]
        public int Proficiency { get; set; }

        public string Category { get; set; }
    }
}
