using AdvertisementApp.Dtos.AdvertisementAppUserStatusDtos;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Dtos.MilitaryStatusDtos;

namespace AdvertisementApp.Dtos.AdvertisementAppUserDtos
{
    // AdvertisementAppUser entity's dto for listing objecs
    public class AdvertisementAppUserListDto :IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        // navigation property
        public AdvertisementListDto Advertisement { get; set; }
        public int AppUserId { get; set; }
        // navigation property
        public AppUserListDto AppUser { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        // navigation property
        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        // navigation property
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
