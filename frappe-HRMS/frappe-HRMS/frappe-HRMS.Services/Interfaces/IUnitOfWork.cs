using frappe_HRMS.Services.Interfaces.Company;
using frappe_HRMS.Services.Interfaces.Employee;

namespace frappe_HRMS.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ISignupRepository Signup { get; }
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IBranchRepository Branch { get; }
        IDesignationRepository Designation { get; }
        IDepartmentRepository Department { get; }
        IEmploymentTypeRepository EmploymentType { get; }
        IEmployeeGroupRepository EmployeeGroup { get; }
        IEmployeeGradeRepository EmployeeGrade { get; }

        Task<int> Save();
    }
}
