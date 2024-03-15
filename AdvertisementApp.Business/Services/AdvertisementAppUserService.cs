using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        // take instances
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;

        // dependency injection
        public AdvertisementAppUserService(IUow uow, IMapper mapper, IValidator<AdvertisementAppUserCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        // creating AdvertisementAppUser entity
        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            // is dto valid?
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                // is that dto same as we look for x?
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilter(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                // if is not exist
                if (control == null)
                {
                    // map dto to AdvertisementAppUser
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);

                    // creating process
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();

                    // response process succeeded
                    return new Response<AdvertisementAppUserCreateDto>(dto, ResponseType.Success);
                }

                // list of validation error using CustomValidationError class. return response as ValidationError
                List<CustomValidationError> errors = new List<CustomValidationError>{ new CustomValidationError { ErrorMessage = "Bu ilana daha önce başvuruldu!", PropertyName = "" } };
                return new Response<AdvertisementAppUserCreateDto>(dto, ResponseType.ValidationError, errors);
            }

            return new Response<AdvertisementAppUserCreateDto>(dto, ResponseType.ValidationError, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();
        
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);

            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }
    }
}
