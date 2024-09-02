using frappe_HRMS.Domain.Company;
using frappe_HRMS.Domain.Employee;
using frappe_HRMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace frappe_HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            var result = await _unitOfWork.Employee.AddAsync(employee);
            return result;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var result = await _unitOfWork.Employee.GetAll();
            return Ok(result);
        }
        [HttpPost("EditEmployee")]
        public async Task<ActionResult<Employee>> EditEmployee(Employee employee)
        {
            var result = _unitOfWork.Employee.Update(employee);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateEmployeeGroup")]
        public async Task<ActionResult<EmployeeGroup>> CreateEmployeeGroup(EmployeeGroup employeeGroup)
        {
            var result = await _unitOfWork.EmployeeGroup.AddAsync(employeeGroup);
            return result;
        }

        [HttpGet("GetAllGroups")]
        public async Task<ActionResult<List<EmployeeGroup>>> GetAllGroups()
        {
            var result = await _unitOfWork.EmployeeGroup.GetAll();
            return Ok(result);
        }
        [HttpPost("EditEmployeeGroup")]
        public async Task<ActionResult<EmployeeGroup>> EditEmployeeGroup(EmployeeGroup employeeGroup)
        {
            var result = _unitOfWork.EmployeeGroup.Update(employeeGroup);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateEmployeeGrade")]
        public async Task<ActionResult<EmployeeGrade>> CreateEmployeeGrade(EmployeeGrade employeeGrade)
        {
            var result = await _unitOfWork.EmployeeGrade.AddAsync(employeeGrade);
            return result;
        }

        [HttpGet("GetAllEmployeeGrades")]
        public async Task<ActionResult<List<EmployeeGrade>>> GetAllEmployeeGrades()
        {
            var result = await _unitOfWork.EmployeeGrade.GetAll();
            return Ok(result);
        }
        [HttpPost("EditEmployeeGrade")]
        public async Task<ActionResult<EmployeeGrade>> EditEmployeeGrade(EmployeeGrade employeeGrade)
        {
            var result = _unitOfWork.EmployeeGrade.Update(employeeGrade);
            await _unitOfWork.Save();
            return result;
        }
        [HttpPost("CreateEmploymentType")]
        public async Task<ActionResult<EmploymentType>> CreateEmploymentType(EmploymentType employmentType)
        {
            var result = await _unitOfWork.EmploymentType.AddAsync(employmentType);
            return result;
        }

        [HttpGet("GetAllemploymentTypes")]
        public async Task<ActionResult<List<EmploymentType>>> GetAllemploymentTypes()
        {
            var result = await _unitOfWork.EmploymentType.GetAll();
            return Ok(result);
        }
        [HttpPost("EditEmploymentType")]
        public async Task<ActionResult<EmploymentType>> EditEmploymentType(EmploymentType employmentType)
        {
            var result = _unitOfWork.EmploymentType.Update(employmentType);
            await _unitOfWork.Save();
            return result;
        }
    }
}
