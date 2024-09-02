using BOC.Processor.Processor.CustomerProcessor.Commands;
using BOC.Processor.Processor.CustomerProcessor.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BOC.Customer_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllCustomersQuery()));
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetById(int customerId)
        {
            return Ok(await mediator.Send(new GetByCustomerIdQuery { Id = customerId }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int customerId, CustomerUpdateCommand command)
        {
            if (customerId != command.Customer.Id)
            {
                return BadRequest("Please give valid Id");
            }
            return Ok(await mediator.Send(command));
        }
        [HttpPost("Deactive/{customerId}")]
        public async Task<IActionResult> Deactive(int customerId)
        {
            return Ok(await mediator.Send(new CustomerDeactiveCommand { Id = customerId }));
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            return Ok(await mediator.Send(new CustomerDeleteCommand { Id = customerId }));
        }
    }
}
