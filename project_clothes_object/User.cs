using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class User
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string user_role { get; set; }
        public int status { get; set; }
        public UserInfo info { get; set; }
        public User() { }
        public User(string user_id, string username,
            string password, string user_role, int status,
            UserInfo info
            )
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.user_role = user_role;
            this.status = status;
            this.info = info;
        }
    }
}
