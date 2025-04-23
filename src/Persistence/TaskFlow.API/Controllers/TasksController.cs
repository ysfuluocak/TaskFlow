using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Features.TaskEntities.Commands.CreateTask;
using TaskFlow.Application.Features.TaskEntities.Commands.DeleteTask;
using TaskFlow.Application.Features.TaskEntities.Commands.UpdateTask;
using TaskFlow.Application.Features.TaskEntities.Queries.GetTasksQuery;
using TaskFlow.Application.Features.TaskEntities.Queries.GetAllTasksQuery;
using TaskFlow.Application.Features.TaskEntities.Queries.GetByIdTaskQuery;

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
    public async Task<IActionResult> Create([FromBody] CreateTaskEntityCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetByIdTaskEntityQuery(id));
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTaskEntitiesQuery request)
    {
        var result = await _mediator.Send(request);
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskEntityCommand command)
    {
        if (id != command.Id)
            return BadRequest("Task ID mismatch");

        var result = await _mediator.Send(command);
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteTaskEntityCommand(id));
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFilteredTasks([FromQuery] GetTaskEntitiesQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }
}