
namespace AdvertisementApp.Entities.Entities
{
    // applications "user" properties for advertisement
    public class AdvertisementAppUser : BaseEntity
    {
        // foreign key - navigation property
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        // foreign key - navigation property
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // foreign key - navigation property
        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; }

        // foreign key - navigation property
        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        
        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }
    
        public string CvPath { get; set; }
    }
}
