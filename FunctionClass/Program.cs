// See https://aka.ms/new-console-template for more information
using FunctionClass;

Console.WriteLine("Hello, World!");


EmployeeDemo emp = new(1001, "Ashu");
emp.DisplayEmployeeDetails();
emp.Addition(10);
emp.Addition(10, 20);
emp.Addition(10, 20, 30);
EmployeeDemo.PrintName("Ashu");
Employee employee = new Employee()
{
    EmployeeId = 1001,
    EmployeeName = "Ashu Singha",
    EmployeeAge = 25
};
emp.EmpDetail(employee);