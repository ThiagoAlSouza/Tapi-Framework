using TapiFramework.Repositories.Interfaces;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Services;

public class BaseService<T> : IBaseServices<T>
    where T : class
{
    private readonly IBaseRepository<T> baseRepository;
    
    public BaseService(IBaseRepository<T> baseRepository)
    {
        this.baseRepository = baseRepository;
    }

    #region Methods

    public void save(T entity)
    {
        baseRepository.Add(entity);
    }

    #endregion
}