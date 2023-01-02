using Jake.Requests.BusinessLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jake.Controllers;

[ApiController]
[Route("businesslocations")]
public class BusinessLocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public BusinessLocationController(IMediator mediator)
    {
        _mediator = mediator;
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