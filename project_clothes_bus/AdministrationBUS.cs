using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class AdministrationBUS : IAdministrationBUS
    {
        IUserDAO userDAO = new UserDAO();
        IUserInfoDAO userInfoDAO = new UserInfoDAO();
        //Acount
        public User Login(string username, string password)
        {
            return userDAO.Login(username, password);
        }
        public void Register(User user)
        {
            //user.info.customer_info_id = GenerateCustomerId();
            //user.customer_id = GenerateCustomerId();

            userDAO.Register(user);
        }

    }
}
