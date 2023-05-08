using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11A
{
    public class Employee
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime HireDate { get; set; }


      

        public int ShowDetails()
         {
     
         int age = DateTime.Today.Year - HireDate.Year;
        if (HireDate.Date > DateTime.Today.AddYears(-age)) age--;
        return age;
        }

  
        public int YearsOfService()
        {
           
            int years = DateTime.Now.Year - HireDate.Year;
            if (DateTime.Now.DayOfYear < HireDate.DayOfYear)
            {
                years--;
            }
            return years;
        }
    }
}
