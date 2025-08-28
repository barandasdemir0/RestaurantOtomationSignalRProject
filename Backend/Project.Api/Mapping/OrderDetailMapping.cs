using AutoMapper;
using Project.DtoLayer.OrderDetailDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class OrderDetailMapping:Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail,CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail,ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail,UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail,GetOrderDetailDto>().ReverseMap();
        }
    }
}
