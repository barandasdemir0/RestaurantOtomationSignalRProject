namespace Project.WebUI.Dtos.BookingDtos
{
    public class GetBookingDto
    {
        public int BookingID { get; set; }
        public string? BookingName { get; set; }
        public string? BookingPhone { get; set; }
        public string? BookingEmail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
