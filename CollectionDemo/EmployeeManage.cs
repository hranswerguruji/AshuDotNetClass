using System;
using System.Collections.Generic;
using System.Text;
using CollectionDemo.Entity;
namespace CollectionDemo;

internal class EmployeeManage
{
    List<Employee> employees = new List<Employee>();
    public List<Employee> GetEmployees()
    {
        employees = new List<Employee>()
        {
            new Employee(){ Id=1, Name="Ashua", Designation="Developer", Salary=1200.50},
            new Employee(){ Id=2, Name="Ravi", Designation="Tester", Salary=1000.50},
            new Employee(){ Id=3, Name="John", Designation="Manager", Salary=1500.50},
            new Employee(){ Id=4, Name="Smith", Designation="Designer", Salary=1100.50},
        };
        return employees;
    }
    public Employee GetEmployeeById(int id)
    {
        // forreach loop
      Employee employee =  employees.FirstOrDefault(emp=> emp.Id == id);
        // First, FirstOrDefault
        // Single, SingleOrDefault

        // First-- Halpa--> 1000--> 100-->Ashu
        // Single-- Mahanga--> 1000--> 100--> Ashu, 120, 200---> 1000

        return employee;
    }
}
