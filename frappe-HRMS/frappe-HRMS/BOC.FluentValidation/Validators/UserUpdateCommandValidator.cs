using BOC.Domain.DataEntity;
using BOC.Processor.Processor.UserProfileProcessor.Commands;
using Database.MSSQL.Context;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC.FluentValidation.Validators
{
    public class UserUpdateCommandValidator: AbstractValidator<UserUpdateCommand>
    {
        private readonly BOCContext context;

        public UserUpdateCommandValidator(BOCContext context)
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.CellPhone).NotNull().NotEmpty().Matches("^[0-9 ]*$").MaximumLength(10);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().
                WithMessage("Invalid email format.").Must((model, email) => UniqueMail(email, model.Id)).WithMessage("Email already exists.");
            RuleFor(x => x.Password).NotNull().NotEmpty().Matches("((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|" +
           "(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$");
            RuleFor(x => x.Username).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LastName).NotNull().NotEmpty().Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.Role).IsInEnum().WithMessage("Please select a valid role");
            this.context = context;
        }
        private bool UniqueMail(string email, int id)
        {
            var result = context.Users.Any(x => x.Email == email && x.Id != id);
            return !result;
        }
    }
}
