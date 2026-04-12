using CollectionDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo.Servcies.Implement
{
    public class EmployeeService : IEmployeeService
    {
        public List<EmployeeDto> GetAllEmployees()
        {
            // Business logic to fetch all employees would go here

        }

        public EmployeeDto GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
