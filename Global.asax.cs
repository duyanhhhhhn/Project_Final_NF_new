﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Project_Final_NF.Models.ModelViews;
using Project_Final_NF.Models.Reponsitories;

namespace Project_Final_NF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        { }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var app = (HttpApplication) sender;
            var uriObj = app.Context.Request.Url.AbsolutePath;
            if (uriObj.ToLower().Contains("admin") == true || uriObj.ToLower().Contains("member") == true)
            {
                if (app.Context.Session["acc"] != null)
                {
                    var usr = (MemberView)app.Context.Session["acc"];
                    var id_auth = usr.IdAuthentication;
                    if (UserRepository.Instance.GetAuthorizationMember(id_auth, uriObj) == false)
                    {
                        app.Context.Response.RedirectToRoute(new { controller = "Home", action = "index" });
                    }
                }
                else if (uriObj.ToLower().Contains("admin") || uriObj.ToLower().Contains("member"))
                {
                    app.Context.Response.RedirectToRoute(new { controller = "Home", action = "index" });
                }
            }
        }
    }
}
