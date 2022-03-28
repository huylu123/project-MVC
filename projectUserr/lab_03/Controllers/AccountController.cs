using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_03.Models;

namespace lab_03.Controllers
{
    public class AccountController : Controller
    {
        projectEntities1 ctx = new projectEntities1();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        //method model
        [HttpPost]
        public ActionResult Register(customer sp)
        {

            if (ModelState.IsValid)
            {
                var checkID = ctx.customers.FirstOrDefault(s => s.ID == sp.ID);
                if (checkID == null)
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    //ctx.customers.Add(sp);
                    //ctx.SaveChanges();
                    //return RedirectToAction("Register");
                }

                var checkEmail = ctx.customers.FirstOrDefault(s => s.email == sp.email);
                if (checkEmail == null)
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.customers.Add(sp);
                    ctx.SaveChanges();
                    return RedirectToAction("Login");
                }else
                {
                    ViewBag.error = "Email already!!!!!!!";
                    return View();
                }
            }     
            return View();
        }
        [HttpPost]
        public ActionResult Authen(customer cus)
        {
            var check = ctx.customers.Where(s => s.email.Equals(cus.email)
            && s.passwork.Equals(cus.passwork)).FirstOrDefault();
            if (check == null)
            {
                cus.LoginErrorMessage = "Error Email or Password! Try Again!!!";
                return View("Login", cus);
            }else
            {
                Session["ID"] = cus.ID;
                Session["email"] = cus.email;
                return RedirectToAction("Index", "Home");
            }
           // return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }
    }
}