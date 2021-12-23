using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class ManageOrderBUS : IManageOrderBUS
    {
        public IOrderDAO orderDAO = new OrderDAO();
        public IOrderDetailDAO orderDetailDAO = new OrderDetailDAO();


        public Order GetOrder(string order_id)
        {
            return orderDAO.GetOrder(order_id);
        }
        public List<Order> GetOrders(string customer_id)
        {
            return orderDAO.GetOrders(customer_id);
        }
        public void AddOrder(Order order, List<OrderDetail> orderDetails)
        {
            order.order_id = GenerateOrderId();
            orderDAO.AddOrder(order);

            foreach (OrderDetail item in orderDetails)
            {
                Console.WriteLine(item);
                item.order_detail_id = GenerateOrderDetailId();
                item.order_id = order.order_id;

                AddOrderDetail(item);
            }
        }
        public void UpdateOrder(Order order)
        {
            orderDAO.UpdateOrder(order);
        }
        public void RemoveOrder(string order_id)
        {
            orderDAO.RemoveOrder(order_id);
        }
        public List<OrderDetail> GetOrderDetails(string order_id)
        {
            return orderDetailDAO.GetOrderDetails(order_id);
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetailDAO.AddOrderDetail(orderDetail);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            orderDetailDAO.UpdateOrderDetail(orderDetail);
        }
        public void RemoveOrderDetail(string order_detail_id)
        {
            orderDetailDAO.RemoveOrderDetail(order_detail_id);
        }
        public string GenerateOrderId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "Ord" + number;
            List<Order> list = GetOrders("");
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].order_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "Ord" + number;
                }
            }
            return id;
        }
        public string GenerateOrderDetailId()
        {
            Random rd = new Random();
            int number = rd.Next(1, 9999);
            string id = "OrdDetail" + number;
            List<OrderDetail> list = GetOrderDetails("");
            if (list == null) return id;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].order_id == id)
                {
                    number = rd.Next(1, 9999);
                    id = "Ord" + number;
                }
            }
            return id;
        }
    }
}
