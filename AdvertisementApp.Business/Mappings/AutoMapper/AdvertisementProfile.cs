using AutoMapper;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile() 
        {
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();
        }
    }
}
