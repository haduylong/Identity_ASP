using Identity.Domain.Repositories;
using Identity.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public class GenericRepository<T, ID> : IGenericRepository<T, ID> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new NullReferenceException();
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(ID id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException("Entity not found");

            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] filters)
        {
            IQueryable<T> query = _dbSet;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(ID id, params Expression<Func<T, bool>>[] filters)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                return null;

            IQueryable<T> query = _dbSet.Where(e => e == entity);

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
