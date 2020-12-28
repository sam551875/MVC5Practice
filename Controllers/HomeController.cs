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
                if(
                    model.SendersReference == "" || model.TimeIndication == "" || model.BankOprationCode == "" || model.InstructionCode == "" || model.TransactionTypeCode == "" ||
                    model.ValueDate_CurrencyCode_Amount == "" || model.Currency_InstructedAmount == "" || model.ExchangeRate == "" || model.OrderingCustomer == "" || model.SendingInstitution == "" ||
                    model.OrderingInstitution == "" || model.SendersCorrespondent == "" || model.ReceiversCorrespondent == "" || model.ThirdReimbursementInstitution == "" || model.IntermediaryInstitution == "" ||
                    model.AccountWithInstitution == "" || model.BeneficiaryCustomer == "" || model.RemittanceInformation == "" || model.DetailsofCharges == "" || model.SendersCharges == "" ||
                    model.ReceiversCharges == "" || model.SendertoReceiverInformation == "" || model.RegulatoryReporting == ""
                )
                {
                    return RedirectToAction("TxnPage1", "Home");
                }
                SetTxnSession("TxnPage1", model);
                return RedirectToAction("Index", "Home", model);
            }
            catch
            {
                return View("ErrorPage");
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
        private string _TxnSession = "Sam";
        protected object GetTxnSession(string key)
        {
            return Session[_TxnSession + "_" + key];
        }
        protected void SetTxnSession(string key, object obj)
        {
            Session[_TxnSession + "_" + key] = obj;
        }

    }
}