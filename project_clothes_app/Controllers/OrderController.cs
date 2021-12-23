using project_clothes_bus;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_clothes_app.Controllers
{
    public class OrderController : Controller
    {
        public IManageOrderBUS manageOrderBUS = new ManageOrderBUS();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetOrders(string customer_id)
        {
            List<Order> orders = manageOrderBUS.GetOrders(customer_id);
            return Json(new { orders }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddOrder(Order order, List<OrderDetail> orderDetails)
        {
            manageOrderBUS.AddOrder(order, orderDetails);
        }
    }
}