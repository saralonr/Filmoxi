using Catalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogRepository<T> : ICatalogRepository<T> where T : class
    {
        private readonly CatalogContext _context;
        private DbSet<T> _dbSet;

        public CatalogRepository(CatalogContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate)
        {
            if (predicate != null)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<TModel>> GetQueryListAsync<TModel>(Expression<Func<T, bool>>? predicate, Expression<Func<T, TModel>> selector)
        {
            if (predicate != null)
            {
                return await _dbSet.Where(predicate).Select(selector).ToListAsync();
            }
            return await _dbSet.Select(selector).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>> orderBy, bool isDesc = false)
        {
            if (predicate != null)
            {
                if (isDesc)
                {
                    return await _dbSet.Where(predicate).OrderByDescending(orderBy).ToListAsync();
                }
                return await _dbSet.Where(predicate).OrderBy(orderBy).ToListAsync();
            }

            if (isDesc)
            {
                return await _dbSet.OrderByDescending(orderBy).ToListAsync();
            }
            return await _dbSet.OrderBy(orderBy).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>> orderBy, bool isDesc = false, int skip = 0, int take = 0)
        {
            if (predicate != null)
            {
                if (isDesc)
                {
                    return await _dbSet.Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take).ToListAsync();
                }
                return await _dbSet.Where(predicate).OrderBy(orderBy).Skip(skip).Take(take).ToListAsync();
            }

            if (isDesc)
            {
                return await _dbSet.OrderByDescending(orderBy).Skip(skip).Take(take).ToListAsync();
            }
            return await _dbSet.OrderBy(orderBy).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }
        public async Task<T> GetAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public async Task<IEnumerable<T>> Includes(bool asNoTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes)
        {
            if (asNoTracking)
            {
                IQueryable<T> query = _dbSet.Where(predicate).AsNoTracking().Include(includes[0]);
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return await query.ToListAsync();
            }
            else
            {
                IQueryable<T> query = _dbSet.Where(predicate).Include(includes[0]);
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return await query.ToListAsync();
            }
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
