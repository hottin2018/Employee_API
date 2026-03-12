using Employee_API.Models;

namespace Employee_API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmplyeeById(int id);
        Task<Employee> CreatEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);

    }
}
