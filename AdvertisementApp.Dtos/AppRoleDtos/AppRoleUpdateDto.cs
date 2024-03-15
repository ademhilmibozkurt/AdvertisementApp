using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppRoleDtos
{
    // AppUser entity's dto for updating existed AppRole object
    public class AppRoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
