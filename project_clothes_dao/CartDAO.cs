using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CartDAO : ICartDAO
    {
        public DataHelper dh = new DataHelper();
        public Cart GetCart(string customer_id)
        {
            ICartDetailDAO cartDetailDAO = new CartDetailDAO();

            if (customer_id == "") return null;
            string query = $"select * from TBL_cart where customer_id='{customer_id}'";
            DataTable dt = dh.getDataTable(query);
            if (dt.Rows.Count <= 0) return null;
            Cart cart = new Cart();

            foreach (DataRow row in dt.Rows)
            {
                List<CartDetail> listCartDetail = cartDetailDAO.GetCartDetails(row[0].ToString());
                cart.cart_id = row[0].ToString();
                cart.customer_id = row[1].ToString();
                cart.listCartDetail = listCartDetail;
            }
            return cart;
        }
        public List<Cart> GetCarts()
        {
            string query = "select * from TBL_cart";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }

        public void AddCart(Cart cart)
        {
            dh.storeReaders("PROC_AddCart", cart.cart_id, cart.customer_id);
        }

        public List<Cart> ToList(DataTable dt)
        {
            List<Cart> list = new List<Cart>();
            ICartDetailDAO cartDetailDAO = new CartDetailDAO();
            foreach (DataRow row in dt.Rows)
            {
                List<CartDetail> ListCartDetail = cartDetailDAO.GetCartDetails(row[0].ToString().Trim());
                Cart cart = new Cart(row[0].ToString(), row[1].ToString(),
                    ListCartDetail);
                list.Add(cart);
            }
            return list;
        }
    }
}
