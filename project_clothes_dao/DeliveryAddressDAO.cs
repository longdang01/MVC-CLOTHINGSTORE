using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class DeliveryAddressDAO : IDeliveryAddressDAO
    {
        public DataHelper dh = new DataHelper();
        public DeliveryAddress GetDeliveryAddress(string customer_id)
        {
            string query = 
                $"select * from TBL_delivery_address where customer_id ='{ customer_id }'";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt).Count > 0 ? ToList(dt)[0] : null;

        }
        public void CreateDeliveryAddress(DeliveryAddress address)
        {
            dh.storeReaders("PROC_CreateDeliveryAddress", address.delivery_address_id,
                address.customer_id, address.commune, address.district, address.province,
                address.specific_address);
        }
        public void UpdateDeliveryAddress(DeliveryAddress address)
        {
            dh.storeReaders("PROC_UpdateDeliveryAddress", address.delivery_address_id,
                address.customer_id, address.commune, address.district, address.province,
                address.specific_address);
        }
        public void DeleteDeliveryAddress(string delivery_address_id)
        {
            dh.storeReaders("PROC_CreateDeliveryAddress", delivery_address_id);
        }
        public List<DeliveryAddress> ToList(DataTable dt)
        {
            List<DeliveryAddress> list = new List<DeliveryAddress>();
            foreach (DataRow row in dt.Rows)
            {
                DeliveryAddress address = new DeliveryAddress
                    (row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), row[3].ToString(),
                    row[4].ToString(), row[5].ToString());
                list.Add(address);
            }
            return list;
        }
    }
}
