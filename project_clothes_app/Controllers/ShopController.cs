using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class ShopController : Controller
    {
        public ProductBUS productBUS = new ProductBUS();
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getProducts()
        {
            List<Product> l = productBUS.getProducts();

            return Json(new { products = l }, JsonRequestBehavior.AllowGet);
        }
    }
}