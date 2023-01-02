using Jake.Requests.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jake.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new List.Query();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Create.Request request)
    {
        var command = new Create.Command { Request = request };
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(Update.Request request)
    {
        var command = new Update.Command { Request = request };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(Delete.Request request)
    {
        var command = new Delete.Command { Request = request };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPost("create/verify")]
    public async Task<IActionResult> CreateVerify(CreateVerify.Request request)
    {
        var command = new CreateVerify.Command { Request = request };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login.Request request)
    {
        var command = new Login.Command { LoginCredentials = request.LoginCredentials };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(string sessionToken)
    {
        var command = new Logout.Command { SessionToken = sessionToken };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }
}