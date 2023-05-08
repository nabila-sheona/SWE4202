using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message) : base(message) { }
    }

    public class IneligibleForSalaryIncreaseException : Exception
    {
        public IneligibleForSalaryIncreaseException() : base("The employee is ineligible for a salary increase.")
        {
        }
    }
}
