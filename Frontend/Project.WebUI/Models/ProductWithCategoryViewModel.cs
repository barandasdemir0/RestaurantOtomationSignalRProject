using Project.WebUI.Dtos.CategoryDtos;
using Project.WebUI.Dtos.ProductDtos;

namespace Project.WebUI.Models
{
    public class ProductWithCategoryViewModel
    {
        public List<ResultProductDto>? Products { get; set; }
        public List<ResultCategoryDto>? Categories { get; set; }
    }
}
