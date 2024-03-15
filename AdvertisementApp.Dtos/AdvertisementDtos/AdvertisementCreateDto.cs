using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AdvertisementDtos
{
    // Advertisement entity's dto for createing new objects
    public class AdvertisementCreateDto : IDto
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }
    }
}
