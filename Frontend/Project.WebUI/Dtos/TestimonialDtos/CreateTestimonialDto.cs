using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string? TestimonialName { get; set; }
        public string? TestimonialTitle { get; set; }
        public string? TestimonialComment { get; set; }
        public string? TestimonialImageUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
