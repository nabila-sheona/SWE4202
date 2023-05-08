using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class SalesEmployee : Employee
    {
        public decimal SalesTarget { get; set; }
        public decimal SalesAchieved { get; set; }

        public override decimal CalculateSalaryIncrease()
        {
            var percentageIncrease = SalesAchieved / SalesTarget * 0.05m;
            return Salary + Salary * percentageIncrease;
        }
    }

    public class EngineeringEmployee : Employee
    {
        public int YearsOfExperience { get; set; }

        public override decimal CalculateSalaryIncrease()
        {
            if (YearsOfExperience >= 5)
            {
                return Salary * 1.05m;
            }
            else
            {
                return Salary;
            }
        }
    }

    public class MarketingEmployee : Employee
    {
        public int MarketingCampaigns { get; set; }

        public override decimal CalculateSalaryIncrease()
        {
            if (MarketingCampaigns >= 3)
            {
                return Salary * 1.03m;
            }
            else
            {
                return Salary;
            }
        }

        public override void PerformPerformanceReview()
        {

            try
            {
                if (MarketingCampaigns >= 3)
                {
                    Console.WriteLine("Employee has performed well and is eligible for a salary increase.");
                }
                else
                {
                    throw new IneligibleForSalaryIncreaseException();
                }
            }
            catch (IneligibleForSalaryIncreaseException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }

    public class FinanceEmployee : Employee
    {
        public string FinanceJobTitle { get; set; }

        public override decimal CalculateSalaryIncrease()
        {
            // Finance employees do not have a specific formula for calculating salary increases
            // but they are still eligible for a standard 2% increase
            return Salary * 1.02m;
        }

        public void HRViewFinanceJobTitle(FinanceEmployee financeEmployee)
        {
            throw new AccessDeniedException("Access denied. HR employees are not authorized to view finance employees' job titles.");
        }

        public override void ViewSalary(Employee employee)
        {
            try
            {
                if (employee is FinanceEmployee)
                {
                    Console.WriteLine($"Salary of Finance Employee {employee.Name}: {employee.Salary:C}");
                }
                else
                {
                    throw new AccessDeniedException("Access denied. Finance employees are not authorized to view HR employees' salaries.");
                }
            }
            catch (AccessDeniedException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

           
        }

        public new string GetEmployeeInformation()
        {
            return $"{base.GetEmployeeInformation()}, Finance Job Title: {FinanceJobTitle}";
        }
    }

    public class HREmployee : Employee
    {
        public string HRJobTitle { get; set; }

        public override decimal CalculateSalaryIncrease()
        {
            // HR employees do not have a specific formula for calculating salary increases
            // but they are still eligible for a standard 2% increase
            return Salary * 1.02m;
        }

        public void FinanceViewHRJobTitle(HREmployee hrEmployee)
        {
            throw new AccessDeniedException("Access denied. Finance employees are not authorized to view HR employees' job titles.");
        }



        public override void ViewSalary(Employee employee)
        {
            try
            {
                if (employee is HREmployee)
                {
                    Console.WriteLine($"Salary of HR Employee {employee.Name}: {employee.Salary:C}");
                }
                else
                {
                    throw new AccessDeniedException("Access denied. HR employees are not authorized to view finance employees' salaries.");
                }
            }
            catch (AccessDeniedException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }



        }

        public new string GetEmployeeInformation()
        {
            return $"{base.GetEmployeeInformation()}, HR Job Title: {HRJobTitle}";
        }
    }

    public class EmployeeData<T> where T : Employee
    {
        private List<T> employees = new List<T>();

        public int EmployeeCount => employees.Count;

        public void AddEmployee(T employee)
        {
            employees.Add(employee);
        }
    }
}
