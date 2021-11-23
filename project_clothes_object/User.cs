using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class User
    {
        public Guid user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string user_role { get; set; }
        public bool status { get; set; }
        public User()
        {

        }
        public User(Guid user_id, string username, string password, string user_role, bool status)
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.user_role = user_role;
            this.status = status;
        }
    }
}
