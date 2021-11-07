using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class ProductBUS : IProductBUS
    {
        public ProductDAO productDAO = new ProductDAO();
        public List<Product> getProducts()
        {
            return productDAO.getProducts();
        }
        public ProductList getProductList(string category_id, int page_index, int page_size, string product_name)
        {
            return productDAO.getProductList(category_id, page_index, page_size, product_name);
        }
        public Product getProductDetail(string product_id)
        {
            return productDAO.getProductDetail(product_id);
        }
    }
}
