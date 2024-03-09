using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.GenderDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IUow uow, IMapper mapper,
                             IValidator<GenderCreateDto> createDtoValidator,
                             IValidator<GenderUpdateDto> updateDtoValidator) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
