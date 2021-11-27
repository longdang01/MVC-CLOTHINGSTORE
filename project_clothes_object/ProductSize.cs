using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class ProductSize
    {
        public Guid product_size_id { get; set; }
        public Guid product_color_id { get; set; }
        public string size { get; set; }
        public int quantity { get; set; }
        public ProductSize(Guid product_size_id, Guid product_color_id,
            string size, int quantity)
        {
            this.product_size_id = product_size_id;
            this.product_color_id = product_color_id;
            this.size= size;
            this.quantity = quantity;

        }

    }
}
