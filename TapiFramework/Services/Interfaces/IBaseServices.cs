namespace TapiFramework.Services.Interfaces;

public interface IBaseServices<T>
    where T : class
{
    void save(T entity);
}