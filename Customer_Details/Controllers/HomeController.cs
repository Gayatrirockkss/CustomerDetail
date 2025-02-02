﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_Details.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public HttpUnauthorizedResult httpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult("Access is Denied");
        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Unauthorized Access!";
            return View();
        }
    }
}