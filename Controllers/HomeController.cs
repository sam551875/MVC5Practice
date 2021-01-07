using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Practice.Common.Common;
using MVC5Practice.Models.Home;


namespace MVC5Practice.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if(isLogged() == false)
            {
                return RedirectToAction("Login", "Home");
            }
            ShowLogerInfo();

            ViewBag.Title = "MT103電文合併平台";
            ViewBag.UserName = HttpContext.Session["UserName"].ToString();
            return View();
        }

        public ActionResult About()
        {
            if (isLogged() == false)
            {
                return RedirectToAction("Login", "Home");
            }

            ShowLogerInfo();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (isLogged() == false)
            {
                return RedirectToAction("Login", "Home");
            }

            ShowLogerInfo();

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

            HideLogerInfo();

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
            if (isLogged() == false)
            {
                return RedirectToAction("Login", "Home");
            }

            ShowLogerInfo();

            ViewBag.Message = "TxnPage1";

            return View();
        }

        [HttpPost]
        public ActionResult TxnPage1(MT103Format model)
        {
            try
            {
                //if(
                //    model.SendersReference == "" || model.TimeIndication == "" || model.BankOprationCode == "" || model.InstructionCode == "" || model.TransactionTypeCode == "" ||
                //    model.ValueDate_CurrencyCode_Amount == "" || model.Currency_InstructedAmount == "" || model.ExchangeRate == "" || model.OrderingCustomer == "" || model.SendingInstitution == "" ||
                //    model.OrderingInstitution == "" || model.SendersCorrespondent == "" || model.ReceiversCorrespondent == "" || model.ThirdReimbursementInstitution == "" || model.IntermediaryInstitution == "" ||
                //    model.AccountWithInstitution == "" || model.BeneficiaryCustomer == "" || model.RemittanceInformation == "" || model.DetailsofCharges == "" || model.SendersCharges == "" ||
                //    model.ReceiversCharges == "" || model.SendertoReceiverInformation == "" || model.RegulatoryReporting == ""
                //)
                //{
                //    return RedirectToAction("TxnPage1", "Home");
                //}
                //SetTxnSession("TxnPage1", model);
                //return RedirectToAction("Index", "Home", model);
                return RedirectToAction("TxnPage1", "Home");
            }
            catch
            {
                return View("ErrorPage");
            }
            
        }
        public ActionResult AorPage1()
        {
            if (isLogged() == false)
            {
                return RedirectToAction("Login", "Home");
            }

            ShowLogerInfo();

            try
            {
                var SelectF50 = new List<SelectListItem>()
                {
                    new SelectListItem {Text="F50A", Value = "Option A"},
                    new SelectListItem {Text="F50F", Value = "Option F"},
                    new SelectListItem {Text="F50K", Value = "Option K"}
                };
                var SelectF52 = new List<SelectListItem>()
                {
                    new SelectListItem {Text="F52A", Value = "Option A"},
                    new SelectListItem {Text="F52D", Value = "Option D"}
                };
                var SelectF53 = new List<SelectListItem>()
                {
                    new SelectListItem {Text="F53A", Value = "Option A"},
                    new SelectListItem {Text="F53B", Value = "Option B"},
                    new SelectListItem {Text="F53D", Value = "Option D"}
                };
                var SelectF54 = new List<SelectListItem>()
                {
                    new SelectListItem {Text="F54A", Value = "Option A"},
                    new SelectListItem {Text="F54B", Value = "Option B"},
                    new SelectListItem {Text="F54D", Value = "Option D"}
                };

                SelectF50.Where(q => q.Value == "Option A").First().Selected = true;
                SelectF52.Where(q => q.Value == "Option A").First().Selected = true;
                SelectF53.Where(q => q.Value == "Option A").First().Selected = true;
                SelectF54.Where(q => q.Value == "Option A").First().Selected = true;
                ViewBag.SelectF50 = SelectF50;
                ViewBag.SelectF52 = SelectF52;
                ViewBag.SelectF53 = SelectF53;
                ViewBag.SelectF54 = SelectF54;

                ViewBag.Message = "AorPage1";
                return View();
            }
            catch
            {
                return View("Error");
            }

            
        }


        //--------------------------方法集暫時區塊------------------------------//
        private bool isLogged()
        {
            if (HttpContext.Session["UserName"] is null || HttpContext.Session["UserName"].ToString() == "")
            {
                return false;
            }
            return true;
        }
        public void ShowLogerInfo()
        {
            ViewBag.UserName = HttpContext.Session["UserName"].ToString();
            ViewBag.Welcome = "歡迎回來";
        }
        public void HideLogerInfo()
        {
            ViewBag.UserName = "";
            ViewBag.Welcome = "";
            HttpContext.Session.Remove("UserName");
        }
        
        

    }
}