using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Peter");
            Manager manager = new Manager("Gosho", new List<string>() { "1", "2", "3" });
            List<Employee> employees = new List<Employee>() { employee, manager };

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
