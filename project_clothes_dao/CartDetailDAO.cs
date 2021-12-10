using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CartDetailDAO : ICartDetailDAO
    {
        public DataHelper dh = new DataHelper();
        public List<CartDetail> GetCartDetails(string cart_id)
        {
            string query = (cart_id != "") ? 
                $"select * from TBL_cart_detail where cart_id = '{cart_id}'"
                : "select * from TBL_cart_detail";
            DataTable dt = dh.getDataTable(query);

            return ToList(dt);
        }
        public void AddCartDetail(CartDetail cartDetail)
        {
            dh.storeReaders("PROC_AddCartDetail", cartDetail.cart_detail_id, cartDetail.cart_id
            , cartDetail.product_id, cartDetail.product_name, cartDetail.image, cartDetail.color,
            cartDetail.size, cartDetail.price, cartDetail.quantity, 
            cartDetail.date_add, cartDetail.status);
        }
        public void UpdateCartDetail(CartDetail cartDetail)
        {
            dh.storeReaders("PROC_UpdateCartDetail", cartDetail.cart_detail_id, cartDetail.cart_id
            , cartDetail.product_id, cartDetail.product_name, cartDetail.image, cartDetail.color,
            cartDetail.size, cartDetail.price, cartDetail.quantity,
            cartDetail.date_add, cartDetail.status);
        }
        public void UpdateQuantity(CartDetail cartDetail)
        {
            dh.storeReaders("PROC_UpdateQuantity", cartDetail.cart_detail_id, cartDetail.cart_id
            , cartDetail.product_id, cartDetail.product_name, cartDetail.image, cartDetail.color,
            cartDetail.size, cartDetail.price, cartDetail.quantity,
            cartDetail.date_add, cartDetail.status);
        }
        public void RemoveCartDetail(CartDetail cartDetail)
        {
            dh.storeReaders("PROC_RemoveCartDetail", cartDetail.cart_detail_id, cartDetail.cart_id
            , cartDetail.product_id, cartDetail.product_name, cartDetail.image, cartDetail.color,
            cartDetail.size, cartDetail.price, cartDetail.quantity,
            cartDetail.date_add, cartDetail.status);
        }
        public List<CartDetail> ToList(DataTable dt)
        {
            List<CartDetail> list = new List<CartDetail>();
            foreach (DataRow row in dt.Rows)
            {
                CartDetail pro = new CartDetail(
                    row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), row[3].ToString(),
                    row[4].ToString(), row[5].ToString(),
                    row[6].ToString(), decimal.Parse(row[7].ToString()),
                    int.Parse(row[8].ToString()), row[9].ToString(),
                    int.Parse(row[10].ToString())
                );
                list.Add(pro);
            }
            return list;
        }
    }
}
