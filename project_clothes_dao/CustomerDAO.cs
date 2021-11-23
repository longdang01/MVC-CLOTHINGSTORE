using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CustomerDAO
    {
        public DataHelper dh = new DataHelper();
        public UserDAO userDAO = new UserDAO();
        public Customer getCustomer(string username, string password)
        {
            string query = $"select c.* from TBL_customer c" +
                $" left join TBL_user u on u.user_id = c.customer_id" +
                $" where username = '{username}' " +
                $" and password = '{password}'";
            DataTable dt = dh.getDataTable(query);
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                User user = userDAO.getUserCustomer(Guid.Parse(dt.Rows[0][0].ToString()));
                Customer c = new Customer(
                    Guid.Parse(dt.Rows[0][0].ToString()),
                    dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(),
                    dt.Rows[0][3].ToString(),
                    dt.Rows[0][4].ToString(),
                    user);
                return c;
            }
        }
    }
}
