using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto,
                                          ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceService(IUow uow, IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator,
                                      IValidator<ProvidedServiceUpdateDto> updateDtoValidator) :
                                      base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
