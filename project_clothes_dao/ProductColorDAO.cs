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
        public List<ProductColor> getProductColors(Guid product_id)
        {
            string query = $"select * from TBL_product_color where product_id = '{product_id}'";
            DataTable dt = dh.getDataTable(query);
            List<ProductColor> l = new List<ProductColor>();

            ProductImageDAO productImageDAO = new ProductImageDAO();
            ProductSizeDAO productSizeDAO = new ProductSizeDAO();

            foreach (DataRow row in dt.Rows)
            {
                List<ProductImage> images = productImageDAO.getProductImages(Guid.Parse(row[0].ToString()));
                List<ProductSize> sizes = productSizeDAO.getProductSizes(Guid.Parse(row[0].ToString()));

                ProductColor pro = new ProductColor(
                    Guid.Parse(row[0].ToString()), Guid.Parse(row[1].ToString()),
                    row[2].ToString(), row[3].ToString(), row[4].ToString(),
                    images, sizes
                    );
                l.Add(pro);
            }
            return l;
        }

    }
}
