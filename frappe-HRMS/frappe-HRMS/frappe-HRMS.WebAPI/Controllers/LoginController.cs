using frappe_HRMS.Domain;
using frappe_HRMS.Services.Dto;
using frappe_HRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace frappe_HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginRequestDto request)
        {
            var result = _unitOfWork.Signup.GetAll().Result.Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
            if (result == null)
            {
                return Ok("Invalid credentials provided.");
            }
            return Ok("Login Successfully!");          
        }
    }
}
