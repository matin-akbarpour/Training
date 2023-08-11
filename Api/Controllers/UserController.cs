using MediatR;
using FluentResults;
using Core.Entities;
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
    [ProducesResponseType(type: typeof(Result<string>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpPost("Signup")]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> Signup(SignupUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
    // --------------------------------------------------------------------------------------------
    [HttpGet("Get")]
    [ProducesResponseType(type: typeof(Result<User>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(type: typeof(Result), statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> Get()
    {
        var result = await _mediator.Send(new GetUsersRequest());

        if (result.IsFailed)
            return BadRequest(result);
        return Ok(result);
    }
}
