using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DtoLayer.ContactDto
{
    public class ResultContactDto
    {
        public int ContactID { get; set; }
        public string? ContactLocation { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactMail { get; set; }
        public string? FooterDescription { get; set; }
        public string? FooterOpenDayMonday { get; set; }
        public string? FooterOpenTuesday { get; set; }
        public string? FooterOpenWednesday { get; set; }
        public string? FooterOpenThursday { get; set; }
        public string? FooterOpenFriday { get; set; }
        public string? FooterOpenSaturday { get; set; }
        public string? FooterOpenSunday { get; set; }
        public string? FooterOpenSpecialDay { get; set; }
    }
}
