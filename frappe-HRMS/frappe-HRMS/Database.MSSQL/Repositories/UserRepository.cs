using BOC.Domain.DataEntity;
using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;

namespace Database.MSSQL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BOCContext context) : base(context)
        {
        }
    }
}
