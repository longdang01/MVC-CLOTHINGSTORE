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
        ProductList getProductList(Guid category_id, int page_index, int page_size, string product_name);
        Product getProductDetail(Guid product_id);
        void deleteProduct(Guid product_id);
        void addProduct(Product product);

    }
}
