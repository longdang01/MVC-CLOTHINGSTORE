using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class ProductImage
    {
        public Guid product_image_id { get; set; }
        public Guid product_color_id { get; set; }
        public string image { get; set; }
        public ProductImage(Guid product_image_id, Guid product_color_id, 
            string image)
        {
            this.product_image_id = product_image_id;
            this.product_color_id = product_color_id;
            this.image = image;
        }
    }
}
