using frappe_HRMS.Domain.Company;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Company;

namespace frappe_HRMS.Services.Services.Company
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
