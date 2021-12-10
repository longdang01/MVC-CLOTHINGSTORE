using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface ICartDAO
    {
        Cart GetCart(string customer_id);
        List<Cart> GetCarts();
        void AddCart(Cart cart);

    }
}
