using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public interface IManageOrderBUS
    {
        Order GetOrder(string order_id);
        List<Order> GetOrders(string customer_id);
        void AddOrder(Order order, List<OrderDetail> orderDetails);
        void UpdateOrder(Order order);
        void RemoveOrder(string order_id);
        List<OrderDetail> GetOrderDetails(string order_id);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void RemoveOrderDetail(string order_detail_id);
    }
}
