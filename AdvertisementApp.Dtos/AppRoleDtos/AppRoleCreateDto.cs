using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppRoleDtos
{
    // AppUser entity's dto for createing new AppRole
    public class AppRoleCreateDto : IDto
    {
        public string Definition { get; set; }
    }
}
