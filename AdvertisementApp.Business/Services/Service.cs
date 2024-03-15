using AutoMapper;
using FluentValidation;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entities.Entities;
using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
                   where CreateDto : class, IDto, new()
                   where UpdateDto : class, IUpdateDto, new()
                   where ListDto : class, IDto, new()
                   where T : BaseEntity
    {
        private readonly IUow _uow;    
        private readonly IMapper _mapper;    
        private readonly IValidator<CreateDto> _createDtoValidator;    
        private readonly IValidator<UpdateDto> _updateDtoValidator;

        public Service(IUow uow, IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(dto, ResponseType.Success);
            }

            // Business/Extensions/ConvertToCustomValidationError
            // if not work then add a new ctor in Response[T]
            return new Response<CreateDto>(dto, ResponseType.ValidationError, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);

            return new Response<List<ListDto>>(dto,ResponseType.Success);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilter(x => x.Id == id);

            if (data == null)
                return new Response<IDto>($"{id} Id'ye sahip veri bulunamadı!", ResponseType.NotFound);

            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(dto, ResponseType.Success);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);

            if (data == null)
                return new Response($"{id} Id'ye sahip veri bulunamadı!", ResponseType.NotFound);

            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var unchanged = await _uow.GetRepository<T>().FindAsync(dto.Id);

                if (unchanged == null)
                    new Response<UpdateDto>($"{dto.Id} id'ye sahip veri bulunamadı!!", ResponseType.NotFound);

                var updated = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(updated, unchanged);
                await _uow.SaveChangesAsync();

                return new Response<UpdateDto>(dto, ResponseType.Success);

            }

            return new Response<UpdateDto>(dto, ResponseType.ValidationError, result.ConvertToCustomValidationError());
        }
    }
}
