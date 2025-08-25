using AutoMapper;
using Project.DtoLayer.AboutDto;
using Project.DtoLayer.FeatureDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        }
    }
}
