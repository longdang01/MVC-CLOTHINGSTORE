using Newtonsoft.Json;
using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace project_clothes_app.Areas.Admin.Controllers
{
    public class AdministrationController : Controller
    {
        public IAdministrationBUS administrationBUS = new AdministrationBUS();

        // GET: Admin/Administration
        public ActionResult LoginAdmin()
        {
            return View("LoginAdmin");
        }
        [HttpGet]
        public JsonResult GetUser(string username, string password)
        {
            User user = administrationBUS.Login(username, password);
            //Session["login"] = (user == null) ? "0" : "1";
            //Session["user"] = (user == null) ? "" : JsonConvert.SerializeObject(user);

            //return Json(new { login = Session["login"], user = user }, JsonRequestBehavior.AllowGet);
            if(user == null) { return Json(user, JsonRequestBehavior.AllowGet); }
            else
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginAdmin");
        }

    }
}