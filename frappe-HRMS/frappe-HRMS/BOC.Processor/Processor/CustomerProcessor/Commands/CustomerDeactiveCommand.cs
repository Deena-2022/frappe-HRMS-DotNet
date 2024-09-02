using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.CustomerProcessor.Commands
{
    public class CustomerDeactiveCommand : IRequest<DeleteCustomerResponseDto>
    {
        public int Id { get; set; }
        public class CustomerDeactiveCommandHandler : IRequestHandler<CustomerDeactiveCommand, DeleteCustomerResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CustomerDeactiveCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DeleteCustomerResponseDto> Handle(CustomerDeactiveCommand request, CancellationToken cancellationToken)
            {
                var customer =  _unitOfWork.Customer.GetById(request.Id);
                if (customer == null) throw new Exception("Please give valid customerId");
                customer.IsDeleted = true;
                _unitOfWork.Customer.Update(customer);
                await _unitOfWork.Save();
                var response = new DeleteCustomerResponseDto
                {
                    Id = request.Id,
                    Message = "Customer Deactivated!"
                };
                return response;
            }
        }
    }
}
