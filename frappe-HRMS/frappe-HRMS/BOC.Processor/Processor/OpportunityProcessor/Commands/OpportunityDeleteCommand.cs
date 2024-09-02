using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.OpportunityProcessor.Commands
{
    public class OpportunityDeleteCommand : IRequest<OpportunityDeleteResponseDto>
    {
        public int OpportunityId { get; set; }
        public class OpportunityDeleteCommandHandler : IRequestHandler<OpportunityDeleteCommand, OpportunityDeleteResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public OpportunityDeleteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<OpportunityDeleteResponseDto> Handle(OpportunityDeleteCommand request, CancellationToken cancellationToken)
            {
                var customer = _unitOfWork.Customer.GetById(request.OpportunityId);
                if (customer == null) throw new Exception("Please give valid opportunityId");
                customer.IsDeleted = true;
                _unitOfWork.Customer.Update(customer);
                await _unitOfWork.Save();
                var response = new OpportunityDeleteResponseDto
                {
                    Id = request.OpportunityId,
                    Message = "Customer Deactivated!"
                };
                return response;
            }
        }
    }
}
