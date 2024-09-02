using frappe_HRMS.Domain.Employee;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Employee;

namespace frappe_HRMS.Services.Services.Employee
{
    public class EmployeeGradeRepository : GenericRepository<EmployeeGrade>, IEmployeeGradeRepository
    {
        public EmployeeGradeRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
