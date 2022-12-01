using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Interfaces
{
    public interface ICatalogRepository<T> : IDisposable where T : class
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate);
        Task<IEnumerable<TModel>> GetQueryListAsync<TModel>(Expression<Func<T, bool>>? predicate, Expression<Func<T, TModel>> selector);
        Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>> orderBy, bool isDesc = false);
        Task<IEnumerable<T>> GetQueryListAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>> orderBy, bool isDesc = false, int skip = 0, int take = 0);

        Task<IEnumerable<T>> Includes(bool asNoTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(int id);
    }
}
