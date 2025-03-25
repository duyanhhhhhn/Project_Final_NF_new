using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Project_Final_NF.Models.ModelViews;
using Project_Final_NF.Models.Reponsitories;

namespace Project_Final_NF.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Product()
        {
            HashSet<ProductView> list = new HashSet<ProductView>();
            var q = ProductRepository.Instance.All();
            list = q ?? new HashSet<ProductView>();
            ViewBag.data = list;
            return View();
        }
        public ActionResult Add_product()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Add_product(HttpPostedFileBase fuImage, ProductView model)
        {
            try
            {
                if (fuImage != null)
                {
                    string newFileName = $"{DateTime.Now.Ticks.ToString()} {fuImage.FileName}";
                    string fullPathSave = $"{Server.MapPath(Url.Content("~/content/images"))}\\{newFileName}";
                    fuImage.SaveAs(fullPathSave);
                    model.ImageUrl = newFileName;
                }

                model.Name = Request.Form["Name"];
                model.Description = Request.Form["Description"];
                model.StockQuantity = int.Parse(Request.Form["StockQuantity"]);
                ProductRepository.Instance.Create(model);
            }
            catch (EntityException ex)
            {

                Debug.Write(ex.Message);
            }

            return RedirectToAction("/product");
        }
    }
}