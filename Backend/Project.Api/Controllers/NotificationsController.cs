using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.AboutDto;
using Project.DtoLayer.NotificationDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var detectedValues = _notificationService.TGetListAll();
            if (detectedValues == null || !detectedValues.Any())
            {
                return NotFound("Kayıt Bulunamadı");
            }

            return Ok(_mapper.Map<List<ResultNotificationDto>>(detectedValues));
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var detectedValues = _notificationService.TNotificationCountByStatusFalse();


            return Ok(detectedValues);
        }
        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            var detectedValues = _notificationService.TGetAllNotificationsByFalse();


            return Ok(_mapper.Map<List<ResultNotificationDto>>(detectedValues));
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
             _notificationService.TNotificationStatusChangeToTrue(id);


            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
             _notificationService.TNotificationStatusChangeToFalse(id);


            return Ok("Güncelleme Yapıldı");
        }



     

        [HttpPost]
        public IActionResult NotificationInsert(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Status = false;
            var detectedValues = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TInsert(detectedValues);
            return Ok("Bildirim Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult NotificationDelete(int id)
        {
            var detectedValues = _notificationService.TGetByID(id);
            _notificationService.TDelete(detectedValues!);//bu ! ile null değil null olursa hata fırlatır ama zaten silme yapacağımız için sorun yok
            return Ok("Bildirim Kısmı Başarılı Bir Şekilde Silindi");
        }


        [HttpPut]
        public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
        {

            var detectedValues = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(detectedValues);
            return Ok("Bildirim Kısmı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult NotificationGetByID(int id)
        {
            var detectedValues = _notificationService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
