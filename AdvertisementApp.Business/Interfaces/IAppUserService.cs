using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.Dtos.AppRoleDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleID);
        Task<Response<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
        Task<Response<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
    }
}
