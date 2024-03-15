using AdvertisementApp.Business.Mappings.AutoMapper;
using AutoMapper;

namespace AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        // create instances of profile classes
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile(),
            };
        }
    }
}
