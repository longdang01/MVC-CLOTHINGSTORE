using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Cart
    {
        public string cart_id { get; set; }
        public string customer_id { get; set; }
        public List<CartDetail> listCartDetail { get; set; }
        public Cart() { }
        public Cart(string cart_id, string customer_id, List<CartDetail> listCartDetail)
        {
            this.cart_id = cart_id;
            this.customer_id = customer_id;
            this.listCartDetail = listCartDetail;
        }
    }
}
