using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_object
{
    public class UserInfo
    {
        public string user_info_id { get; set; }
        public string user_id { get; set; }
        public string full_name { get; set; }
        public string date_of_birth { get; set; }
        public int gender { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public UserInfo() { }
        public UserInfo(string user_info_id, string user_id, string full_name,
            string date_of_birth, int gender, string address, string phone_number, string email)
        {
            this.user_info_id = user_info_id;
            this.user_id = user_id;
            this.full_name = full_name;
            this.date_of_birth = date_of_birth;
            this.gender = gender;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
        }
    }
}
