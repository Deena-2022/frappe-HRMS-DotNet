using BOC.FluentValidation.Validators;
using BOC.Processor.Processor.CustomerProcessor.Commands;
using BOC.Processor.Processor.OpportunityProcessor.Commands;
using BOC.Processor.Processor.UserProfileProcessor.Commands;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BOC.FluentValidation
{
    public static class DependencyInjection
    {
        public static void AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddTransient<IValidator<CustomerCreateCommand>, CustomerCreateCommandValidator>();
            services.AddTransient<IValidator<CustomerUpdateCommand>, CustomerUpdateCommandValidator>();
            services.AddTransient<IValidator<UserCreateCommand>, UserCreateCommandValidator>();
            services.AddTransient<IValidator<UserUpdateCommand>, UserUpdateCommandValidator>();
            services.AddTransient<IValidator<OpportunityCreateCommand>, OpportunityCreateCommandValidator>();
            services.AddTransient<IValidator<OpportunityUpdateCommand>, OpportunityUpdateCommandValidator>();
        }
    }
}
