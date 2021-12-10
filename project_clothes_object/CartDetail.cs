using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class CartDetail
    {
        public string cart_detail_id { get; set; }
        public string cart_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string date_add { get; set; }
        public int status { get; set; }
        public CartDetail() { }
        public CartDetail(string cart_detail_id, string cart_id, string product_id,
            string product_name, string image, string color, string size, decimal price,
            int quantity, string date_add, int status)
        {
            this.cart_detail_id = cart_detail_id;
            this.cart_id = cart_id;
            this.product_id = product_id;
            this.product_name = product_name;
            this.image = image;
            this.color = color;
            this.size = size;
            this.price = price;
            this.quantity = quantity;
            this.date_add = date_add;
            this.status = status;
        }
    }
}
