using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceListDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceCreateDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedService>().ReverseMap();
        }
    }
}
