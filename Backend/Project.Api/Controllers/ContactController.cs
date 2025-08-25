using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.ContactDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var detectedValues = _contactService.TGetListAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult ContactInsert(CreateContactDto createContactDto)
        {
            var detectedValues = _mapper.Map<Contact>(createContactDto);
            _contactService.TInsert(detectedValues);
            return Ok("İletişim Başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {
            var detectedValues = _contactService.TGetByID(id);
            _contactService.TDelete(detectedValues!);
            return Ok("İletişim Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
        {
            var detectedValues = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(detectedValues);
            return Ok("İletişim Başarıyla Güncellendi");
        }

        [HttpGet("ContactGetByID")]
        public IActionResult ContactGetByID(int id)
        {
            var detectedValues = _contactService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
