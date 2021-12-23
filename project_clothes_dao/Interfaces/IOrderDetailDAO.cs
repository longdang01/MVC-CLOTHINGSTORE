using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface IOrderDetailDAO
    {
        List<OrderDetail> GetOrderDetails(string order_id);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void RemoveOrderDetail(string order_detail_id);
    }
}
