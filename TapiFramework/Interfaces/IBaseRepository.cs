namespace TapiFramework.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        #region Methods Synchronous
        
        IEnumerable<T> GetAll(); 
        void Add(T entity);
        void AddRange(IEnumerable<T> entity); 
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);    

        #endregion

        #region Methods Asynchronous

        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);  
        Task UpdateAsync(T entity); 
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);

        #endregion
    }
}