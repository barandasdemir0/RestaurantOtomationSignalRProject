using AutoMapper;
using Project.DtoLayer.MessageDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class MessageMapping:Profile
    {
        public MessageMapping()
        {
            CreateMap<Message,ResultMessageDto>().ReverseMap();
            CreateMap<Message,GetMessageDto>().ReverseMap();
            CreateMap<Message,CreateMessageDto>().ReverseMap();
            CreateMap<Message,UpdateMessageDto>().ReverseMap();
        }
    }
}
