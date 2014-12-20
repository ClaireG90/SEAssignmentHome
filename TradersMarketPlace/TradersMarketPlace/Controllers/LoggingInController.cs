using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradersMarketPlace.Models;
using Common;
using Business;
using System.Web.Security;

namespace TradersMarketPlace.Controllers
{
    public class LoggingInController : Controller
    {
        //
        // GET: /UserAuthentication/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new Models.LoggingInModel());
        }

        [HttpPost]
        public ActionResult Login(LoggingInModel model)
        {
            BAAccount baAccount = new BAAccount();
            if (baAccount.GetAccountByUsernameAndPassword(model.UserName, model.Password) != null)
            {
                Account check = new BAAccount().GetAccountByUsername(model.UserName);


                if (check.Password.Equals(model.Password) && check.Username.Equals(model.UserName))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, true);
                    Session["username"] = model.UserName;
                    Session["accountid"] = check.ID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Login credentials";
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "Invalid Login credentials";
                return View();
            }
            //if (new BAAccount().GetAccountByUsername(model.UserName)!= null)
            //{
            //    Account account = new BAAccount().GetAccountByUsername(model.UserName);

            //    if (model.Password != account.Password)
            //    {
            //        ModelState.AddModelError("", "Token is not valid.");
            //    }
            //    else
            //    {
            //        Session["accountID"] = account.ID;

            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Username does not exist.");
            //}

            //return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
    }
}
