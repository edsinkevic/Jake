using Jake.Requests.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jake.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var command = new List.Query();
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Create.Request req)
    {
        var command = new Create.Command{Request = req};
        var result = await _mediator.Send(command);

        if (result.Error != null)
            return BadRequest(result.Error);

        return Ok(result);
    }
}