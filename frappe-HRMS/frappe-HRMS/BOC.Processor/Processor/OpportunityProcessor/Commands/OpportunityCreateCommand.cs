using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.OpportunityProcessor.Commands
{
    public class OpportunityCreateCommand : IRequest<OpportunityCreateResponseDto>
    {
        public int CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Action { get; set; }
        public DateTime Due_Date { get; set; }
        public bool IsOpportunity { get; set; } = true;
        public class OpportunityCreateCommandHandler : IRequestHandler<OpportunityCreateCommand, OpportunityCreateResponseDto>
        {
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;

            public OpportunityCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }
            public async Task<OpportunityCreateResponseDto> Handle(OpportunityCreateCommand request, CancellationToken cancellationToken)
            {
                var opportunity = mapper.Map<Opportunity>(request);
                await unitOfWork.Opportunity.Add(opportunity);
                await unitOfWork.Save();
                var responseDto = mapper.Map<OpportunityCreateResponseDto>(request);
                responseDto.Message = "User created successfully!";
                responseDto.Id = opportunity.Id;
                return responseDto;
            }
        }
    }
}
