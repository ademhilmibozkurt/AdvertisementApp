using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.ProvidedServiceDtos
{
    // ProvidedService entity's data transfer objects for update existed ProvidedService
    public class ProvidedServiceUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
