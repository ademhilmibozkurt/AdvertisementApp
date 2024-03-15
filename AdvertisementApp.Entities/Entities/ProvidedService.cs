
namespace AdvertisementApp.Entities.Entities
{
    // service for additional processes
    public class ProvidedService : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
