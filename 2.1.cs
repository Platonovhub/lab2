using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public double Grade { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("C:/Users/Admin/Documents/students.TXT"))
        {
            List<Student> students = new List<Student>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(':');
                Student student = new Student();
                student.Name = parts[0];
                student.Grade = double.Parse(parts[1]);
                students.Add(student);
            }
            List<Student> filteredStudents = students.OrderByDescending(student => student.Grade).ToList();
            foreach (Student student in filteredStudents)
            {
                Console.WriteLine(student.Name + ": " + student.Grade);
            }
        }
    }
}