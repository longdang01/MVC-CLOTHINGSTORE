using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductSizeDAO : IProductSizeDAO
    {
        public DataHelper dh = new DataHelper();
        public List<ProductSize> GetProductSizes(string product_color_id)
        {
            string query = $" select s.* from TBL_product_size s" +
                           $" left join TBL_product_color c on c.product_color_id = s.product_color_id" +
                           $" where c.product_color_id = '{product_color_id}'";

            DataTable dt = dh.getDataTable(query);
            List<ProductSize> l = new List<ProductSize>();
            foreach (DataRow row in dt.Rows)
            {
                ProductSize pro = new ProductSize(
                    row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), int.Parse(row[3].ToString())
                    );
                l.Add(pro);
            }
            return l;
        }
    }
}
