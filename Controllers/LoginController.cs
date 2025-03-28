using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Project_Final_NF.Models.ModelViews;
using Project_Final_NF.Models.Reponsitories;

namespace Project_Final_NF.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            MemberView item = (MemberView)Session["acc"];
            if (item != null)
            {
                string username = item.UserName;
                string password = item.Password;
                MemberView mv = UserRepository.Instance.CheckLogin(username, password);
                if (mv != null)
                {
                    Session["acc"] = mv;
                    switch (mv.IdAuthentication)
                    {
                        case 1: return RedirectToAction("index", "Admin");break ;
                        case 2: return RedirectToAction("index","Home"); break;
                    }
                }
            }
            return View();
        }
        public ActionResult acc_checked()
        {
            string username = Request.Form["UserName"];
            string password = Request.Form["Password"];
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("login", new { username, password });
            }
            MemberView mv = UserRepository.Instance.CheckLogin(username, password);
            if (mv != null)
            {
                Session["acc"] = mv;
                switch (mv.IdAuthentication)
                {
                    case 1: return RedirectToAction("index", "Admin", new { mv }); break;
                    case 2:
                        return RedirectToAction("index","Home"); break;
                }
            }
            return RedirectToAction("Index", "Home", new { username, password });
        }
        public ActionResult Logout()
        {
            Session.Clear(); 
            Session.Abandon();
            return RedirectToAction("Index", "Login"); 
        }

    }
}