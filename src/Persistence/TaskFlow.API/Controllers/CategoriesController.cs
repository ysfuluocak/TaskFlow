using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Features.Categories.Commands.CreateTaskCategory;
using TaskFlow.Application.Features.Categories.Queries.GetAllTaskCategoriesQuery;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTaskCategoriesQuery request)
        {
            var result = await _mediator.Send(request);

            return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
        }
    }
}
