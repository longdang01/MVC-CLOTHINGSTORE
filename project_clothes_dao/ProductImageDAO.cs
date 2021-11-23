using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductImageDAO : IProductImageDAO
    {
        public DataHelper dh = new DataHelper();
        public List<ProductImage> getProductImages(Guid product_color_id)
        {
            string query = $" select i.* from TBL_product_image i" +
                           $" left join TBL_product_color c on c.product_color_id = i.product_color_id" +
                           $" where c.product_color_id = '{product_color_id}'";

            DataTable dt = dh.getDataTable(query);
            List<ProductImage> l = new List<ProductImage>();
            foreach (DataRow row in dt.Rows)
            {
                ProductImage pro = new ProductImage(
                    Guid.Parse(row[0].ToString()), Guid.Parse(row[1].ToString()),
                    row[2].ToString()
                    );
                l.Add(pro);
            }
            return l;
        }

    }
}
