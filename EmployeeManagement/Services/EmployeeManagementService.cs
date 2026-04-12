using EmployeeManagement.Data;
using EmployeeManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    private readonly AppDbContext _dbContext;

    public EmployeeManagementService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddEmployeeAsync(Employee employee)
    {
        var getEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email == employee.Email);

        if (getEmployee == null) { // This is new employee, so we can add it to the database

            _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChangesAsync();

            return "Employee added successfully.";

        } else {
            return "An employee with the same email already exists.";

        }
    }

    public Task<string> DeleteEmployeeAsync(Guid employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> GetEmployeeAsync(Guid employeeId)
    {
        Employee employee =await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        return (employee);
    }

    public Task<List<Employee>> GetEmployeesAsync()
    {
       return _dbContext.Employees.ToListAsync();
    }

    public Task<string> UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }
}
