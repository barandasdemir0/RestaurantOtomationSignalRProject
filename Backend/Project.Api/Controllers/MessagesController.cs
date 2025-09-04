using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.MessageDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var detectedValues = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult MessageInsert(CreateMessageDto createMessageDto)
        {

            var detectedValues = _mapper.Map<Message>(createMessageDto);
            _messageService.TInsert(detectedValues);
            return Ok("Mesajlar Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult MessageDelete(int id)
        {
            var detectedValues = _messageService.TGetByID(id);
            _messageService.TDelete(detectedValues!);//bu ! ile null değil null olursa hata fırlatır ama zaten silme yapacağımız için sorun yok
            return Ok("Mesajlar Kısmı Başarılı Bir Şekilde Silindi");
        }


        [HttpPut]
        public IActionResult MessageUpdate(UpdateMessageDto updateMessageDto)
        {

            var detectedValues = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(detectedValues);
            return Ok("Mesajlar Kısmı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult MessageGetByID(int id)
        {
            var detectedValues = _messageService.TGetByID(id);
            return Ok(detectedValues);
        }

    }
}
