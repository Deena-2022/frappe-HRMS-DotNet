using frappe_HRMS.Domain;
using frappe_HRMS.Domain.Company;
using frappe_HRMS.Domain.Employee;
using frappe_HRMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace frappe_HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("SetupOrganisation")]
        public async Task<ActionResult<Company>> SetupOrganisation(Company company)
        {
            // Add the initial company record
            var result = await _unitOfWork.Company.AddAsync(company);
            await _unitOfWork.Save();

            // If the company is a demo version, add a second entry with modified details
            if (company.IsDemo)
            {
                // Create a new company object for the demo version
                var demoCompany = new Company
                {
                    CompanyName = $"{company.CompanyName} (Demo)",
                    CompanyAbbrevation = $"{company.CompanyAbbrevation}D",
                    FinancialYearBeginsOn = company.FinancialYearBeginsOn,
                    IsDemo = false,
                    Currency = company.Currency,
                    Country = company.Country,
                    Designation = company.Designation,
                    TimeZone = company.TimeZone,
                    PhoneNumber = company.PhoneNumber,
                    Industry = company.Industry,
                    NumberOfEmployess = company.NumberOfEmployess,
                    Language = company.Language
                };

                // Add the demo company record to the database
                await _unitOfWork.Company.AddAsync(demoCompany);
                await _unitOfWork.Save();
            }

            // Return the result of the initial company creation
            return Ok(result);
        }

        [HttpPost("CreateCompany")]
        public async Task<ActionResult<Company>> CreateCompany(Company company)
        {
            var result = await _unitOfWork.Company.AddAsync(company);
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var result =  await _unitOfWork.Company.GetAllCompanies();
            return Ok(result);
        }

        [HttpPost("EditCompany")]
        public async Task<ActionResult<Company>> EditCompany(Company company)
        {
            var result = _unitOfWork.Company.Update(company);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateBranch")]
        public async Task<ActionResult<Branch>> CreateBranch(Branch branch)
        {
            var result = await _unitOfWork.Branch.AddAsync(branch);
            return result;
        }

        [HttpGet("GetAllBranches")]
        public async Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            var result = await _unitOfWork.Branch.GetAll();
            return Ok(result);
        }

        [HttpPost("EditBranch")]
        public async Task<ActionResult<Branch>> EditBranch(Branch branch)
        {
            var result = _unitOfWork.Branch.Update(branch);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateDepartment")]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            var result = await _unitOfWork.Department.AddAsync(department);
            return result;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<List<Department>>> GetAllDepartments()
        {
            var result = await _unitOfWork.Department.GetAll();
            return Ok(result);
        }

        [HttpPost("EditDepartment")]
        public async Task<ActionResult<Department>> EditDepartment(Department department)
        {
            var result = _unitOfWork.Department.Update(department);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateDesignation")]
        public async Task<ActionResult<Designation>> CreateDesination(Designation designation)
        {
            var result = await _unitOfWork.Designation.AddAsync(designation);
            return result;
        }

        [HttpGet("GetAllDesignations")]
        public async Task<ActionResult<List<Designation>>> GetAllDesignations()
        {
            var result = await _unitOfWork.Designation.GetAll();
            return Ok(result);
        }

        [HttpPost("EditDesignation")]
        public async Task<ActionResult<Designation>> EditDesignation(Designation designation)
        {
            var result = _unitOfWork.Designation.Update(designation);
            await _unitOfWork.Save();
            return result;
        }
        [HttpGet("GetCompanyList")]
        public ActionResult<List<Company>> GetCompanyList()
        {
            var result =  _unitOfWork.Company.GetCompanyList();
            return Ok(result);
        }
    }
}
