using _2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4.Entities;

namespace _1.UI.Controllers
{
    public class RegistrationController : Controller
    {
        UserManager userManager;
        public RegistrationController()
        {
            userManager = new UserManager();
        }

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Models.RegisterInfo registinfo)
        {
            bool b = false;
            // 1) validate the user details
            if (b)
            {
                User newUser = new User
                {
                    First_name = registinfo.Name,
                    Last_name = registinfo.LastName,
                    User_name = registinfo.UserName,
                    Birth_Date = registinfo.BirthDate,
                    Gender = registinfo.Gender,
                    E_mail = registinfo.Email,
                    Password = registinfo.Password
                };

                // 2) update the student in db
                userManager.Insert(newUser);
                //db.SaveChanges();

                // 3) return to list of all student
                return RedirectToAction("Index","Users");
            }
            else
            {
                //  חוזרים לאותו הוויו עם אותו המודל
                // ולא העתק שלו!!!!
                b = true;
                return View("Index");
            }
        }
    }
}