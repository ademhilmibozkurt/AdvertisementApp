using AutoMapper;
using FluentValidation;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Entities.Entities;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public AdvertisementService(IUow uow, IMapper mapper,
                                    IValidator<AdvertisementCreateDto> createDtoValidator,
                                    IValidator<AdvertisementUpdateDto> updateDtoValidator) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedDate, OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(dto, ResponseType.Success); 
        }
    }
}
