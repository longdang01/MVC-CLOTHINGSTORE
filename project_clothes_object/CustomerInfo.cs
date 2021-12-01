using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class CustomerInfo
    {
        public string customer_info_id { get; set; }
        public string customer_name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string customer_id { get; set; }
        public CustomerInfo()
        {

        }
        public CustomerInfo(string customer_info_id, string customer_name, string phone_number, string address,
            string email, string customer_id)
        {
            this.customer_info_id = customer_info_id;
            this.customer_name = customer_name;
            this.phone_number = phone_number;
            this.address = address;
            this.email = email;
            this.customer_id = customer_id;
        }

    }
}
