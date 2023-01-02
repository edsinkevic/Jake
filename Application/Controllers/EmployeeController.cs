using Jake.Requests.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jake.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Create.Request req)
    {
        var command = new Create.Command { Request = req };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPatch]
    [Route("privileges")]
    public async Task<IActionResult> ChangePrivileges([FromQuery] long id, ChangePrivileges.Request req)
    {
        var command = new ChangePrivileges.Command { Request = req };
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok();
    }
}