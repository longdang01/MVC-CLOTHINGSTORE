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
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public string made_in { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
        public Guid category_id { get; set; }
        public List<ProductColor> list_color { get; set; }
        public ProductPrice price { get; set; }
        public Product()
        {

        }
        public Product( Guid product_id, string product_code, string product_name,
               string description, string brand, string made_in, string gender,
               string status, Guid category_id, List<ProductColor> list_color, ProductPrice price)
        { 
            this.product_id = product_id;
            this.product_code = product_code;
            this.product_name = product_name;
            this.description = description;
            this.brand = brand;
            this.made_in = made_in;
            this.gender = gender;
            this.status = status;
            this.category_id = category_id;
            this.list_color = list_color;
            this.price = price;
        }
    }
}
