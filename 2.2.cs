using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public int Experience { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("C:/Users/Admin/Documents/employees.txt"))
        {
            List<Employee> employees = new List<Employee>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                Employee employee = new Employee();
                employee.Name = parts[0];
                employee.Salary = double.Parse(parts[1]);
                employee.Experience = int.Parse(parts[2]);
                employees.Add(employee);
            }
            List<Employee> filteredEmployees = employees.OrderByDescending(employees => employees.Name).ToList();

            foreach (Employee employee in employees)
            {
                Console.WriteLine("{0}: зарплата (grn) - {1}, стаж (рік) - {2}", employee.Name, employee.Salary, employee.Experience);
            }
        }
    }
}
