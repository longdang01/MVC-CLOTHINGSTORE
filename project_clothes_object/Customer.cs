using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Customer
    {
        public Guid customer_id { get; set; }
        public string customer_name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public Guid user_id { get; set; }
        public Customer(Guid customer_id, string customer_name, string phone_number, string address,
            string email, Guid user_id)
        {
            this.customer_id = customer_id;
            this.customer_name = customer_name;
            this.phone_number = phone_number;
            this.address = address;
            this.email = email;
            this.user_id = user_id;
        }

    }
}
