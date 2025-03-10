using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; } // NULL if currently working
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
