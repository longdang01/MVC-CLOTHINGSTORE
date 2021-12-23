using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class UserDAO : IUserDAO
    {
        public DataHelper dh = new DataHelper();
        public List<User> GetUsers()
        {
            string query = $"select * from TBL_user";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }
        public User Login(string username, string password)
        {
            string query = $"select * from TBL_user where username = '{username}'" +
                $" and password = '{password}'";
            DataTable dt = dh.getDataTable(query);
            return dt.Rows.Count > 0 ? ToList(dt)[0] : null;
        }
        public void Register(User user)
        {
            dh.storeReaders("PROC_User_Register",
                user.user_id, user.info.user_info_id,
                user.username, user.info.full_name,
                user.info.phone_number, user.password
            );
        }
        public List<User> ToList(DataTable dt)
        {
            List<User> list = new List<User>();
            IUserInfoDAO userInfoDAO = new UserInfoDAO();
            foreach (DataRow row in dt.Rows)
            {
                UserInfo info = userInfoDAO.GetUserInfo(row[0].ToString());
                User user = new User(
                    row[0].ToString(), row[1].ToString(),
                    row[2].ToString(), row[3].ToString(),
                    int.Parse(row[4].ToString()),
                    info);
                list.Add(user);
            }
            return list;
        }
    }
}
