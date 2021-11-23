using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class UserDAO
    {
        public DataHelper dh = new DataHelper();
        public User getUser(string username, string password)
        {
            string query = $"select * from TBL_user where username = '{username}' " +
                $"and password = '{password}'";
            DataTable dt = dh.getDataTable(query);
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                User u = new User(
                    Guid.Parse(dt.Rows[0][0].ToString()),
                    dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(),
                    dt.Rows[0][3].ToString(),
                    bool.Parse(dt.Rows[0][4].ToString()));
                return u;
            }
        }
        public User getUserCustomer(Guid user_id)
        {
            string query = $"select * from TBL_user where user_id = '{user_id}'";
            DataTable dt = dh.getDataTable(query);
            User u = new User();
            foreach (DataRow row in dt.Rows)
            {
                u.user_id = Guid.Parse(row[0].ToString());
                u.username = row[1].ToString();
                u.password = row[2].ToString();
                u.user_role = row[3].ToString();
                u.status = bool.Parse(row[3].ToString());
            }
            return u;
        }
    }
}
