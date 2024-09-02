using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using Database.MSSQL.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC.Processor.Processor.OpportunityProcessor.Queries
{
    public class GetOpportunityByIdQuery : IRequest<OpportunityResponseDto>
    {
        public int OpportunityId { get; set; }
        public class GetOpportunityByIdQueryHandler : IRequestHandler<GetOpportunityByIdQuery, OpportunityResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetOpportunityByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<OpportunityResponseDto> Handle(GetOpportunityByIdQuery request, CancellationToken cancellationToken)
            {
                var opportunity = _unitOfWork.Opportunity.GetById(request.OpportunityId);
                var result = _mapper.Map<OpportunityResponseDto>(opportunity);
                if (opportunity == null) throw new Exception("Please give valid opportunityId");
                return result;
            }
        }
    }
}
