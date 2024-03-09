using AdvertisementApp.Dtos.GenderDtos;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
