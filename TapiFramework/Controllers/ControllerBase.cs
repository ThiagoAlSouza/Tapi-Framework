using Microsoft.AspNetCore.Mvc;
using TapiFramework.Entities.Interfaces;
using TapiFramework.Services;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ControllerBase<TEntity, TBaseService> : ControllerBase
    where TEntity : class, IBaseEntity
    where TBaseService : class, IBaseService<TEntity>
{
    private readonly IBaseService<TEntity> _service;

    protected ControllerBase(IBaseService<TEntity> baseService)
    {
        _service = baseService;
    }

    #region Methods

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }
        catch
        {
            return BadRequest("Error");
        }
    }

    #endregion
}