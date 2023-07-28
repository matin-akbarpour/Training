using MediatR;
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
    public async Task<IActionResult> Reservation(RegisterReservationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetReservationsRequest());
        return Ok(result);
    }
}
