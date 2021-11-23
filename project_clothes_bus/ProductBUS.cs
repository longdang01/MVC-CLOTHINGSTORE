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
        public IProductDAO productDAO = new ProductDAO();
        public ProductList getProductList(Guid category_id, int page_index, int page_size, string product_name)
        {
            return productDAO.getProductList(category_id, page_index, page_size, product_name);
        }
        public Product getProductDetail(Guid product_id)
        {
            return productDAO.getProductDetail(product_id);
        }
        public void deleteProduct(Guid product_id)
        {
            productDAO.deleteProduct(product_id);
        }
        public void addProduct(Product product)
        {
            productDAO.addProduct(product);
        }
    }
}
