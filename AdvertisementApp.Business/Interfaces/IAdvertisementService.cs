using AdvertisementApp.Common.ResponseObjects;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
