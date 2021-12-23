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
    [Authorize]
    public class ManageProductsController : Controller
    {
        // GET: Admin/ProductAdmin
        public ICategoryBUS categoryBUS = new CategoryBUS();
        public IProductBUS productBUS = new ProductBUS();
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
        [HttpGet]
        public JsonResult GetCategoryList()
        {
            List<Category> lc = categoryBUS.GetCategoryList();

            return Json(new { list_category = lc }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void RemoveProduct(string product_id)
        {
            productBUS.RemoveProduct(product_id);
        }
        [HttpPost]
        public void AddProduct(Product product)
        {
            productBUS.AddProduct(product);
        }
        [HttpPost]
        public void UpdateProduct(Product product)
        {
            productBUS.UpdateProduct(product);
        }
        [HttpPost]
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