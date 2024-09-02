using BOC.Processor.Processor.CustomerProcessor.Commands;
using FluentValidation;

namespace BOC.FluentValidation.Validators
{
    public class CustomerCreateCommandValidator : AbstractValidator<CustomerCreateCommand>
    {
        public CustomerCreateCommandValidator()
        {
            RuleFor(x => x.Customer.Name).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Customer.Phone_Number).NotNull().NotEmpty().Matches("^[0-9 ]*$").MaximumLength(10);
            RuleFor(x => x.Customer.Email).NotNull().NotEmpty().EmailAddress().
                WithMessage("Invalid email format.");
            RuleFor(x => x.Customer.Address).NotNull().NotEmpty();
            RuleFor(x => x.Customer.City).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Customer.State).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Customer.PostalCode).NotNull().NotEmpty().Matches("^([0-9]{3} [0-9]{3})$");
        }
    }
}
