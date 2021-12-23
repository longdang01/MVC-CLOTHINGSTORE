using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface ICartDetailDAO
    {
        List<CartDetail> GetCartDetails(string cart_id);
        void AddCartDetail(CartDetail cartDetail);
        void UpdateCartDetail(CartDetail cartDetail);
        void UpdateQuantity(CartDetail cartDetail);
        void RemoveCartDetail(CartDetail cartDetail);
        void ClearCart(string cart_id);



    }
}
