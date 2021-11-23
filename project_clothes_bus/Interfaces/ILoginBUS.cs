using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public interface IUserBUS
    {
        User getUser(string username, string password);
        Customer getCustomer(string username, string password);

    }
}
