using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CustomerDAO : ICustomerDAO
    {
        public DataHelper dh = new DataHelper();
        public List<Customer> GetCustomers()
        {
            string query = $"select * from TBL_customer";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }
        public Customer Login(string username, string password)
        {
            string query = $"select * from TBL_customer where username = '{username}'" +
                $" and password = '{password}'";
            DataTable dt = dh.getDataTable(query);
            return dt.Rows.Count > 0 ? ToList(dt)[0] : null;
        }
        public void Register(Customer customer)
        {
            dh.storeReaders("PROC_Customer_Register",
                customer.customer_id, customer.info.customer_info_id,
                customer.username, customer.info.customer_name,
                customer.info.phone_number, customer.password
            );
        }
        public List<Customer> ToList(DataTable dt)
        {
            List<Customer> list = new List<Customer>();
            ICustomerInfoDAO customerInfoDAO = new CustomerInfoDAO();
            foreach (DataRow row in dt.Rows)
            {
                CustomerInfo info = customerInfoDAO.GetCustomerInfo(row[0].ToString());
                Customer user = new Customer(
                    row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), int.Parse(row[3].ToString()),
                    info);
                list.Add(user);
            }
            return list;
        }
    }
}
