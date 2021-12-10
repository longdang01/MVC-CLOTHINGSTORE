using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public interface IProductBUS
    {
        ProductList GetProductList(string category_id, int page_index, int page_size, string product_name);
        Product GetProductDetail(string product_id);
        void RemoveProduct(string product_id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetNewArrival(int rows);
        List<Product> GetHot(int rows);
        List<Product> GetBestSeller(int rows);
        List<Product> GetSale(int rows);
    }
}
