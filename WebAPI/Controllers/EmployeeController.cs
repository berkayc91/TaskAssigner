using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;    
        }

        [HttpGet]
        [Route("List_Employee")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("Find_Employee/{id}")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.Get(id);
            return Ok(result);
        }
    }
}
