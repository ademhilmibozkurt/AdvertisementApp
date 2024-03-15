namespace AdvertisementApp.Entities.Entities
{
    // advertisement entity properties for job proclamation
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        // navigation property
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
