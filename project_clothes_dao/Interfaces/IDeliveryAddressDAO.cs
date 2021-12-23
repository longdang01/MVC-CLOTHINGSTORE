using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public interface IDeliveryAddressDAO
    {
        DeliveryAddress GetDeliveryAddress(string customer_id);
        void CreateDeliveryAddress(DeliveryAddress address);
        void UpdateDeliveryAddress(DeliveryAddress address);
        void DeleteDeliveryAddress(string delivery_address_id);
    }
}
