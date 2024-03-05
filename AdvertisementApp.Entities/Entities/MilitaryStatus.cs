
namespace AdvertisementApp.Entities.Entities
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }

        // navigation property
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
