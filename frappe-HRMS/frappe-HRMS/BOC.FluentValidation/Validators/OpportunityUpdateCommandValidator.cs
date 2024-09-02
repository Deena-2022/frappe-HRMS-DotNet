using BOC.Processor.Processor.OpportunityProcessor.Commands;
using FluentValidation;

namespace BOC.FluentValidation.Validators
{
    public class OpportunityUpdateCommandValidator : AbstractValidator<OpportunityUpdateCommand>
    {
        public OpportunityUpdateCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("Please select a customer.");
            RuleFor(command => command.Status).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(command => command.SalesPersonId).NotEmpty().WithMessage("Please select a sales person.");
        }
    }
}
