using frappe_HRMS.Domain.Company;
using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Company;

namespace frappe_HRMS.Services.Services.Company
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(HRMSDbContext context) : base(context)
        {
        }
    }
}
