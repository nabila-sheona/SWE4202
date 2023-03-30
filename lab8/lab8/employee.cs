using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class employee
    {

        protected int id;
        protected string name;
        protected int base_salary;
        protected inventory _inventory;
        public employee()
        {
            _inventory = new inventory();


        }


    }
}
