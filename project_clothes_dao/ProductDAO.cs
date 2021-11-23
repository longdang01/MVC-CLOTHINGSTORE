using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductDAO : IProductDAO
    {
        public DataHelper dh = new DataHelper();
        public ProductList getProductList(Guid category_id, int page_index, int page_size, string product_name)
        {
            ProductList pl = new ProductList();
            List<Product> l = new List<Product>();

            ProductPriceDAO productPriceDAO = new ProductPriceDAO();
            ProductColorDAO productColorDAO = new ProductColorDAO();

            SqlDataReader dr = dh.storeReaders("getProductList", category_id, page_index, page_size, product_name);

            while (dr.Read())
            {
                ProductPrice price = productPriceDAO.getProductPrice(Guid.Parse(dr[0].ToString()));
                List<ProductColor> colors = productColorDAO.getProductColors(Guid.Parse(dr[0].ToString()));

                Product p = new Product(
                    Guid.Parse(dr[0].ToString()), dr[1].ToString(),
                     dr[2].ToString(), dr[3].ToString(),
                     dr[4].ToString(), dr[5].ToString(),
                     dr[6].ToString(), dr[7].ToString(),
                     dr[8].ToString(),
                     Guid.Parse(dr[9].ToString()),
                     colors, price
                    );
                l.Add(p);
            }
            pl.list_product = l;
            dr.NextResult();
            while (dr.Read())
            {
                pl.total_count = int.Parse(dr["total_count"].ToString());
            }
            return pl;
        }
        public Product getProductDetail(Guid product_id)
        {
            string query = $" select * from TBL_product p" +
                           $" WHERE p.product_id = '{ product_id }'";

            DataTable dt = dh.getDataTable(query);
            return ToList(dt)[0];
        }
        public void deleteProduct(Guid product_id)
        {
            dh.storeReaders("deleteProduct", product_id);
        }
        public void addProduct(Product product)
        {
            if (product.product_id == Guid.Empty) product.product_id = new Guid();
            dh.storeReaders("addProduct", product.product_id, product.product_code, product.product_name,
            product.description, product.image_avt, product.brand, product.made_in, product.gender,
            product.status, product.category_id);
        }
        public List<Product> ToList(DataTable dt)
        {
            List<Product> l = new List<Product>();
            ProductPriceDAO productPriceDAO = new ProductPriceDAO();
            ProductColorDAO productColorDAO = new ProductColorDAO();

            foreach (DataRow dr in dt.Rows)
            {
                ProductPrice price = productPriceDAO.getProductPrice(Guid.Parse(dr[0].ToString()));
                List<ProductColor> colors = productColorDAO.getProductColors(Guid.Parse(dr[0].ToString()));

                Product p = new Product(
                     Guid.Parse(dr[0].ToString()), dr[1].ToString(),
                     dr[2].ToString(), dr[3].ToString(),
                     dr[4].ToString(), dr[5].ToString(),
                     dr[6].ToString(), dr[7].ToString(),
                     dr[8].ToString(),
                     Guid.Parse(dr[9].ToString()),
                     colors, price
                     );
                l.Add(p);
            }
            return l;
        }
    }
}
