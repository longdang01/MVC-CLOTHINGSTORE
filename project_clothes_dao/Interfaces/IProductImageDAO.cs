using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface IProductImageDAO
    {
        List<ProductImage> getProductImages(Guid product_id);
    }
}
