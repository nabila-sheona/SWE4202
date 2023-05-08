using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11A
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Hospital hospital=new Hospital();
            Nurse nurse1 = new Nurse { Name = "John Smith", Address = "123 Main St", PhoneNumber = 555-1234, Email = "john.smith@example.com", HireDate = new DateTime(2010, 1, 1), Position = "Charge Nurse", Department = "Orthopedic" };
            Nurse nurse2 = new Nurse { Name = "Jane Doe", Address = "456 Oak St", PhoneNumber = 555-5678, Email = "jane.doe@example.com", HireDate = new DateTime(2015, 6, 1), Position = "Assisting Nurse", Department = "Pedriatric" };
            Doctor doctor1 = new Doctor { Name = "David Lee", Address = "789 Maple St", PhoneNumber = 555-9012, Email = "david.lee@example.com", HireDate = new DateTime(2005, 12, 1), Position = "Head of Department", Department = "Cardiology", Degrees = new List<string> { "MD", "PhD" }, CoWorkers = new List<Doctor> { } };
            Doctor doctor2 = new Doctor { Name = "Mary Johnson", Address = "321 Pine St", PhoneNumber = 555-3456, Email = "mary.johnson@example.com", HireDate = new DateTime(2018, 3, 1), Position = "Junior Doctor", Department = "ER", Degrees = new List<string> { "MD" }, CoWorkers = new List<Doctor> { doctor1 } };
            ManagementStaff staff1 = new ManagementStaff { Name = "Robert Chen", Address = "987 Elm St", PhoneNumber = 555-7890, Email = "robert.chen@example.com", HireDate = new DateTime(2000, 6, 1), Position = "Director", Department = "Finance" };

            hospital.AddEmployee(doctor1);
           hospital.AddEmployee(doctor2);
            hospital.AddEmployee(nurse1);
            hospital.AddEmployee(nurse2);
            hospital.AddEmployee(staff1);


           
            List<Employee> employee = hospital.ListofEmployees();

            List<Employee> employees = hospital.SearchByName("John");
            Console.WriteLine($"Found {employees.Count} employees\n");
            foreach(Employee e in employees) {
                Console.WriteLine($" {e.Name}\n");
            }

            employees = hospital.SearchByJoiningYear(2011);
            Console.WriteLine($"Found {employees.Count} employees who joined in 2011:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"  {e.Name}");
            }

            employees = hospital.SearchByPosition("Charge");
            Console.WriteLine($"Found {employees.Count} employees with 'Charge' position:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"  {e.Name}");
            }

            employees = hospital.SearchByDepartment("Neurology");
            Console.WriteLine($"Found {employees.Count} employees in 'Neurology' department:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"  {e.Name}");
            }

         // Employee  employee = hospital.Employee.First();
           // int yearsofservice = employees.CalculateYearsofService();
            //Console.WriteLine($"{employee.Name} has worked for the hospital for {yearsOfService} years.");



        }
    }

}
