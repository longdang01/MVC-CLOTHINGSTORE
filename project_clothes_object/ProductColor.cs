using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class ProductColor
    {
        public string product_color_id { get; set; }
        public string product_id { get; set; }
        public string avatar { get; set; }
        public string images { get; set; }
        public string color { get; set; }
        public string hex { get; set; }
        public List<ProductSize> list_size { get; set; }
        public ProductColor(string product_color_id, string product_id, string avatar,
            string images, string color, string hex, List<ProductSize> list_size)
        {
            this.product_color_id = product_color_id;
            this.product_id = product_id;
            this.avatar = avatar;
            this.images = images;
            this.color = color;
            this.hex = hex;
            this.list_size = list_size;
        }
    }
}
