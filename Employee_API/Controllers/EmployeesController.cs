using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee_API.Services;
using Employee_API.Models;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _service.GetEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _service.GetEmploeeById(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await _service.CreateEmployee(employee);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _service.UpdateEmployeeAsync(employee);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployee(id);
            return Ok();
        }

    }
}
