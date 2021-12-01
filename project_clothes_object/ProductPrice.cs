using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class ProductPrice
    {
        public string product_price_id { get; set; }
        public string product_id { get; set; }
        public decimal price_current { get; set; }
        public string date_effect { get; set; }
        public string date_expired { get; set; }
        public ProductPrice()
        {

        }
        public ProductPrice(string product_price_id, string product_id, decimal price_current,
            string date_effect, string date_expired)
        {
            this.product_price_id = product_price_id;
            this.product_id = product_id;
            this.price_current = price_current;
            this.date_effect = date_effect;
            this.date_expired = date_expired;
        }
    }
}
