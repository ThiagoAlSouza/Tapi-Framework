using Microsoft.EntityFrameworkCore;
using TapiFramework.Interfaces;

namespace TapiFramework.Data;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbContext context;

    protected BaseRepository(DbContext context)
    {
        this.context = context;
    }

    #region Methods Synchronous

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Methods Asynchronous

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await context.Set<T>().AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    #endregion
}