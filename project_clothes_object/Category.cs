using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class Category
    {
        public Guid category_id { get; set; }
        public string category_name { get; set; }
        public Category(Guid category_id, string category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }
    }
}
