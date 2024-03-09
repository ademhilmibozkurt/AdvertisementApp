using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.UI.Models;
using AutoMapper;

namespace AdvertisementApp.UI.Mappings.AutoMapper
{
    public class AppUserCreateModelProfile : Profile
    {
        public AppUserCreateModelProfile() 
        {
            CreateMap<AppUserCreateModel, AppUserCreateDto>();
        }
    }
}
