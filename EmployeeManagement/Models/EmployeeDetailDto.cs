using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Models;

public class EmployeeDetailDto
{
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public int TotoalEmployee { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotoalEmployee / PageSize);
}
