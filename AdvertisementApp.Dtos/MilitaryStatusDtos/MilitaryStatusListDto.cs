using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.MilitaryStatusDtos
{
    // MilitaryStatus entity's dto for listing
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
