using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class OrderDetailDAO : IOrderDetailDAO
    {
        public DataHelper dh = new DataHelper();
        public List<OrderDetail> GetOrderDetails(string order_id)
        {
            string query = order_id == "" ? "select * from TBL_order_detail" :
               $"select * from TBL_order_detail where order_id='{order_id}'";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            dh.storeReaders("PROC_AddOrderDetail", orderDetail.order_detail_id, 
                orderDetail.order_id, orderDetail.product_id, orderDetail.product_name,
                orderDetail.image, orderDetail.color, orderDetail.size,
                orderDetail.quantity, orderDetail.price);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            dh.storeReaders("PROC_UpdateOrderDetail", orderDetail.order_detail_id, orderDetail.order_id,
                   orderDetail.product_id, orderDetail.product_name, orderDetail.color, orderDetail.size,
                   orderDetail.quantity, orderDetail.price);
        }
        public void RemoveOrderDetail(string order_detail_id)
        {
            dh.storeReaders("PROC_RemoveOrderDetail", order_detail_id);
        }
        public List<OrderDetail> ToList(DataTable dt)
        {
            List<OrderDetail> list = new List<OrderDetail>();

            foreach (DataRow row in dt.Rows)
            {
                OrderDetail orderDetail = new OrderDetail
                    (row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), row[3].ToString(),
                    row[4].ToString(), row[5].ToString(),
                    row[6].ToString(), int.Parse(row[7].ToString()),
                    decimal.Parse(row[8].ToString()));
                list.Add(orderDetail);
            }
            return list;
        }

    }
}
