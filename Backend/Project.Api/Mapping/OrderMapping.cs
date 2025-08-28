using AutoMapper;
using Project.DtoLayer.OrderDetailDto;
using Project.DtoLayer.OrderDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order,CreateOrderDto>().ReverseMap();
            CreateMap<Order,ResultOrderDto>().ReverseMap();
            CreateMap<Order,GetOrderDto>().ReverseMap();
            CreateMap<Order,UpdateOrderDto>().ReverseMap();
        }
    }
}
