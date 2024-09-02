using BOC.Domain.DataEntity;
using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;

namespace Database.MSSQL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BOCContext context) : base(context)
        {

        }
    }
}
