
namespace AdvertisementApp.Entities.Entities
{
    // application user current status information
    public class AdvertisementAppUserStatus : BaseEntity
    {
        public string Definition { get; set; }

        // navigation property
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
