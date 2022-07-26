using Microsoft.EntityFrameworkCore;
using TapiFramework.Interfaces;

namespace TapiFramework.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext context; 
        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}