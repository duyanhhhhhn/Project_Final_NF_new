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
        public JsonResult PlaceOrder(List<ProductView> cart)
        {
            if (cart == null || cart.Count == 0)
            {
                return Json(new { success = false, message = "Cart is empty!" });
            }

            try
            {
                var userSession = Session["acc"] as Project_Final_NF.Models.ModelViews.MemberView;
                if (userSession == null)
                {
                    return Json(new { success = false, message = "User is not logged in!", redirectUrl = Url.Action("Index", "Login") });
                }

                int userId = userSession.Id;

                var orderItems = cart.Select(p => new OrderDetailView
                {
                    ProductId = p.ProductId,
                    Quantity = 1,
                    Price = 0,
                    status = "Pending",
                }).ToList();

                var orderView = new OrderView
                {
                    UserId = userId
                };

                int orderId = OrderRepository.Instance.Create(orderView, orderItems);

                if (orderId > 0)
                {
                    return Json(new { success = true, message = "Order placed successfully!", orderId });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to place order!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }
}
