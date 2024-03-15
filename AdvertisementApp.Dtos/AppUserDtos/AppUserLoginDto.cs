using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppUserDtos
{
    // AppUser entity's dto for login process 
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set;}
        public string Password { get; set;}
        public bool RememberMe { get; set; }
    }
}
