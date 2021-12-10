using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface IProductDAO
    {
        ProductList GetProductList(string category_id, int page_index, int page_size, string product_name);
        Product GetProductDetail(string product_id);
        List<Product> GetNewArrival(int rows);
        List<Product> GetHot(int rows);
        List<Product> GetBestSeller(int rows);
        List<Product> GetSale(int rows);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(string product_id);
    }
}
