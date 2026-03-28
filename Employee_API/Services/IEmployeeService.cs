using Employee_API.Models;
using Employee_API.Repositories;

namespace Employee_API.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmploeeById(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployee(int id);
    }
}
