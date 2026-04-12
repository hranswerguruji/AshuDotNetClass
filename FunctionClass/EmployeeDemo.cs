using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionClass;

internal class EmployeeDemo
{
    // data type-> int, string, double, bool
    // access modifier-> public, private, protected, internal   
    int empId;
    string name;

    // mememory
    // statc and head memory
    // struct will store in stack memory
    // class/reference will store in head memory

    //public EmployeeDemo()
    //{
    //    empId = 0;
    //    name = "Default Name";
    //}
    public EmployeeDemo(int empId, string name)
    {
        this.empId = empId;
        this.name = name;
    }
    // ctor
    //Gacutil command

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Employee ID: " + empId);
        Console.WriteLine("Employee Name: " + name);
    }

    public void Addition(int a)
    {       
        Console.WriteLine("Sum: " + a);
    }
    public void Addition(int a, int b)
    {
        int sum= a + b;
        Console.WriteLine("Sum: " + sum);
    }

    public void Addition(int a, int b, int c)
    {
        int sum = a + b+c;
        Console.WriteLine("Sum: " + sum);
    }

    public static void PrintName(string name)
    {       
        Console.WriteLine($"Hello {name}");
    }
    public void EmpDetail(Employee employee)
    {
        Console.WriteLine($"Employee ID: {employee.EmployeeId}, Employee Name: {employee.EmployeeName}, Employee Age: {employee.EmployeeAge}");
    }
}


 class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int EmployeeAge { get; set; }
}