using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Employee;

namespace frappe_HRMS.Services.Services.Employee
{
    public class EmployeeRepository : GenericRepository<Domain.Employee.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
