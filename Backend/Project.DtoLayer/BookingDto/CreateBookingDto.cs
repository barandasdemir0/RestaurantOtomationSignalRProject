using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DtoLayer.BookingDto
{
    public class CreateBookingDto
    {
        public string? BookingName { get; set; }
        public string? BookingPhone { get; set; }
        public string? BookingEmail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
