    using _1.UI.Models;
using _2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _1.UI.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager;
        public int UserId { get; set; }
        public LoginController()
        {
            userManager = new UserManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Email, string Password, string returnUrl)
        {
            returnUrl = ViewBag.Title;
            var users = userManager.Users.ToList();
            if (!(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)))
            {
                    foreach (var item in users)
                    {
                        if (item.E_mail == Email && item.Password == Password)
                        {
                            /* login succeeded !!! :) */

                            // save the user identity in a cookie & session
                            FormsAuthentication.SetAuthCookie(Email, false);

                            if (string.IsNullOrEmpty(returnUrl))
                            {
                                // redirect to the default page
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                // redurect to the last requested page
                                return Redirect(returnUrl);
                            }
                        }
                    }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}