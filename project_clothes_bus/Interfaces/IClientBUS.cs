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
        void ClearCart(string cart_id);
        List<CartDetail> GetCartDetails(string cart_id);
        //Delivery address
        DeliveryAddress GetDeliveryAddress(string customer_id);
        void CreateDeliveryAddress(DeliveryAddress address);
        void UpdateDeliveryAddress(DeliveryAddress address);
        void DeleteDeliveryAddress(string delivery_address_id);

    }
}
