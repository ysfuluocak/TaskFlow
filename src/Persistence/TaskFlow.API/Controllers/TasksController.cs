using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Features.Tasks.Commands;
using TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : Controller
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        // Şimdilik sadece ID döndürelim, sonra burayı tamamlarız.
        return Ok(new { id });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }
}