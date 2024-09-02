using BOC.Processor.Processor.UserProfileProcessor.Commands;
using Database.MSSQL.Context;
using FluentValidation;

namespace BOC.FluentValidation.Validators
{
    public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        private readonly BOCContext context;

        public UserCreateCommandValidator(BOCContext context)
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.CellPhone).NotNull().NotEmpty().Matches("^[0-9 ]*$").MaximumLength(10);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().
                WithMessage("Invalid email format.").Must(UniqueMail).WithMessage("Email already exists.");
            RuleFor(x => x.Password).NotNull().NotEmpty().Matches("((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|" +
           "(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$");
            RuleFor(x => x.Username).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LastName).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Role).IsInEnum().WithMessage("Please select a valid role");
            this.context = context;
        }
        private bool UniqueMail(string email)
        {
            var result = context.Users.Any(x => x.Email == email);
            return !result;
        }
    }
}
