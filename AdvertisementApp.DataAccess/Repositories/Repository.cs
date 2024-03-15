using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdvertisementApp.DataAccess.Repositories
{
    // database CRUD operations are here
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        // instance of context
        private readonly AdvertisementContext _context;

        // dependency injection
        public Repository(AdvertisementContext context)
        {
            _context = context;
        }

        // get all data
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        // get filtered data
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        // get data in order
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.ASC)
        {
            return orderByType == OrderByType.ASC? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() :
                                                   await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        // get filtered data in order 
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.ASC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() :
                                                   await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }


        // find by id
        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // get filter base on  filter Expression. check as no tracking
        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                                   await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity) 
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateAsync(T entity) 
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
