using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CustomerInfoDAO : ICustomerInfoDAO
    {
        public DataHelper dh = new DataHelper();
        public List<CustomerInfo> GetCustomerInfos()
        {
            string query = $"select * from TBL_customer_info";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }
        public CustomerInfo GetCustomerInfo(string customer_id)
        {
            string query = $"select * from TBL_customer_info where customer_id = '{customer_id}'";
            DataTable dt = dh.getDataTable(query);
            return dt.Rows.Count > 0 ? ToList(dt)[0] : null;
        }
        public List<CustomerInfo> ToList(DataTable dt)
        {
            List<CustomerInfo> l = new List<CustomerInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                CustomerInfo info = new CustomerInfo(
                    dr[0].ToString(), dr[1].ToString(),
                    dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString());
                l.Add(info);
            }
            return l;
        }
    }
}
