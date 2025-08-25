using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.AboutDto;
using Project.DtoLayer.CategoryDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var detectedValues = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult AboutInsert(CreateAboutDto createAboutDto)
        {

            var detectedValues = _mapper.Map<About>(createAboutDto);
            _aboutService.TInsert(detectedValues);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            var detectedValues = _aboutService.TGetByID(id);
            _aboutService.TDelete(detectedValues!);//bu ! ile null değil null olursa hata fırlatır ama zaten silme yapacağımız için sorun yok
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Silindi");
        }


        [HttpPut]
        public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
        {

            var detectedValues = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(detectedValues);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("AboutGetByID")]
        public IActionResult AboutGetByID(int id)
        {
            var detectedValues = _aboutService.TGetByID(id);
            return Ok(detectedValues);
        }


    }
}
