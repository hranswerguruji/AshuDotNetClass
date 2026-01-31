using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeClass;

public class Employee
{
    public void GetEmployee(string name, int empId, string email)
    {
        Console.WriteLine($"Hello {name} your emmployee Id {empId} and email is {email}");
        Console.WriteLine("Thanks for comming...");
    }
}
