using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class SALES : employee
    {
        protected double bonus = 0;
        public void sale_product(int id, int amount)
        {
            foreach (product product in inventory.products)
            {

                if (product.id == id && product.quantity >= amount)
                {
                    double total_price = product.price * amount;

                    bonus += total_price * 0.01;
                    product.quantity -= amount;




                }
            }
        }
    }
}
