// See https://aka.ms/new-console-template for more information
using EmployeeClass;

Console.WriteLine("Welcome to Ashu program...");

Employee employee = new Employee();
//employee.GetEmployee("Ashu", 10001, "ashu@gmail.com");

Console.WriteLine("Please provide your details:");
Console.WriteLine("Enter your name:");
string name = Console.ReadLine();

Console.WriteLine("Enter your emp id:");
int empId =Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter your email address:");
string email = Console.ReadLine();

employee.GetEmployee(name, empId,email);

