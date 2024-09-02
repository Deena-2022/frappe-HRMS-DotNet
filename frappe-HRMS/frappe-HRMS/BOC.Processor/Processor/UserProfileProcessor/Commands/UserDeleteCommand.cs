using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using MediatR;

namespace BOC.Processor.Processor.UserProfileProcessor.Commands
{
    public class UserDeleteCommand : IRequest<UserDeleteResponseDto>
    {
        public int UserId { get; set; }
        public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, UserDeleteResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UserDeleteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<UserDeleteResponseDto> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
            {
                var user = _unitOfWork.User.GetById(request.UserId);
                if (user == null) throw new Exception("Please give valid userId");
                user.IsActive = false;
                _unitOfWork.User.Update(user);
                await _unitOfWork.Save();
                var response = new UserDeleteResponseDto
                {
                    Id = request.UserId,
                    Message = "User deleted successfully!"
                };
                return response;
            }
        }
    }
}
