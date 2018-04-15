using _2.BL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class UsersController : Controller
    {
        UserManager userManager;
        public UsersController()
        {
            userManager = new UserManager();
        }
        // GET: Users

        //[Authorize(Roles = "Manager")]
        [Authorize]
        public ActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            var userToDelete = userManager.GetByID(id);
            if (userManager.Delete(userToDelete))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult UpdateUser1(int id)
        {
            if (ModelState.IsValid)
            {
                var userToUpdat = userManager.GetByID(id);
                userManager.Update(userToUpdat);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult EditUser(int id)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = userManager.GetByID(id);
                return View(userToUpdate);
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult UpdateUser(User userToUpdate)
        {
            userManager.Update(userToUpdate);
            return RedirectToAction("Index");
        }


    }
}
