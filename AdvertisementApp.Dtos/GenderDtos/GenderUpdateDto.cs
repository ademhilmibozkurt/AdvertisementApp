using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.GenderDtos
{
    // Gender entity's dto for updating existed Gender 
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
