using MediatR;
using Application.Location;
using Infrastructure.Models;
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
    [HttpGet("Get/{pageNumber:int}/{pageLimit:int}")]
    public async Task<IActionResult> Get(int pageNumber, int pageLimit, string? title, string? locationType)
    {
        var result = await _mediator.Send(new GetLocationsRequest
            {pageNumber = pageNumber, pageLimit = pageLimit, title = title, locationType = locationType});
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterLocationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPatch("Update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<Locations>? patchDocument)
    {
        var result = await _mediator.Send(new UpdateLocationCommand {Id = id, PatchDocument = patchDocument});
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand {Id = id});
        return Ok(result);
    }
}
