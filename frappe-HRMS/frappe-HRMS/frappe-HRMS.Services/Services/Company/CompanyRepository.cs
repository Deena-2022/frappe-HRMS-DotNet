using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces.Company;
using Microsoft.EntityFrameworkCore;

namespace frappe_HRMS.Services.Services.Company
{
    public class CompanyRepository : GenericRepository<Domain.Company.Company>, ICompanyRepository
    {
        public CompanyRepository(HRMSDbContext context) : base(context)
        {
        }
        public async Task<List<Domain.Company.Company>> GetAllCompanies()
        {
            return await _context.Company.Include(c => c.Employees).ToListAsync();
        }

        public List<string?> GetCompanyList()
        {
            return  _context.Company.ToList().Select(x => x.CompanyName).ToList();
        }
    }
}
