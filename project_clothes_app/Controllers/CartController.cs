using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class CartController : Controller
    {
        public IClientBUS clientBUS = new ClientBUS();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetCart(string customer_id)
        {
            Cart cart = clientBUS.GetCart(customer_id);
            return Json(new { cart }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddToCart(Cart cart, CartDetail cartDetail)
        {
            clientBUS.AddToCart(cart, cartDetail);
        }
        [HttpPost]
        public void UpdateCartDetail(CartDetail cartDetail)
        {
            clientBUS.UpdateCartDetail(cartDetail);
        }
        [HttpPost]
        public void UpdateQuantity(CartDetail cartDetail)
        {
            clientBUS.UpdateQuantity(cartDetail);
        }
        [HttpPost]
        public void RemoveCartDetail(CartDetail cartDetail)
        {
            clientBUS.RemoveCartDetail(cartDetail);
        }
    }
}