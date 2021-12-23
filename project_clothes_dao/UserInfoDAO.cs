using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class UserInfoDAO : IUserInfoDAO
    {
        public DataHelper dh = new DataHelper();
        public List<UserInfo> GetUserInfos()
        {
            string query = $"select * from TBL_user_info";
            DataTable dt = dh.getDataTable(query);
            return ToList(dt);
        }
        public UserInfo GetUserInfo(string user_id)
        {
            string query = $"select * from TBL_user_info where user_id = '{user_id}'";
            DataTable dt = dh.getDataTable(query);
            return dt.Rows.Count > 0 ? ToList(dt)[0] : null;
        }
        public List<UserInfo> ToList(DataTable dt)
        {
            List<UserInfo> l = new List<UserInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                UserInfo info = new UserInfo(
                    dr[0].ToString(), dr[1].ToString(),
                    dr[2].ToString(), dr[3].ToString(),
                    int.Parse(dr[4].ToString()), dr[5].ToString(),
                    dr[6].ToString(), dr[7].ToString());
                l.Add(info);
            }
            return l;
        }
    }
}
