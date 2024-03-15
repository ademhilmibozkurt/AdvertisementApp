using AdvertisementApp.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    // AdvertisementsAppUser property configuration operations. implements interface
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        // build AdvertisementAppUser objects properties 
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            // set an paired primary key
            builder.HasIndex(x => new { x.AdvertisementId, x.AppUserId }).IsUnique();
            
            // relations between entities
            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.AdvertisementAppUserStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementAppUserStatusId);
            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.MilitaryStatusId);

            // property settings
            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();
        }
    }
}
