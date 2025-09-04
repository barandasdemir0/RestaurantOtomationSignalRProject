using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.DiscountDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var detectedValues = _discountService.TGetListAll();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(detectedValues));
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Veri Başarıyla Güncellendi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Veri Başarıyla Güncellendi");
        }

        [HttpPost]
        public IActionResult DiscountInsert(CreateDiscountDto createDiscountDto)
        {
            var detectedValues = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TInsert(detectedValues);
            return Ok("İndirim Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DiscountDelete(int id)
        {
            var detectedValues = _discountService.TGetByID(id);
            _discountService.TDelete(detectedValues!);
            return Ok("İndirim Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
        {
            var detectedValues = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(detectedValues);
            return Ok("İndirim Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult DiscountGetByID(int id)
        {
            var detectedValues = _discountService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
