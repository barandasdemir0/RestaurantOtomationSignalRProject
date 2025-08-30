using AutoMapper;
using Project.DtoLayer.BasketDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket ,ResultBasketDto>().ReverseMap();
            CreateMap<Basket ,GetBasketDto>().ReverseMap();
            CreateMap<Basket ,CreateBasketDto>().ReverseMap();
            CreateMap<Basket ,UpdateBasketDto>().ReverseMap();
        }

    }
}
