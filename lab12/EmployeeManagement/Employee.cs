using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public abstract class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        public abstract decimal CalculateSalaryIncrease();

        public virtual void PerformPerformanceReview()
        {
            // Default implementation
            Console.WriteLine("Performance review completed.");
        }

        public virtual void ViewSalary(Employee employee)
        {
            throw new AccessDeniedException("Access denied. Employees are not authorized to view each other's salaries.");
        }

        public string GetEmployeeInformation()
        {
            return $"Name: {Name}, ID: {EmployeeID}, Job Title: {JobTitle}, Salary: {Salary:C}";
        }
    }
}
