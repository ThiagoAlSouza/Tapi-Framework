namespace TapiFramework.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);  
        Task UpdateAsync(T entity); 
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);       
    }
}