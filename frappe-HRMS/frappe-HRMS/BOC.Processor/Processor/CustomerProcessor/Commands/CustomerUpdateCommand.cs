using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Dto.RequestDto;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using FluentValidation;
using MediatR;

namespace BOC.Processor.Processor.CustomerProcessor.Commands
{
    public class CustomerUpdateCommand : IRequest<CustomerUpdateResponseDto>
    {
        public required UpdateCustomerRequestDto Customer { get; set; }
        public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, CustomerUpdateResponseDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IValidator<CustomerUpdateCommand> _validator;

            public CustomerUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CustomerUpdateCommand> validator)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _validator = validator;
            }
            public async Task<CustomerUpdateResponseDto> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new FluentValidation.ValidationException(validationResult.Errors);
                }
                var customer =  _unitOfWork.Customer.GetById(request.Customer.Id);
                if (customer == null) throw new Exception("Please give valid customerId");
                var updatedCustomer = _mapper.Map<Customer>(request);
                _unitOfWork.Customer.Update(updatedCustomer);
                await _unitOfWork.Save();
                var responseDto = _mapper.Map<CustomerUpdateResponseDto>(request);
                responseDto.Message = "Customer updated successfully!";
                return responseDto;
            }
        }
    }
}
