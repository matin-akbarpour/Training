using MediatR;
using FluentResults;
using Core.Entities;
using Application.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;
    public LocationController(IMediator mediator) => _mediator = mediator;
    // --------------------------------------------------------------------------------------------
    [HttpGet("Get")]
    [ProducesResponseType(type: typeof(Result<Location>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get([FromQuery] GetLocationsRequest request)
    {
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPost("Register")]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Register(RegisterLocationCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPatch("Update/{id:int}")]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Update(int id, JsonPatchDocument<Location> patchDocument)
    {
        var result = await _mediator.Send(new UpdateLocationCommand {Id=id, PatchDocument=patchDocument});
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpDelete("Delete/{id:int}")]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand {Id=id});
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
}
