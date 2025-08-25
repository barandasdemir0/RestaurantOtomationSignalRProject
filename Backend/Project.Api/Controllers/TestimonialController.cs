using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.TestimonialDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var detectedValues = _testimonialService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult TestimonialInsert(CreateTestimonialDto createTestimonialDto)
        {
            var detectedValues = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TInsert(detectedValues);
            return Ok("Referans Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var detectedValues = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(detectedValues!);
            return Ok("Referans Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            var detectedValues = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(detectedValues);
            return Ok("Referans Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult TestimonialGetByID(int id)
        {
            var detectedValues = _testimonialService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
