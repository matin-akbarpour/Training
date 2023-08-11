using MediatR;
using FluentResults;
using Core.Entities;
using Application.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;
    public ReservationController(IMediator mediator) => _mediator = mediator;
    // --------------------------------------------------------------------------------------------
    [HttpPost("Register")]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> Reservation(RegisterReservationCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpGet("Get")]
    [ProducesResponseType(type: typeof(Result<Reservation>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> Get()
    {
        var result = await _mediator.Send(new GetReservationsRequest());

        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
}
