using TapiFramework.Entities.Interfaces;

namespace TapiFramework.Repositories.Interfaces;

public interface IBaseRepository<T> 
    where T : class, IBaseEntity
{
    #region Methods Synchronous

    IEnumerable<T> GetAll();
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    #endregion

    #region Methods Asynchronous

    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    #endregion
}