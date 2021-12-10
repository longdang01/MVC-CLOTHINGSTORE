using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class ClientBUS : IClientBUS
    {
        ICustomerDAO customerDAO = new CustomerDAO();
        ICustomerInfoDAO customerInfoDAO = new CustomerInfoDAO();
        ICartDAO cartDAO = new CartDAO();
        ICartDetailDAO cartDetailDAO = new CartDetailDAO();

        //Cart
        public Cart GetCart(string customer_id)
        {
            return cartDAO.GetCart(customer_id);
        }
        public List<Cart> GetCarts()
        {
            return cartDAO.GetCarts();
        }
        //CartDetail
        public List<CartDetail> GetCartDetails(string cart_id)
        {
            return cartDetailDAO.GetCartDetails(cart_id);
        }
        public void AddToCart(Cart cart, CartDetail cartDetail)
        {
            string cart_detail_id = GenerateCartDetailId();
            Cart c = GetCart(cart.customer_id);
            if (c == null)
            {
                cartDetail.cart_detail_id = cart_detail_id;
                string cart_id = GenerateCartId();

                cart.cart_id = cart_id;
                cartDetail.cart_id = cart_id;

                cart.listCartDetail = null;
                cartDAO.AddCart(cart);
                cartDetailDAO.AddCartDetail(cartDetail);
            }
            else
            {
                CartDetail cd = GetCartDetail(cartDetail.product_id, cartDetail.color, 
                    cartDetail.size, c.cart_id);
                cartDetail.cart_id = c.cart_id;

                if (cd == null)
                {
                    cartDetail.cart_detail_id = cart_detail_id;
                    cartDetailDAO.AddCartDetail(cartDetail);
                } else
                {
                    cartDetail.cart_detail_id = cd.cart_detail_id;
                    UpdateCartDetail(cartDetail);
                }
            }
        }
        public void UpdateCartDetail(CartDetail cartDetail)
        {
            cartDetailDAO.UpdateCartDetail(cartDetail);
        }
        public void UpdateQuantity(CartDetail cartDetail)
        {
            cartDetailDAO.UpdateQuantity(cartDetail);
        }
        public void RemoveCartDetail(CartDetail cartDetail)
        {
            cartDetailDAO.RemoveCartDetail(cartDetail);
        }

        //Acount
        public Customer Login(string username, string password)
        {
            return customerDAO.Login(username, password);
        }
        public void Register(Customer customer)
        {
            customer.info.customer_info_id = GenerateCustomerId();
            customer.customer_id = GenerateCustomerId();

            customerDAO.Register(customer);
        }

        public CartDetail GetCartDetail(string product_id, string color, string size, string cart_id)
        {
            List<CartDetail> list = GetCartDetails(cart_id);
            foreach (var item in list)
            {
                if (item.product_id == product_id && item.color.Equals(color) && item.size == size)
                        return item;
            }
            return null;
        }
        //Generate id
        public string GenerateCartId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "CART" + number;
            List<Cart> list = GetCarts();
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].cart_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "CART" + number;
                }
            }
            return id;
        }
        public string GenerateCartDetailId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "CD" + number;
            List<CartDetail> list = GetCartDetails("");
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].cart_detail_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "CD" + number;
                }
            }
            return id;
        }
        public string GenerateCustomerId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "C" + number;
            List<Customer> list = GetCustomers();
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].customer_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "C" + number;
                }
            }
            return id;
        }
        public string GenerateCustomerInfoId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "CI" + number;
            List<CustomerInfo> list = GetCustomerInfos();
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].customer_info_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "CI" + number;
                }
            }
            return id;
        }
        public List<Customer> GetCustomers()
        {
            return customerDAO.GetCustomers();
        }
        public List<CustomerInfo> GetCustomerInfos()
        {
            return customerInfoDAO.GetCustomerInfos();
        }
    }
}
