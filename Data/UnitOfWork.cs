using Microsoft.EntityFrameworkCore;
using OrdersAPI.Insfractucture.Interfaces.Repositories;
using OrdersAPI.Insfractucture.Context;
using OrdersAPI.Insfractucture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersAPI.Core.Entities.Base;

namespace OrdersAPI.Insfractucture
{
        public interface IUnitOfWork : IDisposable
        {
            IGenericRepository<T, TKey> Repository<T, TKey>() where T : BaseEntity<TKey> where TKey : IEquatable<TKey>;
            Task CommitAsync();
        }

        public class UnitOfWork : IUnitOfWork
        {
            private readonly ApplicationDbContext _context;
            private bool disposed = false;

            public UnitOfWork(ApplicationDbContext context)
            {
                _context = context;
            }

            public IGenericRepository<T, TKey> Repository<T, TKey>() where T : BaseEntity<TKey> where TKey : IEquatable<TKey>
            {
                return new GenericRepository<T, TKey>(_context);
            }

            public async Task CommitAsync()
            {
                await _context.SaveChangesAsync();
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

}
