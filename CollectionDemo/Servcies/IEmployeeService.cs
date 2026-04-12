using CollectionDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo.Servcies
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
    }
}
