using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Final_NF.Models.ModelViews;
using Project_Final_NF.Models.Reponsitories;

namespace Project_Final_NF.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            HashSet<ProductView> list = new HashSet<ProductView>();
            var q = ProductRepository.Instance.All();
            list = q ?? new HashSet<ProductView>();
            ViewBag.data = list;
            return View();
        }


    [HttpPost]
        public ActionResult PlaceOrder(List<OrderDetailView> orderItems)
        {
            var user = Session["acc"] as MemberView; 
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var order = new OrderView
            {
                UserId = user.Id,
            };

            int orderId = OrderRepository.Instance.Create(order, orderItems);

            if (orderId > 0)
            {
                ViewBag.Message = "Đặt hàng thành công!";
            }
            else
            {
                ViewBag.Message = "Đặt hàng thất bại!";
            }

            return RedirectToAction("Index");
        }
    }
}
