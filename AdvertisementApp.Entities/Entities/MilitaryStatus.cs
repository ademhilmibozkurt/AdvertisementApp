
namespace AdvertisementApp.Entities.Entities
{
    // military information for male users
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }

        // navigation property
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
