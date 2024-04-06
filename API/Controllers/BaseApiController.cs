using Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{

    private IMediator _mediator;


    protected IMediator Mediator => _mediator ??=
        HttpContext.RequestServices.GetService<IMediator>();

/// <summary>
/// receives an action result of type TDto, to catch the response and return it to the client with http response
/// </summary>
/// <typeparam name="TDto"> dto object returned</typeparam>
/// <param name="result"> result object with the dto inside, if an error occours IsSuccess is false and result .value is null</param>
/// <returns></returns>
    protected ActionResult HandleResult<TDto>(Result<TDto> result)
    {
        if (result == null) return NotFound();
        if (result.IsSuccess && result.Value != null)
            return Ok(result.Value);
        if (result.IsSuccess && result.Value == null)
            return NotFound();
        return BadRequest(result.Error);
    }
/// <summary>
/// abstraction for manage pagination, receive a TEntity, and add to the Response object a header with the page info
/// </summary>
/// <typeparam name="TEntity"> objects that represents an entity or a DTO</typeparam>
/// <param name="result"></param>
/// <returns></returns>
    protected ActionResult HandlePageResult<TEntity>(Result<PagedList<TEntity>> result)
    {
        if (result == null) return NotFound();
        if (result.IsSuccess && result.Value != null)
        {
            Response.AddPaginationHeader(result.Value.CurrentPage,
                                         result.Value.PageSize,
                                         result.Value.TotalCount,
                                         result.Value.TotalPages);
            return Ok(result.Value);
        }

        if (result.IsSuccess && result.Value == null)
            return NotFound();
        return BadRequest(result.Error);
    }
}
