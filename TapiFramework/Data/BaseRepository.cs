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
        return context.Set<T>().AsNoTracking().ToList();
    }

    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void AddRange(IEnumerable<T> entities)   
    {
        context.Set<T>().AddRange(entities);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entities)    
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Methods Asynchronous

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
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