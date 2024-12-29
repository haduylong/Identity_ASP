using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Repositories
{
    public interface IGenericRepository<T, ID> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] filters);

        Task<T> GetAsync(ID id, params Expression<Func<T, bool>>[] filters);

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(ID id);
    }
}
