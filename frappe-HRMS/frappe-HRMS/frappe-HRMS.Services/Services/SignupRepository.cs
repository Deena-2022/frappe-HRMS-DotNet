using frappe_HRMS.Domain;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces;

namespace frappe_HRMS.Services.Services
{
    public class SignupRepository : GenericRepository<User>, ISignupRepository
    {
        public SignupRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
