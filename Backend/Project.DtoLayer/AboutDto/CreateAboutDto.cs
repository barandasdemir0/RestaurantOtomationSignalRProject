using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DtoLayer.AboutDto
{
    public class CreateAboutDto
    {
        public string? AboutImageUrl { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
    }
}
