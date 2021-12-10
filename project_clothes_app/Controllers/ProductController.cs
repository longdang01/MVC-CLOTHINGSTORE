using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class ProductController : Controller
    {
        public ProductBUS productBUS = new ProductBUS();
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetProductList(string category_id, int page_index, int page_size, string product_name)
        {
            ProductList pl = productBUS.GetProductList(category_id, page_index, page_size, product_name);

            return Json(pl, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNewArrival(int rows)
        {
            List<Product> l = productBUS.GetNewArrival(rows);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetHot(int rows)
        {
            List<Product> l = productBUS.GetHot(rows);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBestSeller(int rows)
        {
            List<Product> l = productBUS.GetBestSeller(rows);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSale(int rows)
        {
            List<Product> l = productBUS.GetSale(rows);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}