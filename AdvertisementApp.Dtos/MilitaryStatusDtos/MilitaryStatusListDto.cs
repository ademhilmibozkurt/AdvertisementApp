using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.MilitaryStatusDtos
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
