using Employee_API.Models;
using Employee_API.Repositories;
namespace Employee_API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repo = repository;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _repo.GetEmployees();
        }
        public async Task<Employee> GetEmploeeById(int id)
        {
            return await _repo.GetEmplyeeById(id);
        }
        public async Task CreateEmployee(Employee employee)
        {
            await _repo.CreatEmployee(employee);
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _repo.UpdateEmployee(employee);
        }
        public async Task DeleteEmployee(int id)
        {
            await _repo.DeleteEmployee(id);
        }
    }
}
