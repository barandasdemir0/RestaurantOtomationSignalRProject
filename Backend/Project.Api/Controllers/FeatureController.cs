using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.FeatureDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var detectedValues = _featureService.TGetListAll();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult FeatureInsert(CreateFeatureDto createFeatureDto)
        {
            var detectedValues = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TInsert(detectedValues);
            return Ok("Öne Çıkan Alan Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult FeatureDelete(int id)
        {
            var detectedValues = _featureService.TGetByID(id);
            _featureService.TDelete(detectedValues!);
            return Ok("Öne Çıkan Alan Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult FeatureUpdate(UpdateFeatureDto updateFeatureDto)
        {
            var detectedValues = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(detectedValues);
            return Ok("Öne Çıkan Alan Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult FeatureGetByID(int id)
        {
            var detectedValues = _featureService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
