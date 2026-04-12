// See https://aka.ms/new-console-template for more information
using CollectionDemo;
using CollectionDemo.Entity;

Console.WriteLine("Hello, World!");
// Entry point of the program

EmployeeManage empManage = new EmployeeManage();
List<Employee> employees = empManage.GetEmployees();
foreach (var emp in employees)
{
    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Designation: {emp.Designation}, Salary: {emp.Salary}");
}

Employee empById = empManage.GetEmployeeById(2);
Console.WriteLine($"Employee with Id 2: Name: {empById.Name}, Designation: {empById.Designation}, Salary: {empById.Salary}");

// Unit test cases can be created to test the methods in EmployeeManage class.
