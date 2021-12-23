using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Order
    {
        public string order_id { get; set; }
        public string customer_id { get; set; }
        public string address { get; set; }
        public decimal total { get; set; }
        public string date_order { get; set; }
        public string status { get; set; }
        public List<OrderDetail> listOrderDetails { get; set; }
        public Order() { }
        public Order(string order_id, string customer_id, string address, decimal total,
            string date_order, string status, List<OrderDetail> listOrderDetails)
        {
            this.order_id = order_id;
            this.customer_id = customer_id;
            this.address = address;
            this.total = total;
            this.date_order = date_order;
            this.status = status;
            this.listOrderDetails = listOrderDetails;
        }

    }
}
