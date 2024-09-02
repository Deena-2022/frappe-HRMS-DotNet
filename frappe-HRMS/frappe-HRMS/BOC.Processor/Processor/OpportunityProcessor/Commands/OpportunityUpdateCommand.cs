using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Dto.ResponseDto;
using Database.MSSQL.Interfaces;
using Database.MSSQL.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC.Processor.Processor.OpportunityProcessor.Commands
{
    public class OpportunityUpdateCommand : IRequest<OpportunityCreateResponseDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Action { get; set; }
        public DateTime Due_Date { get; set; }
        public class OpportunityUpdateCommandHandler : IRequestHandler<OpportunityUpdateCommand, OpportunityCreateResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            private readonly IValidator<OpportunityUpdateCommand> validator;

            public OpportunityUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<OpportunityUpdateCommand> validator)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
                this.validator = validator;
            }
            public async Task<OpportunityCreateResponseDto> Handle(OpportunityUpdateCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new FluentValidation.ValidationException(validationResult.Errors);
                }
                var customer = unitOfWork.Opportunity.GetById(request.Id);
                if (customer == null) throw new Exception("Please give valid customerId");
                var updatedOpportunity = mapper.Map<Opportunity>(request);
                unitOfWork.Opportunity.Update(updatedOpportunity);
                await unitOfWork.Save();
                var responseDto = mapper.Map<OpportunityCreateResponseDto>(request);
                responseDto.Message = "Opportunity updated successfully!";
                return responseDto;
            }
        }
    }
}
