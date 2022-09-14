using Microsoft.AspNetCore.Mvc;
using TapiFramework.Entities.Interfaces;
using TapiFramework.Returns;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ControllerBase<TEntity, TBaseService> : ControllerBase
    where TEntity : class, IBaseEntity
    where TBaseService : class, IBaseService<TEntity>
{
    #region Private

    private readonly IBaseService<TEntity> _service;

    #endregion

    #region Constructors

    protected ControllerBase(IBaseService<TEntity> baseService)
    {
        _service = baseService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var list = await _service.GetAllAsync();

            return Ok(new RequestResult<IEnumerable<TEntity>>(list));
        }
        catch
        {
            return BadRequest(new RequestResult<TEntity>("There was an error getting the database data."));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TEntity body)
    {
        try
        {
            await _service.SaveAsync(body);

            return Ok(new RequestResult<TEntity>(body));
        }
        catch
        {
            return BadRequest(new RequestResult<TEntity>("Error at insert data in database"));
        }
    }

    #endregion
}