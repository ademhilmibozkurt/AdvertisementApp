using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Models
{
    public class AppUserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }

        public SelectList Genders { get; set; }
    }
}
