using frappe_HRMS.Domain.Company;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Company;

namespace frappe_HRMS.Services.Services.Company
{
    public class EmploymentTypeRepository : GenericRepository<EmploymentType>, IEmploymentTypeRepository
    {
        public EmploymentTypeRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
