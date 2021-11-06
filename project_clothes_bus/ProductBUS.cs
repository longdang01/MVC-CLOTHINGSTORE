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
        public Product getProductDetail(string product_id)
        {
            return productDAO.getProductDetail(product_id);
        }
    }
}
