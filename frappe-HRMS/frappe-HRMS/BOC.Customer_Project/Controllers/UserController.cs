using BOC.Domain.Enum;
using BOC.Processor.Processor.CustomerProcessor.Commands;
using BOC.Processor.Processor.OpportunityProcessor.Commands;
using BOC.Processor.Processor.OpportunityProcessor.Queries;
using BOC.Processor.Processor.UserProfileProcessor.Commands;
using BOC.Processor.Processor.UserProfileProcessor.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BOC.Customer_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    [SwaggerTag("Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllUsersQuery()));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            return Ok(await mediator.Send(new GetByUserIdQuery { UserId = userId }));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int userId, UserUpdateCommand command)
        {
            if (userId != command.Id)
            {
                return BadRequest("Please give valid Id");
            }
            return Ok(await mediator.Send(command));
        }
        [HttpPost("Delete/{userId}")]
        public async Task<IActionResult> Deactive(int userId)
        {
            return Ok(await mediator.Send(new UserDeleteCommand { UserId = userId }));
        }
    }
}
