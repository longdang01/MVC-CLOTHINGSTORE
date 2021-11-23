using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class ProductColor
    {
        public Guid product_color_id { get; set; }
        public Guid product_id { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public string hex { get; set; }
        public List<ProductImage> list_image { get; set; }
        public List<ProductSize> list_size { get; set; }

        public ProductColor(Guid product_color_id, Guid product_id, string image, string color, string hex
            , List<ProductImage> list_image, List<ProductSize> list_size)
        {
            this.product_color_id = product_color_id;
            this.product_id = product_id;
            this.image = image;
            this.color = color;
            this.hex = hex;
            this.list_image = list_image;
            this.list_size = list_size;
        }
    }
}
