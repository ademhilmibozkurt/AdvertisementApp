using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.ProvidedServiceDtos
{
    // ProvidedService entity's data transfer objects for create new ProvidedService
    public class ProvidedServiceCreateDto : IDto
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
