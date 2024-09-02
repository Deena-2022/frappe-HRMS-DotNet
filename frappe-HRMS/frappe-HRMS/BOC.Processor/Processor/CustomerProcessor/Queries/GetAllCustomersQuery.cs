using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.CustomerProcessor.Queries
{
    public  class GetAllCustomersQuery : IRequest<List<CustomerResponseDto>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponseDto>>
        {
            private readonly IUnitOfWork _unitofwork;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitofwork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<CustomerResponseDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _unitofwork.Customer.GetAll();
                var result = _mapper.Map<List<CustomerResponseDto>>(customers);
                return result.Where(c => !c.IsDeleted).ToList();
            }
        }
    }
}
