using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class DeliveryAddress
    {
        public string delivery_address_id { get; set; }
        public string customer_id { get; set; }
        public string commune { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string specific_address { get; set; }
        public DeliveryAddress() { }
        public DeliveryAddress(string delivery_address_id, string customer_id, string commune,
            string district, string province, string specific_address)
        {
            this.delivery_address_id = delivery_address_id;
            this.customer_id = customer_id;
            this.commune = commune;
            this.district = district;
            this.province = province;
            this.specific_address = specific_address;
        }

    }
}
