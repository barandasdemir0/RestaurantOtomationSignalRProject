using AutoMapper;
using Project.DtoLayer.NotificationDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class NotificationMapping:Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification , ResultNotificationDto>().ReverseMap();
            CreateMap<Notification , GetNotificationDto>().ReverseMap();
            CreateMap<Notification , CreateNotificationDto>().ReverseMap();
            CreateMap<Notification , UpdateNotificationDto>().ReverseMap();
        }
    }
}
