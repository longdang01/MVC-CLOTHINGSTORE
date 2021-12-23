using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface IOrderDAO
    {
        Order GetOrder(string order_id);
        List<Order> GetOrders(string customer_id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveOrder(string order_id);

    }
}
