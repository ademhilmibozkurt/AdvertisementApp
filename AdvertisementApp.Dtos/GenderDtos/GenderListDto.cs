using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.GenderDtos
{
    // Gender entity's dto for listing Gender
    public class GenderListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
