using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeManagement;
using System.Collections.Generic;

namespace EmployeeTest
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void TestViewSalary_HRAuthorized()
        {
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

            // Call ViewSalary method on HR employee with finance employee as parameter
            Assert.ThrowsException<AccessDeniedException>(() => hrEmployee.ViewSalary(financeEmployee));
        }

        [TestMethod]
        public void TestGetEmployeeInformation_HR()
        {
            var hrEmployee = new HREmployee
            {
                Name = "Alice Johnson",
                EmployeeID = 1,
                JobTitle = "HR Manager",
                Salary = 100000m,
                HRJobTitle = "Senior HR Manager"
            };

            // Check that GetEmployeeInformation method returns expected output
            Assert.AreEqual("Name: Alice Johnson, ID: 1, Job Title: HR Manager, Salary: $100,000.00, HR Job Title: Senior HR Manager", hrEmployee.GetEmployeeInformation());
        }
        [TestMethod]
        public void TestHrViewSalaryAccessDenied()
        {
            // Arrange
            var hrEmployee = new HREmployee { Name = "Michael Johnson", EmployeeID = 3, JobTitle = "HR Manager", Salary = 70000m, HRJobTitle = "Recruitment" };
            var expectedException = typeof(AccessDeniedException);

            // Act and Assert
            Assert.ThrowsException<AccessDeniedException>(() => hrEmployee.Salary, "Salary() did not throw the expected AccessDeniedException for HR employee.");
        }

        [TestMethod]
        public void TestSalesPerformPerformanceReview()
        {

            var salesEmployee = new SalesEmployee { Name = "Jane Bailey", EmployeeID = 4, JobTitle = "Sales Representative", Salary = 60000m };
            var expectedException = typeof(AccessDeniedException);
        

            // Act and Assert
            Assert.ThrowsException<AccessDeniedException>(() => salesEmployee.PerformPerformanceReview(), "PerformPerformanceReview() did not throw the expected AccessDeniedException.");
        }

        [TestMethod]
        public void TestHRAccessDeniedException()
        {
            // Arrange
            var hrEmployee = new HREmployee { Name = "Mary Hopkins", EmployeeID = 5, JobTitle = "HR Manager", Salary = 55000m };
            var engineeringEmployee = new EngineeringEmployee { Name = "Tom Johnson", EmployeeID = 3, JobTitle = "Software Engineer", Salary = 70000m, YearsOfExperience = 5 };

            // Act and Assert
            Assert.ThrowsException<AccessDeniedException>(() => hrEmployee.ViewSalary(engineeringEmployee), "AccessDeniedException not thrown for HR employee trying to access engineering employee's salary.");
        }

        [TestMethod]
        public void TestCalculateSalaryIncrease_MarketingCampaignsMet_ReturnsExpectedValue()
        {
            // Arrange
            decimal baseSalary = 5000m; 
            int marketingCampaigns = 3;
            decimal expectedSalaryIncrease = baseSalary * 0.02m; 

            MarketingEmployee marketingEmployee = new MarketingEmployee
            {
                Salary = baseSalary,
                MarketingCampaigns = marketingCampaigns
            };

            // Act
            decimal actualSalaryIncrease = marketingEmployee.CalculateSalaryIncrease();

            // Assert
            Assert.AreEqual(expectedSalaryIncrease, actualSalaryIncrease);
        }

        [TestMethod]

        public void TestEngineerCalculateSalaryIncrease()
        {
            // Arrange
            var engineeringEmployee = new EngineeringEmployee { Name = "Aaron Warner", EmployeeID = 7, JobTitle = "Software Engineer", Salary = 60000m, YearsOfExperience = 7 };
            decimal Salary = 60000m;
            decimal expectedSalaryIncrease = Salary * 1.05m;
            // Act
            var salaryIncrease = engineeringEmployee.CalculateSalaryIncrease();

            // Assert
            Assert.AreEqual(expectedSalaryIncrease, salaryIncrease);
        }

        [TestMethod]

        public void TestIneligibleForSalaryIncreaseException()
        {
            // Arrange
            var financeEmployee = new FinanceEmployee { Name = "Inej Ghafa", EmployeeID = 8, JobTitle = "Accountant", Salary = 45000m, FinanceJobTitle = "Junior Financial Analyst" };

            // Act and Assert
            Assert.ThrowsException<IneligibleForSalaryIncreaseException>(() => financeEmployee.CalculateSalaryIncrease(), "IneligibleForSalaryIncreaseException not thrown for FinanceEmployee.");
        }

    }
}
