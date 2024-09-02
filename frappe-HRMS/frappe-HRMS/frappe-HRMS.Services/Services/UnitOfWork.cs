using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces;
using frappe_HRMS.Services.Interfaces.Company;
using frappe_HRMS.Services.Interfaces.Employee;
using frappe_HRMS.Services.Services.Company;
using frappe_HRMS.Services.Services.Employee;

namespace frappe_HRMS.Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRMSDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; }
        public IBranchRepository BranchRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IEmploymentTypeRepository EmploymentTypeRepository { get; }
        public IEmployeeGradeRepository EmployeeGradeRepository { get; }
        public IEmployeeGroupRepository EmployeeGroupRepository { get; }
        public ISignupRepository SignupRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public UnitOfWork(HRMSDbContext context,
            ISignupRepository signupRepository,
            ICompanyRepository companyRepository,
            IEmployeeRepository employeeRepository,
            IBranchRepository branchRepository,
            IDepartmentRepository departmentRepository,
            IEmploymentTypeRepository employmentTypeRepository,
            IEmployeeGradeRepository employeeGradeRepository,
            IEmployeeGroupRepository employeeGroupRepository)
        {
            _context = context;
            SignupRepository = signupRepository;
            CompanyRepository = companyRepository;
            EmployeeRepository = employeeRepository;
            BranchRepository = branchRepository;
            DepartmentRepository = departmentRepository;
            EmploymentTypeRepository = employmentTypeRepository;
            EmployeeGradeRepository = employeeGradeRepository;
            EmployeeGroupRepository = employeeGroupRepository;
        }


        public ISignupRepository Signup => new SignupRepository(_context);
        public ICompanyRepository Company => new CompanyRepository(_context);
        public IEmployeeRepository Employee => new EmployeeRepository(_context);
        public IBranchRepository Branch => new BranchRepository(_context);
        public IDepartmentRepository Department => new DepartmentRepository(_context);
        public IDesignationRepository Designation => new DesignationRepository(_context);
        public IEmploymentTypeRepository EmploymentType => new EmploymentTypeRepository(_context);
        public IEmployeeGroupRepository EmployeeGroup => new EmployeeGroupRepository(_context);
        public IEmployeeGradeRepository EmployeeGrade => new EmployeeGradeRepository(_context);

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
