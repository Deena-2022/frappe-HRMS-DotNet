using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;

namespace Database.MSSQL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BOCContext context;
        public ICustomerRepository CustomerRepository { get; }
        public IOpportunityRepository OpportunityRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(BOCContext context, ICustomerRepository customerRepository,IOpportunityRepository opportunityRepository, IUserRepository userRepository)
        {
            this.context = context;
            CustomerRepository = customerRepository;
            OpportunityRepository = opportunityRepository;
            UserRepository = userRepository;
        }
        public ICustomerRepository Customer => new CustomerRepository(context);
        public IOpportunityRepository Opportunity => new OpportunityRepository(context);
        public IUserRepository User => new UserRepository(context);
        
        public Task Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
