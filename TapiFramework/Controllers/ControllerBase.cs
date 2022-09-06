using Microsoft.AspNetCore.Mvc;
using TapiFramework.Entities.Interfaces;
using TapiFramework.Returns;
using TapiFramework.Services.Interfaces;

namespace TapiFramework.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ControllerBase<T, TBaseService> : ControllerBase
    where T : class, IBaseEntity
    where TBaseService : class, IBaseService<T>
{
    private readonly IBaseService<T> _service;

    protected ControllerBase(IBaseService<T> baseService)
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

            return Ok(new RequestResult<IEnumerable<T>>(list));
        }
        catch
        {
            return BadRequest(new RequestResult<T>("There was an error getting the database data."));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] T body)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RequestResult<T>("ModelState is not valid."));

        try
        {
            if(body == null)
                return BadRequest(new RequestResult<T>("The body sent is null."));

            await _service.SaveAsync(body);

            return Ok(new RequestResult<T>(body));
        }
        catch
        {
            return BadRequest(new RequestResult<T>("Error at insert data in database"));
        }
    }

    #endregion
}