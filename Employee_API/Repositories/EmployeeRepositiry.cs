using Employee_API.Data;
using Employee_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Repositories
{
    public class EmployeeRepositiry:IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepositiry(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var employees= await _context.Employees.ToListAsync();
            return employees;
        }
        public async Task<Employee> GetEmplyeeById(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(employee != null)
                    return employee;
            }
            return new Employee();            
            
        }
        public async Task<Employee> CreatEmployee(Employee employee)
        {
            if(_context != null)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task UpdateEmployee(Employee employee)
        {
            if(_context !=null)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
