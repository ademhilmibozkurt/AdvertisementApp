namespace AdvertisementApp.Entities.Entities
{
    // role class on program properties
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
