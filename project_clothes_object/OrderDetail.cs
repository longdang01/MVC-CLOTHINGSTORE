using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class OrderDetail
    {
        public string order_detail_id { get; set; }
        public string order_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public OrderDetail() { }
        public OrderDetail(string order_detail_id, string order_id, string product_id,
            string product_name, string image, string color, string size, 
            int quantity, decimal price)
        {
            this.order_detail_id = order_detail_id;
            this.order_id = order_id;
            this.product_id = product_id;
            this.product_name = product_name;
            this.image = image;
            this.color = color;
            this.size = size;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
