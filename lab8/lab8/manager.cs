using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class manager : employee
    {
        public void addProduct(product product);
        public void initialautoreq(int product_id)
        {

            foreach (product product in inventory.products)
            {
                if (product.id == product_id && product.quantity < product.min)
                {
                    product.auto_req();
                }
            }
        }

        public void initializerequistion(int product_id, int amount)
        {
            foreach (product product in inventory.products)
            {
                if (product.id == product_id && product.quantity < product.min)
                {
                    product.req(amount);
                }
            }

        }
    }
}
