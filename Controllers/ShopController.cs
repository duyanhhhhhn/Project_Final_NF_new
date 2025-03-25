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
      
    }
}