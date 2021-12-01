using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Customer
    {
        public string customer_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public CustomerInfo info { get; set; }
        public Customer()
        {

        }
        public Customer(string customer_id, string username,
            string password, int status,
            CustomerInfo info
            )
        {
            this.customer_id = customer_id;
            this.username = username;
            this.password = password;
            this.status = status;
            this.info = info;
        }
    }
}
