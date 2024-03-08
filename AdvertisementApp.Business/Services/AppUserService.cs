using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    internal class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserService(IUow uow, IMapper mapper,
                              IValidator<AppUserCreateDto> createDtoValidator,
                              IValidator<AppUserUpdateDto> updateDtoValidator) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
