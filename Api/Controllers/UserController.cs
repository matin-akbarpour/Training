using MediatR;
using Application.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator) => _mediator = mediator;
    // --------------------------------------------------------------------------------------------
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPost("Signup")]
    public async Task<IActionResult> Signup(SignupUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetUsersRequest());
        return Ok(result);
    }
}
