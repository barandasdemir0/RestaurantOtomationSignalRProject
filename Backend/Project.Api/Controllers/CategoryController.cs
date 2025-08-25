using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.BookingDto;
using Project.DtoLayer.CategoryDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var detectedValues = _categoryService.TGetListAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult CategoryInsert(CreateCategoryDto createCategoryDto)
        {
            var detectedValues = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TInsert(detectedValues);
            return Ok("Kategori Başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var detectedValues = _categoryService.TGetByID(id);
            _categoryService.TDelete(detectedValues!);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            var detectedValues = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(detectedValues);
            return Ok("Kategori Başarıyla Güncellendi");
        }

        [HttpGet("CategoryGetByID")]
        public IActionResult CategoryGetByID(int id)
        {
            var detectedValues = _categoryService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
