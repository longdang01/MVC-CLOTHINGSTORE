using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class LoginBUS
    {
        UserDAO userDAO = new UserDAO();
        CustomerDAO customerDAO = new CustomerDAO();

        public User getUser(string username, string password)
        {
            return userDAO.getUser(username, password);
        }
        public Customer getCustomer(string username, string password)
        {
            return customerDAO.getCustomer(username, password);
        }
    }
}
