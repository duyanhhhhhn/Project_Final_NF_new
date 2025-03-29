using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Final_NF.Models.ModelViews;
using Project_Final_NF.Models.Reponsitories;

namespace Project_Final_NF.Controllers
{
    public class MyOrderController : Controller
    {
        // GET: MyOrder
        public ActionResult Index()
        {
            var item = Session["acc"] as Project_Final_NF.Models.ModelViews.MemberView;

            if (item == null)
            {
                return RedirectToAction("index", "Login");
            }

            int userId = item.Id;
            var orders = OrderRepository.Instance.FindByUserId(userId); 

            ViewBag.data = orders ?? new HashSet<OrderView>();
            return View();
        }
        public JsonResult UpdateOrderStatus(int orderDetailId, string newStatus)
        {
            int result = OrderRepository.Instance.UpdateStatus(orderDetailId, newStatus);
            return Json(new { success = result > 0 });
        }
    }
}