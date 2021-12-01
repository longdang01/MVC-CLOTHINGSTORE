using Newtonsoft.Json;
using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class CustomerController : Controller
    {
        public IClientBUS clientBUS = new ClientBUS();
        // GET: Customer
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpGet]
        public JsonResult GetCustomer(string username, string password)
        {
            Customer customer = clientBUS.Login(username, password);
            Session["login"] = (customer == null) ? "0" : "1";
            Session["customer"] = (customer == null) ? "" : JsonConvert.SerializeObject(customer);

            return Json(new { login = Session["login"], customer = customer }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void SignUp(string username, string name, string phone_number, string password)
        {
            Customer customer = new Customer();
            customer.username = username;
            customer.password = password;
            customer.info = new CustomerInfo();
            customer.info.customer_name = name;
            customer.info.phone_number = phone_number;

            clientBUS.Register(customer);
        }
        public JsonResult SignOut()
        {
            Session.Remove("login");
            Session.Remove("customer");
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}