namespace Project.WebUI.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string? AboutImageUrl { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
    }
}
