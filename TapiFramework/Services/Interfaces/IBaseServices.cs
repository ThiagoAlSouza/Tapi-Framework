using TapiFramework.Entities.Interfaces;

namespace TapiFramework.Services.Interfaces;

public interface IBaseServices<T>
    where T : class, IBaseEntity
{
    #region Methods Synchronous

    IEnumerable<T> GetAll();
    void Save(T entity);
    void SaveList(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
    void RemoveList(IEnumerable<T> entities);

    #endregion

    #region Methods Asynchronous

    Task<IEnumerable<T>> GetAllAsync();
    Task SaveAsync(T entity);
    Task SaveListAsync(IEnumerable<T> entities);

    #endregion
}