using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Insfractucture.Interfaces.Repositories
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        Task<(IEnumerable<T> Entity,int totalCount)> GetAllAsync(int pageIndex, int pageSize);
        Task<T> GetByIdAsync(TKey id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task<bool> LogicalDeleteAsync(TKey entity);
        Task SaveAsync();
    }
}
