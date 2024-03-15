namespace AdvertisementApp.Entities.Entities
{
    // users gender information
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }

        // navigation property
        public List<AppUser> AppUsers { get; set; }
    }
}
