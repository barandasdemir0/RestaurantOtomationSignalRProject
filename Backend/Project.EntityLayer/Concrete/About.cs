using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string? AboutImageUrl { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
    }
}
