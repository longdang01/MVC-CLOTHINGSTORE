using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductColorDAO : IProductColorDAO
    {
        public DataHelper dh = new DataHelper(); 
        public List<ProductColor> GetProductColors(string product_id)
        {
            string query = $"select * from TBL_product_color where product_id = '{product_id}'";
            DataTable dt = dh.getDataTable(query);
            List<ProductColor> l = new List<ProductColor>();

            ProductSizeDAO productSizeDAO = new ProductSizeDAO();

            foreach (DataRow row in dt.Rows)
            {
                List<ProductSize> sizes = productSizeDAO.GetProductSizes(row[0].ToString());

                ProductColor pro = new ProductColor(
                    row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), row[3].ToString(), row[4].ToString(),
                    row[5].ToString(), sizes
                );
                l.Add(pro);
            }
            return l;
        }

    }
}
