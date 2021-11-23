using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        // GET: Admin/ProductAdmin
        public ICategoryBUS categoryBUS = new CategoryBUS();
        public IProductBUS productBUS = new ProductBUS();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getProductList(Guid category_id, int page_index, int page_size, string product_name)
        {
            ProductList pl = productBUS.getProductList(category_id, page_index, page_size, product_name);

            return Json(pl, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getCategoryList()
        {
            List<Category> lc = categoryBUS.getCategoryList();

            return Json(new { list_category = lc }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void deleteProduct(Guid product_id)
        {
            productBUS.deleteProduct(product_id);
        }
        [HttpPost]
        public void addProduct(Product product)
        {
            productBUS.addProduct(product);
        }
        //public JsonResult getCategoryName(Guid category_id)
        //{
        //     string category_name = categoryBUS.getCategoryName(category_id);

        //    return Json(category_name, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult Upload(string product_code, string category)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath($"~/assets/images/");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];

                var filename = $"{product_code}_{category}_1" + Path.GetExtension(pf.FileName);

                pf.SaveAs(path + filename);
                l.Add(filename);
            }

            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}