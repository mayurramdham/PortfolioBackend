using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class TestimonialForCreationDto
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Feedback { get; set; }

        public string ClientImageUrl { get; set; }
    }

}
