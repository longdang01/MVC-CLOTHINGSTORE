using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductDAO : IProductDAO
    {
        public DataHelper dh = new DataHelper();
        public List<Product> getProducts()
        {
            string query = $" SELECT p.product_id, pd.images, p.product_name, pp.price_current FROM TBL_product p" +
                           $" LEFT JOIN TBL_product_detail pd ON pd.product_id = p.product_id" +
                           $" LEFT JOIN TBL_product_price pp ON pp.product_detail_id = pd.product_detail_id" +
                           $" GROUP BY p.product_id, pd.images, p.product_name, pp.price_current";
            DataTable dt = dh.getDataTable(query);

            return ToList(dt);
        }
        public Product getProductDetail(string product_id)
        {
            string query = $" SELECT pd.product_detail_id, pd.product_id," +
                           $" pd.images, p.product_name, p.description, pp.price_current, p.product_code," +
                           $" pd.color, pd.size FROM TBL_product p" +
                           $" LEFT JOIN TBL_product_detail pd ON pd.product_id = p.product_id" +
                           $" LEFT JOIN TBL_product_price pp ON pp.product_detail_id = pd.product_detail_id" +
                           $" WHERE pd.product_id = '{ product_id }'";

            DataTable dt = dh.getDataTable(query);
            List<Product> l = new List<Product>();
           
            List<string> colors = new List<string>();
            List<string> sizes = new List<string>();
            
            foreach (DataRow dr in dt.Rows)
            {
                if(colors.Count > 0)
                {
                    foreach (string color in colors)
                    {
                        if(dr[7].ToString() != color)
                        {
                            colors.Add(dr[7].ToString());
                        }
                    }
                }else { colors.Add(dr[7].ToString()); }

                sizes.Add(dr[8].ToString());
            }

            foreach (DataRow dr in dt.Rows)
            {
                List<string> images = dr[2].ToString().Split(',').ToList();
                Product p = new Product(
                  Guid.Parse(dr[0].ToString())
                , Guid.Parse(dr[1].ToString())
                , images
                , dr[3].ToString()
                , dr[4].ToString()
                , decimal.Parse(dr[5].ToString())
                , dr[6].ToString()
                , colors
                , sizes);
                l.Add(p);
            }

            return l[0];
        }
        public List<Product> ToList(DataTable dt)
        {
            List<Product> l = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                List<string> images = dr[1].ToString().Split(',').ToList();

                Product p = new Product(Guid.Parse(dr[0].ToString()), images, dr[2].ToString()
                    , Convert.ToDecimal(dr[3].ToString()));
                l.Add(p);
            }
            return l;
        }
    }
}
