using TapiFramework.Entities.Interfaces;

namespace TapiFramework.Returns;

public class RequestResult<T>
    where T : class
{
    #region Constructors

    public RequestResult(T data, IList<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public RequestResult(T data)
    {
        Data = data;
    }

    public RequestResult(IList<string> errors)
    {
        Errors = errors;
    }

    public RequestResult(string error)
    {
       Errors?.Add(error);
    }

    #endregion

    #region Properties

    public T? Data { get; private set; }
    public IList<string>? Errors { get; private set; }

    #endregion
}