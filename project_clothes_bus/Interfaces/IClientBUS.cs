using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public interface IClientBUS
    {
        //Login, register
        Customer Login(string username, string password);
        void Register(Customer customer);
        //Cart
        Cart GetCart(string customer_id);
        List<Cart> GetCarts();
        void AddToCart(Cart cart, CartDetail cardDetail);
        //CartDetail
        void UpdateQuantity(CartDetail cartDetail);
        void UpdateCartDetail(CartDetail cartDetail);
        void RemoveCartDetail(CartDetail cartDetail);
        List<CartDetail> GetCartDetails(string cart_id);


    }
}
