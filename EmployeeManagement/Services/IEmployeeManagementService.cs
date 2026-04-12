using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Services;

public interface IEmployeeManagementService
{
    Task<string> AddEmployeeAsync(Employee employee);
    Task<string> UpdateEmployeeAsync(Employee employee);
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeAsync(Guid employeeId);
    Task<string> DeleteEmployeeAsync(Guid employeeId);
}
