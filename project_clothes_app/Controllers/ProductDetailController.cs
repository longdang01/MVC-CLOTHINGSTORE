using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class ProductDetailController : Controller
    {
        public IProductBUS productBUS = new ProductBUS();
        // GET: ProductDetail
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getProductDetail(Guid product_id)
        {
            Product p = productBUS.getProductDetail(product_id);

            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}