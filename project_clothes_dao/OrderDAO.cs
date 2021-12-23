using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class OrderDAO : IOrderDAO
    {
        public DataHelper dh = new DataHelper();
        public Order GetOrder(string order_id)
        {
            string query = $"select * from TBL_order where order_id='{order_id}'";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt).Count > 0 ? ToList(dt)[0] : null;
        }
        public List<Order> GetOrders(string customer_id)
        {
            string query = customer_id != "" ?
               $"select * from TBL_order where customer_id='{customer_id}'" :
               $"select * from TBL_order";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt).Count > 0 ? ToList(dt) : null;
        }
        public void AddOrder(Order order)
        {
            dh.storeReaders("PROC_AddOrder", order.order_id, order.customer_id,
                order.address, order.total, order.date_order, order.status);
        }
        public void UpdateOrder(Order order)
        {
            dh.storeReaders("PROC_UpdateOrder", order.order_id, order.customer_id,
                order.address, order.total, order.date_order, order.status);
        }
        public void RemoveOrder(string order_id)
        {
            dh.storeReaders("PROC_RemoveOrder", order_id);
        }
        public List<Order> ToList(DataTable dt)
        {
            List<Order> list = new List<Order>();
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();

            foreach (DataRow row in dt.Rows)
            {
                List<OrderDetail> listOrderDetails =
                    orderDetailDAO.GetOrderDetails(row[0].ToString());

                Order order = new Order
                    (row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), decimal.Parse(row[3].ToString()),
                    row[4].ToString(), row[5].ToString(), listOrderDetails);
                list.Add(order);
            }
            return list;
        }
    }
}
