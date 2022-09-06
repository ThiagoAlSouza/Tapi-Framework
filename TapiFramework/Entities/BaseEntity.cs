using TapiFramework.Entities.Interfaces;

namespace TapiFramework.Entities;

public abstract class BaseEntity : IBaseEntity
{
    #region Properties

    public IList<string> Errors { get; } = new List<string>();

    #endregion

    #region Methods

    public bool Validate()
    {
        return true;
    }

    #endregion
}