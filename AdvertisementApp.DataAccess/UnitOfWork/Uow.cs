using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.DataAccess.Repositories;
using AdvertisementApp.Entities.Entities;

namespace AdvertisementApp.DataAccess.UnitOfWork
{  
    // implements UOW interface
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;

        // dependency injection
        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        // reach repository using context
        public IRepository<T> GetRepository<T>() where T: BaseEntity 
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
