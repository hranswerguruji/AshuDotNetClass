using EmployeeManagement.Models;
using EmployeeManagement.Models.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeManagementService _employeeManagementService;
        public EmployeeController(IEmployeeManagementService employeeManagementService)
        {
            _employeeManagementService = employeeManagementService;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2)
        {
            var employees = await _employeeManagementService.GetEmployeesAsync();

            EmployeeDetailDto employeeDetailDto = new EmployeeDetailDto
            {
                Employees = employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                TotoalEmployee = employees.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(employeeDetailDto);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeManagementService.AddEmployeeAsync(employee);
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditEmployee(Guid id)
        {
            Employee employee = await _employeeManagementService.GetEmployeeAsync(id);
            return View(employee);
        }
    }
}
