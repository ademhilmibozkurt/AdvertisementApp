using AdvertisementApp.Dtos.AppRoleDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    internal class AppRoleProfile : Profile
    {   
        public AppRoleProfile() 
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}
