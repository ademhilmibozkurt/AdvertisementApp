
namespace AdvertisementApp.Entities.Entities
{
    public class AdvertisementAppUserStatus : BaseEntity
    {
        public string Definition { get; set; }

        // navigation property
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
