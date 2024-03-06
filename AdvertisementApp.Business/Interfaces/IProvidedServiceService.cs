using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto,
                                                        ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
        
    }
}
