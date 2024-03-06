using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    // generic service interface for creating, updating and listing dtos
    public interface IService<CreateDto, UpdateDto, ListDto, T>
                     where CreateDto : class, IDto, new()
                     where UpdateDto : class, IUpdateDto, new()
                     where ListDto : class, IDto, new()
                     where T : BaseEntity
    {
        // all processis for dto architecture
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();

    }
}
