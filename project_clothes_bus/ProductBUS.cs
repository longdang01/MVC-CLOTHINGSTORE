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
        public ProductList GetProductList(Guid category_id, int page_index, int page_size, string product_name)
        {
            return productDAO.GetProductList(category_id, page_index, page_size, product_name);
        }
        public Product GetProductDetail(Guid product_id)
        {
            return productDAO.GetProductDetail(product_id);
        }
        public void RemoveProduct(Guid product_id)
        {
            productDAO.RemoveProduct(product_id);
        }
        public void AddProduct(Product product)
        {
            productDAO.AddProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            productDAO.UpdateProduct(product);
        }
    }
}
