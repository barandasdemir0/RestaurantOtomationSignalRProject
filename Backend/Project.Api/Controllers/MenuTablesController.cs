using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.MenuTableDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTablesService _menuTablesService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTablesService menuTablesService, IMapper mapper)
        {
            _menuTablesService = menuTablesService;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTablesService.TMenuTableCount());
        }

        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTablesService.TChangeMenuTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            _menuTablesService.TChangeMenuTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }


        [HttpGet]
        public IActionResult MenuTableList()
        {
            var detectedValues = _menuTablesService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult MenuTableInsert(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = true;
            var detectedValues = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTablesService.TInsert(detectedValues);
            return Ok("Masa  Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult MenuTableDelete(int id)
        {
            var detectedValues = _menuTablesService.TGetByID(id);
            _menuTablesService.TDelete(detectedValues!);//bu ! ile null değil null olursa hata fırlatır ama zaten silme yapacağımız için sorun yok
            return Ok("Masa  Kısmı Başarılı Bir Şekilde Silindi");
        }


        [HttpPut]
        public IActionResult MenuTableUpdate(UpdateMenuTableDto updateMenuTableDto)
        {

            var detectedValues = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTablesService.TUpdate(detectedValues);
            return Ok("Masa  Kısmı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult MenuTableGetByID(int id)
        {
            var detectedValues = _menuTablesService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
