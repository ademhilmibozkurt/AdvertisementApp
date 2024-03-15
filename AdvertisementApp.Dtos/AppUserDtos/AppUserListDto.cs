using AdvertisementApp.Dtos.GenderDtos;
using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppUserDtos
{
    // AppUser entity's dto for listing objects 
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }

        // navigation property 
        public GenderListDto Gender { get; set; }
    }
}
