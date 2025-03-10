using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Feedback { get; set; }
        public string ClientImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
