using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.IO;
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
            HashSet<OrderView> list = new HashSet<OrderView>();
            var q = OrderRepository.Instance.All();
            list = q ?? new HashSet<OrderView>();
            ViewBag.data = list;
            return View();

        }
        public ActionResult Order()
        {
            HashSet<OrderView> list = new HashSet<OrderView>();
            var q = OrderRepository.Instance.All();
            list = q ?? new HashSet<OrderView>();
            ViewBag.data = list;
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
            var q = ProductRepository.Instance.All();
            return View(q);

        }
        [HttpPost]
        public ActionResult Add_product(HttpPostedFileBase ImageUrl, ProductView model)
        {
            try
            {
                string directoryPath = Server.MapPath("~/Content/client/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (ImageUrl != null && ImageUrl.ContentLength > 0)
                {
                    string safeFileName = Path.GetFileNameWithoutExtension(ImageUrl.FileName)
                                            .Replace(" ", "_")
                                            + Path.GetExtension(ImageUrl.FileName);
                    string newFileName = $"{DateTime.Now.Ticks}_{safeFileName}";
                    string fullPathSave = Path.Combine(directoryPath, newFileName);

                    ImageUrl.SaveAs(fullPathSave);
                    model.ImageUrl = newFileName;
                }
                else
                {
                    model.ImageUrl = "defaultimage.jpg";
                }

                ProductRepository.Instance.Create(model);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                System.IO.File.WriteAllText(Server.MapPath("~/Content/log.txt"), ex.ToString());
            }
            return RedirectToAction("/product");
        }

       
    }
}