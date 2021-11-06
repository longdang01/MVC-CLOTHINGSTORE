using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Product
    {
        public Guid product_id { get; set; }
        public Guid product_detail_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public Guid category_id { get; set; }
        public string image { get; set; }
        public List<string> images { get; set; }
        public string color { get; set; }
        public List<string> colors { get; set; }
        public string size { get; set; }
        public List<string> sizes { get; set; }
        public int quantity { get; set; }
        public decimal price_current { get; set; }
        public DateTime date_effect { get; set; }
        public DateTime date_expired { get; set; }

        public Product(Guid product_id, List<string> images,
            string product_name, decimal price_current)
        {
            this.product_id = product_id;
            this.images = images;
            this.product_name = product_name;
            this.price_current = price_current;
        }

        public Product(Guid product_detail_id, Guid product_id, List<string> images,
            string product_name, string description, decimal price_current, string product_code, 
            List<string> colors,
            List<string> sizes)
        { 
            this.product_detail_id = product_detail_id;
            this.product_id = product_id;
            this.images = images;
            this.product_name = product_name;
            this.description = description;
            this.price_current = price_current;
            this.product_code = product_code;
            this.colors = colors;
            this.sizes = sizes;
        }
    }
}
