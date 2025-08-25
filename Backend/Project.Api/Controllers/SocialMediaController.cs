using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.SocialMediaDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var detectedValues = _socialMediaService.TGetListAll();
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult SocialMediaInsert(CreateSocialMediaDto createSocialMediaDto)
        {
            var detectedValues = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TInsert(detectedValues);
            return Ok("Sosyal Medya Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var detectedValues = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(detectedValues!);
            return Ok("Sosyal Medya Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var detectedValues = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(detectedValues);
            return Ok("Sosyal Medya Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult SocialMediaGetByID(int id)
        {
            var detectedValues = _socialMediaService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
