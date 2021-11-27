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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //public JsonResult Logout()
        //{
        //    Session.Remove("user_current");
        //    return Json(0, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Login(string username, string password, bool remember_password)
        //{
        //    Customer c = loginBUS.getCustomer(username, password);
        //    if(c != null)
        //        if (!remember_password) c.user.password = "";
        //    Session["user_current"] = (c != null) ? (JsonConvert.SerializeObject(c)) : "";

        //    return Json(new { user_current = Session["user_current"] }, JsonRequestBehavior.AllowGet);
        //}
    }
}