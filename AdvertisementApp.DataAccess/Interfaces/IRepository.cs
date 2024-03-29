﻿using AdvertisementApp.Common.Enums;
using AdvertisementApp.Entities.Entities;
using System.Linq.Expressions;

namespace AdvertisementApp.DataAccess.Interfaces
{
    // interface for database CRUD operation container class
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.ASC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.ASC);
        Task<T> FindAsync(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
