using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using Database.MSSQL.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BOC.Processor.Processor.OpportunityProcessor.Queries
{
    public class GetAllOpportunitiesQuery : IRequest<List<OpportunityResponseDto>>
    {
        public class GetAllOpportunitiesQueryHandler : IRequestHandler<GetAllOpportunitiesQuery, List<OpportunityResponseDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllOpportunitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<OpportunityResponseDto>> Handle(GetAllOpportunitiesQuery request, CancellationToken cancellationToken)
            {
                var opportunities =  await _unitOfWork.Opportunity.GetAll();
                var result = _mapper.Map<List<OpportunityResponseDto>>(opportunities);
                return result;
            }
        }
    }
}
