using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Domain.Enum;
using BOC.Dto.ResponseDto;
using BOC.Processor.Processor.CustomerProcessor.Commands;
using Database.MSSQL.Interfaces;
using FluentValidation;
using MediatR;

namespace BOC.Processor.Processor.UserProfileProcessor.Commands
{
    public class UserCreateCommand : IRequest<UserCreateResponseDto>
    {
        public string? Username { get;  set; }
        public RoleEnums Role { get;  set; }
        public string? FirstName { get;  set; }
        public string? LastName { get;  set; }
        public string? CellPhone { get;  set; }
        public string? Email { get;  set; }
        public string? Password { get; set; }
        public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserCreateResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            private readonly IValidator<UserCreateCommand> _validator;

            public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserCreateCommand> validator)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
                _validator = validator;
            }

            public async Task<UserCreateResponseDto> Handle(UserCreateCommand request, CancellationToken cancellationToken)
            {
                var user = mapper.Map<User>(request);
                await unitOfWork.User.Add(user);
                await unitOfWork.Save();
                var responseDto = mapper.Map<UserCreateResponseDto>(request);
                responseDto.Message = "User created successfully!";
                responseDto.Id = user.Id;
                return responseDto;
            }
        }
    }
}
