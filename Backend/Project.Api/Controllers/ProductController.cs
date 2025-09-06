using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.ProductDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var detectedValues = _productService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(detectedValues));
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {  
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductWithCategoryNameHamburger")]
        public IActionResult ProductWithCategoryNameHamburger()
        {  
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductWithCategoryNamePizza")]
        public IActionResult ProductWithCategoryNamePizza()
        {  
            return Ok(_productService.TProductCountByCategoryNamePizza());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {  
            return Ok(_productService.TProductPriceAverage());
        }
        [HttpGet("ProductPriceByMax")]
        public IActionResult ProductPriceByMax()
        {  
            return Ok(_productService.TProductPriceByMax());
        }
        [HttpGet("ProductPriceByMin")]
        public IActionResult ProductPriceByMin()
        {  
            return Ok(_productService.TProductPriceByMin());
        }

        [HttpGet("ProductPriceByHamburger")]
        public IActionResult ProductPriceByHamburger()
        {  
            return Ok(_productService.TProductPriceByHamburger());
        }
        [HttpGet("GetLast6Products")]
        public IActionResult GetLast6Products()
        {  
            return Ok(_productService.TGetLast6Products());
        }

        [HttpPost]
        public IActionResult ProductInsert(CreateProductDto createProductDto)
        {
            var detectedValues = _mapper.Map<Product>(createProductDto);
            _productService.TInsert(detectedValues);
            return Ok("Ürün Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            var detectedValues = _productService.TGetByID(id);
            _productService.TDelete(detectedValues!);
            return Ok("Ürün Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
        {
            var detectedValues = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(detectedValues);
            return Ok("Ürün Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult ProductGetByID(int id)
        {
            var detectedValues = _productService.TGetByID(id);
            return Ok(detectedValues);
        }


        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var detectedValues = _productService.TGetProductsWithCategories();
            return Ok(_mapper.Map<List<ResultProductWithCategory>>(detectedValues));
        }
    }
}
