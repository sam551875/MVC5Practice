using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Practice.Models.Home;

namespace MVC5Practice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session["UserName"].ToString();
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

        public ActionResult Test()
        {
            ViewBag.Message = "Sams Test.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Sams LogIn.";

            return View();
        }
        [HttpPost]
        public ActionResult LogIn(BeginModel model)
        {
            try
            {
                if(model.username == "" || model.password == "")
                {
                    return View("~/Views/Home/LogIn.cshtml");
                }

                HttpContext.Session["UserName"] = model.username;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("ErrorPage");
            }
        }

        public ActionResult TxnPage1()
        {
            ViewBag.Message = "TxnPage1";

            return View();
        }

    }
}