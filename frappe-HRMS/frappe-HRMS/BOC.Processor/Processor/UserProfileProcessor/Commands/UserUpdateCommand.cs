using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Domain.Enum;
using BOC.Dto.ResponseDto;
using BOC.Processor.Processor.OpportunityProcessor.Commands;
using Database.MSSQL.Interfaces;
using Database.MSSQL.Repositories;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BOC.Processor.Processor.UserProfileProcessor.Commands
{
    public class UserUpdateCommand : IRequest<UserCreateResponseDto>
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public RoleEnums Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CellPhone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserCreateResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            private readonly IValidator<UserUpdateCommand> validator;

            public UserUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserUpdateCommand> validator)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
                this.validator = validator;
            }
            public async Task<UserCreateResponseDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new FluentValidation.ValidationException(validationResult.Errors);
                }
                var user = unitOfWork.User.GetById(request.Id);
                if (user == null) throw new Exception("Please give valid userId");
                var updatedUser= mapper.Map<User>(request);
                unitOfWork.User.Update(updatedUser);
                await unitOfWork.Save();
                var responseDto = mapper.Map<UserCreateResponseDto>(request);
                responseDto.Message = "User updated successfully!";
                return responseDto;
            }
        }
    }
}
