using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.UserProfileProcessor.Queries
{
    public class GetByUserIdQuery : IRequest<UserResponseDto>
    {
        public int UserId { get; set; }
        public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, UserResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<UserResponseDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
            {
                var user = _unitOfWork.User.GetById(request.UserId);
                var result = _mapper.Map<UserResponseDto>(user);
                if (user == null) throw new Exception("Please give valid userId");
                return result;
            }
        }
    }
}
