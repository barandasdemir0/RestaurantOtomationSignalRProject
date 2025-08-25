using Project.EntityLayer.Concrete;

namespace Project.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string? CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
