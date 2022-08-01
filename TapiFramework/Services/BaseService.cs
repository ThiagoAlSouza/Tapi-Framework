using TapiFramework.Repositories.Interfaces;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Services;

public class BaseService<T> : IBaseServices<T>
    where T : class
{
    private readonly IBaseRepository<T> _baseRepository;
    
    public BaseService(IBaseRepository<T> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    #region Methods Synchronous
    
    public virtual IEnumerable<T> GetAll()
    {
        return _baseRepository.GetAll();
    }

    public virtual void Save(T entity)
    {
        _baseRepository.Add(entity);
    }

    public virtual void SaveList(IEnumerable<T> entities)
    {
        _baseRepository.AddRange(entities);
    }

    public virtual void Update(T entity)
    {
        _baseRepository.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _baseRepository.Remove(entity);
    }

    public virtual void RemoveList(IEnumerable<T> entities)
    {
        _baseRepository.RemoveRange(entities);
    }

    #endregion

    #region Methods Asynchronous

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _baseRepository.GetAllAsync();
    }

    public virtual async Task SaveAsync(T entity)
    {
        await _baseRepository.AddAsync(entity);
    }

    public virtual async Task SaveListAsync(IEnumerable<T> entities)
    {
        await _baseRepository.AddRangeAsync(entities);
    }

    #endregion
}