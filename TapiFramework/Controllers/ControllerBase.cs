﻿using Microsoft.AspNetCore.Mvc;
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

            return Ok(new RequestResult<IEnumerable<TEntity>>(list));
        }
        catch
        {
            return BadRequest(new RequestResult<string>("There was an error getting the database data."));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TEntity body)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RequestResult<TEntity>("ModelState is not valid."));

        try
        {
            if(body == null)
                return BadRequest(new RequestResult<string>("The body sent is null."));

            await _service.SaveAsync(body);

            return Ok(new RequestResult<TEntity>(body));
        }
        catch
        {
            return BadRequest(new RequestResult<string>("Error at insert data in database"));
        }
    }

    #endregion
}