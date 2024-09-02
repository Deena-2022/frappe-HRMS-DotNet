using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Dto.RequestDto;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace BOC.Processor.Processor.CustomerProcessor.Commands
{
    public class CustomerCreateCommand : IRequest<CustomerCreateResponseDto>
    {
        public required CreateCustomerRequestDto Customer { get; set; } 
        public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            private readonly IValidator<CustomerCreateCommand> _validator;

            public CustomerCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CustomerCreateCommand> validator)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
                _validator = validator;
            }
            public async Task<CustomerCreateResponseDto> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
                var customer = mapper.Map<Customer>(request);
                await unitOfWork.Customer.Add(customer);
                await unitOfWork.Save();
                var responseDto = mapper.Map<CustomerCreateResponseDto>(request);
                responseDto.Message = "Customer created successfully!";
                responseDto.Id = customer.Id;
                return responseDto;
            }
        }
    }
}
