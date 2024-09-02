using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.CustomerProcessor.Commands
{
    public  class CustomerDeleteCommand : IRequest<DeleteCustomerResponseDto>
    {
        public int Id { get; set; }
        public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand, DeleteCustomerResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;

            public CustomerDeleteCommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<DeleteCustomerResponseDto> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.Customer.Delete(request.Id);
                await unitOfWork.Save();
                var response = new DeleteCustomerResponseDto
                {
                    Id = request.Id,
                    Message = "Customer deleted successfully!"
                };
                return response;
            }
        }
    }
}
