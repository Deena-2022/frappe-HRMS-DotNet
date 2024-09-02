using Database.MSSQL.Interfaces;
using Database.MSSQL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Database.MSSQL
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
