using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AdvertisementAppUserDtos
{
    // AdvertisementAppUser entity's dto for creating new object
    public class AdvertisementAppUserCreateDto : IDto
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
