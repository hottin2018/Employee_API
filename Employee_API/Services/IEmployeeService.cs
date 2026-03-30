using Employee_API.Models;
using Employee_API.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Employee_API.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmploeeById(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task PartialUpdateAsync(int id, JsonPatchDocument<Employee> patchDocument);
        Task DeleteEmployee(int id);
    }
}
