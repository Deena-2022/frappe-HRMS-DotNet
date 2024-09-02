using frappe_HRMS.Domain.Company;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Company;

namespace frappe_HRMS.Services.Services.Company
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
