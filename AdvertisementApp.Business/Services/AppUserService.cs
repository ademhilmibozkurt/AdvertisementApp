using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.AppRoleDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Entities.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;

        public AppUserService(IUow uow, IMapper mapper,
                              IValidator<AppUserCreateDto> createDtoValidator,
                              IValidator<AppUserUpdateDto> updateDtoValidator, IValidator<AppUserLoginDto> loginDtoValidator) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                // 1.Yol
                //user.AppUserRoles = new List<AppUserRole>();
                //user.AppUserRoles.Add(new AppUserRole
                //{
                //    AppUser = user,
                //    AppRoleId = roleId
                //});
                //await _uow.GetRepository<AppUser>().CreateAsync(user);

                // 2. Yol
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.SaveChangesAsync();

                return new Response<AppUserCreateDto>(dto, ResponseType.Success);
            }

            return new Response<AppUserCreateDto>(dto, ResponseType.ValidationError, validationResult.ConvertToCustomValidationError());
        }

        public async Task<Response<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilter(x => x.UserName == dto.UserName && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(appUserDto, ResponseType.Success);
                }

                return new Response<AppUserListDto>("Kullanıcı adı veya şifre hatalı!", ResponseType.NotFound);
            }
            return new Response<AppUserListDto>("Kullanıcı veya şifre boş olamaz!", ResponseType.ValidationError);
        }

        public async Task<Response<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>("İlgili rol bulunamadı!", ResponseType.NotFound);
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(dto, ResponseType.Success);
        }

    }
}
