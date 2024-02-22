using Microsoft.EntityFrameworkCore;
using OrdersAPI.Core.Entities.Base;
using OrdersAPI.Insfractucture.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Insfractucture.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<(IEnumerable<T>, int)> GetAllAsync(int pageIndex, int pageSize)
        {
            var query = _dbSet.Where(e => e.Active);

            var entities = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalCount = await query
                .CountAsync();

            return (entities,totalCount);
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e => e.Id.Equals(id) && e.Active);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> LogicalDeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                entity.Active = false;
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            return false;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
