using BOC.Processor.Processor.CustomerProcessor.Commands;
using BOC.Processor.Processor.CustomerProcessor.Queries;
using BOC.Processor.Processor.OpportunityProcessor.Commands;
using BOC.Processor.Processor.OpportunityProcessor.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BOC.Customer_Project.Controllers
{
    [Authorize]
    [SwaggerTag("Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunityController : ControllerBase
    {
        private readonly IMediator mediator;

        public OpportunityController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllOpportunitiesQuery()));
        }
        [HttpGet("{opportunityId}")]
        public async Task<IActionResult> GetById(int opportunityId)
        {
            return Ok(await mediator.Send(new GetOpportunityByIdQuery { OpportunityId = opportunityId }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(OpportunityCreateCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int opportunityId, OpportunityUpdateCommand command)
        {
            if (opportunityId != command.Id)
            {
                return BadRequest("Please give valid Id");
            }
            return Ok(await mediator.Send(command));
        }
        [HttpPost("Delete/{opportunityId}")]
        public async Task<IActionResult> Deactive(int opportunityId)
        {
            return Ok(await mediator.Send(new OpportunityDeleteCommand { OpportunityId = opportunityId }));
        }
    }
}

