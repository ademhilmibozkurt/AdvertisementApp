using AdvertisementApp.Business.Mappings.AutoMapper;
using AutoMapper;

namespace AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile()
            };
        }
    }
}
