using BOC.Processor.Processor.LoginProcessor.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BOC.Customer_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Customer")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator mediator;

        public TokenController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Token(LoginUserQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}
