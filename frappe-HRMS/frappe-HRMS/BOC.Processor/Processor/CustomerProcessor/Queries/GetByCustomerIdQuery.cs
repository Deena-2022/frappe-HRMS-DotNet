using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.CustomerProcessor.Queries
{
    public class GetByCustomerIdQuery : IRequest<CustomerResponseDto>
    {
        public int Id { get; set; }
        public class GetByCustomerIdQueryHandler : IRequestHandler<GetByCustomerIdQuery, CustomerResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetByCustomerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public  async Task<CustomerResponseDto> Handle(GetByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var customer =  _unitOfWork.Customer.GetById(request.Id);
                var result = _mapper.Map<CustomerResponseDto>(customer);
                if (customer == null) throw new Exception("Please give valid customerId");
                return result;
            }
        }        
    }
}
