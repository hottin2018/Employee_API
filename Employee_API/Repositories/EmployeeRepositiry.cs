using System;
using Employee_API.Data;
using Employee_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        /* PSEUDOCODE / PLAN (detailed)
         - Validate the incoming patch document is not null; throw if it is.
         - Retrieve the target employee by id using the asynchronous repository method.
         - Await the retrieval so we have an Employee instance, not a Task.
         - If the retrieved employee is non-null:
             - Apply the JsonPatchDocument to the Employee instance using the correct overload:
               - Use patchDocument.ApplyTo(employee) (no second argument), or provide an error handler if needed.
             - Mark the entity as updated in the DbContext.
             - Persist changes with SaveChangesAsync.
         - End.
        */
        public async Task PartialUpdate(int id, JsonPatchDocument<Employee> patchDocument)
        {
            if (patchDocument == null)
                throw new ArgumentException("Invalid Patch Document");

            // Await the async retrieval to get the actual Employee instance
            var employee = await GetEmplyeeById(id);

            if (employee != null)
            {
                // Apply the patch to the Employee instance (correct overload)
                patchDocument.ApplyTo(employee);

                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
