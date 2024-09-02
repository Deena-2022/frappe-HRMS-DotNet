using AutoMapper;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.UserProfileProcessor.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserResponseDto>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.User.GetAll();
                var result = _mapper.Map<List<UserResponseDto>>(users);
                return result.Where(c => c.IsActive).ToList();
            }
        }
    }
}
