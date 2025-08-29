using Project.EntityLayer.Concrete;

namespace Project.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

    }
}
