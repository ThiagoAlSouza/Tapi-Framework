using Microsoft.AspNetCore.Mvc;
using TapiFramework.Entities.Interfaces;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Controllers;

public abstract class ControllerBase<TEntity, TBaseService> : ControllerBase
    where TEntity : class, IBaseEntity
    where TBaseService : class, IBaseServices<TEntity>
{
}