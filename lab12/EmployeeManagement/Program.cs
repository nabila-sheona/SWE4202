using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create some employees
            var hrEmployee = new HREmployee
            {
                Name = "Alice Johnson",
                EmployeeID = 1,
                JobTitle = "HR Manager",
                Salary = 100000m,
                HRJobTitle = "Senior HR Manager"
            };

            var financeEmployee = new FinanceEmployee
            {
                Name = "Bob Smith",
                EmployeeID = 2,
                JobTitle = "Finance Manager",
                Salary = 75000m,
                FinanceJobTitle = "Senior Financial Analyst"
            };

            var marketingEmployee = new MarketingEmployee
            {
                Name = "Charlie Brown",
                EmployeeID = 3,
                JobTitle = "Marketing Manager",
                Salary = 90000m,
                MarketingCampaigns = 2
            };
            var financeEmployee2 = new FinanceEmployee { Name = "Inej Ghafa", EmployeeID = 8, JobTitle = "Accountant", Salary = 45000m, FinanceJobTitle = "Junior Financial Analyst" };
            var engineeringEmployee = new EngineeringEmployee { Name = "Aaron Warner", EmployeeID = 7, JobTitle = "Software Engineer", Salary = 60000m, YearsOfExperience = 3 };
            // Call some methods on the employees
            hrEmployee.ViewSalary(hrEmployee);
            
            
          hrEmployee.ViewSalary(financeEmployee); // throws AccessDeniedException
          financeEmployee.ViewSalary(hrEmployee); // throws AccessDeniedException
          marketingEmployee.PerformPerformanceReview(); // throws IneligibleForSalaryIncreaseException

            

            // Print out some employee information
            Console.WriteLine(hrEmployee.GetEmployeeInformation());
            Console.WriteLine(financeEmployee.GetEmployeeInformation());
            Console.WriteLine(marketingEmployee.GetEmployeeInformation());
            Console.WriteLine(financeEmployee2.GetEmployeeInformation());
            Console.WriteLine(engineeringEmployee.GetEmployeeInformation());
          
            EmployeeData<Employee> empData = new EmployeeData<Employee>();
            empData.AddEmployee(hrEmployee);
            empData.AddEmployee(marketingEmployee);
            empData.AddEmployee(financeEmployee);
            empData.AddEmployee(financeEmployee2);
            empData.AddEmployee(engineeringEmployee);

            Console.WriteLine($"Total Employee Count: {empData.EmployeeCount}");
            Console.ReadKey();
        }
    }
}
