namespace TapiFramework.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(T entity);
        Task<T> UpdateAsync(T entity); 
        Task<T> RemoveAsync(T entity);
        Task<IEnumerable<T>> RemoveRangeAsync(T entity);    
    }
}