using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract class product
    {
        public int id;
        public string name;
        public string price;
        public string quantity;
        public string min;
        public int req_amount;

        public product(int id, string name, string price, string quantity, string min, int req_amount)
        {

            this.id = id;
            this.name = name;
            this.price = price;

            this.quantity = quantity;
            this.min = min;
            this.req_amount = req_amount;



        }

        public void auto_req()
        {
            quantity += req_amount;

        }
        public void req(int amount)
        {
            quantity += amount;
        }

    }
}
