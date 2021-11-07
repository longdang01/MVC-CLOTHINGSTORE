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
        List<Product> getProducts();
        ProductList getProductList(string category_id, int page_index, int page_size, string product_name);
        Product getProductDetail(string product_id);

    }
}
