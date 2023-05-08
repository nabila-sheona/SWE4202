using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11A
{
    public class Hospital
    {
        private List<Employee> employees;

        public Hospital()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public List<Employee> ListofEmployees()
        {
            return employees;
        }


        public List<Employee> SearchByName(string name)
        {
            return employees.Where(e => e.Name.Contains(name)).ToList();
        }

        public List<Employee> SearchByJoiningYear(int year)
        {
            return employees.Where(e => e.HireDate.Year == year).ToList();
        }

        public List<Employee> SearchByPosition(string position)
        {
            return employees.Where(e =>
            {
                if (e is Doctor)
                {
                    return ((Doctor)e).Position.ToString().Contains(position);
                }
                else if (e is Nurse)
                {
                    return ((Nurse)e).Position.ToString().Contains(position);
                }
                else if (e is ManagementStaff)
                {
                    return ((ManagementStaff)e).Position.ToString().Contains(position);
                }
                else
                {
                    return false;
                }
            }).ToList();
        }

        public List<Employee> SearchByDepartment(string position)
        {
            return employees.Where(e =>
            {
                if (e is Doctor)
                {
                    return ((Doctor)e).Department.ToString().Contains(position);
                }
                else if (e is Nurse)
                {
                    return ((Nurse)e).Department.ToString().Contains(position);
                }
                else if (e is ManagementStaff)
                {
                    return ((ManagementStaff)e).Department.ToString().Contains(position);
                }
                else
                {
                    return false;
                }
            }).ToList();
        }
    }
}
