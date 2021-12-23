using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public interface IAdministrationBUS
    {
        //Login, register
        User Login(string username, string password);
        void Register(User user);
    }
}
