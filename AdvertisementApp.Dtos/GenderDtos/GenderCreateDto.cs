using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.GenderDtos
{
    // Gender entity's dto for createing new Gender
    public class GenderCreateDto : IDto
    {
        public string Definition { get; set; }
    }
}
