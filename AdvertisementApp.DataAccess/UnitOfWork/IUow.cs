using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
    // interface for Unit Of Work design pattern
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
