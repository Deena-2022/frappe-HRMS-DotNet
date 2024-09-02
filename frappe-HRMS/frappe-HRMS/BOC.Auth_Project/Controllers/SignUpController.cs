using BOC.Processor.Processor.UserProfileProcessor.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOC.Auth_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IMediator mediator;

        public SignUpController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(UserCreateCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
