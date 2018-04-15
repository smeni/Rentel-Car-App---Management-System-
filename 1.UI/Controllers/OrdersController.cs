using _1.UI.Models;
using _2.BL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class OrdersController : Controller
    {
        OrderManager orderManager;
        public OrdersController()
        {
            orderManager = new OrderManager();
        }

        // GET: Orders

        //[Authorize(Roles = "Manager")]
        [Authorize]
        public ActionResult Index()
        {
            List<OrdersViewModel> lvm = new List<OrdersViewModel>();
            var orders = orderManager.Orders;

            foreach (var item in orders)
            {
                OrdersViewModel vm = new OrdersViewModel();
                //user details
                vm.First_name = item.User.First_name;
                vm.Last_name = item.User.Last_name;
                vm.Gender = item.User.Gender;
                vm.E_mail = item.User.E_mail;

                //typecar details
                //vm.TypeID = item.Car.Cartyp.TypeID;
                vm.Manufacturer = item.Car.Cartyp.Manufacturer;
                vm.Model = item.Car.Cartyp.Model;
                vm.Year_of_Manufacturer = item.Car.Cartyp.Year_of_Manufacturer;

                //car details
                vm.Mileage = item.Car.Mileage;
                vm.Picture = item.Car.Picture;
                vm.C_License_number = item.Car.C_License_number;
                vm.BranchID = item.Car.BranchID;

                //order details
                vm.OrderID = item.OrderID;
                vm.UserID = item.UserID;
                vm.Taking_Date = item.Taking_Date;
                vm.Return_Date = item.Return_Date;
                vm.Actual_return_Date = item.Actual_return_Date;

                lvm.Add(vm);
            }
            return View(lvm);
        }

        public ActionResult DeleteOrder(int id)
        {
            var orderToDelete = orderManager.GetByID(id);
            if (orderManager.Delete(orderToDelete))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult EditOrder(int id)
        {
            if (ModelState.IsValid)
            {
                // 1) get the Product details
                var orderToUpdate = orderManager.GetByID(id);

                // 2) get the categories & suppliers lists
                // GetRelatedLists(vm);

                return View(orderToUpdate);
            }
            else
            {
                return View("Error");
            }

            //ProductViewModel vm = new ProductViewModel();

            //// 1) get the Product details
            //vm.Product = manager.GetById(id);

            //// 2) get the categories & suppliers lists
            //GetRelatedLists(vm);

            //return View(vm);
        }

        public ActionResult UpdateOrder(Order orderToUpdate)
        {
            orderManager.Update(orderToUpdate);
            return RedirectToAction("Index");
        }

        public ActionResult CreateNew(NewOrderVIewModel oVM)
        {
            List<NewOrderVIewModel> lovm = new List<NewOrderVIewModel>();


            // 1) check if valid?
            if (ModelState.IsValid)
            {
                oVM = new NewOrderVIewModel();
                Order neworder = new Order
                {
                    OrderID = oVM.OrderID,
                    UserID = oVM.UserID,
                    Taking_Date = oVM.Taking_Date,
                    Return_Date = oVM.Return_Date,
                    Actual_return_Date = oVM.Actual_return_Date
                };
                
                // 2) update the product in database
                orderManager.Insert(neworder);

                return RedirectToAction("Index");
            }
            else
            {
                // get the suppliers & categories lists
                GetRelatedLists(oVM);

                return View(oVM);
            }
        }

        public void GetRelatedLists(NewOrderVIewModel oVM)
        {
            UserManager userManager = new UserManager();
            CarsManager carsManager = new CarsManager();

            // 2) get all suppliers (id-name)
            var users = userManager.Users;

            // 3) get all categories (id-name)
            var cartyps = carsManager.CarsType;

            oVM.car = cartyps.Select(car => new SelectListItem()
            {
                Text = car.Manufacturer,
                Value = car.Manufacturer

            }).ToList();

            oVM.user = users.Select(user => new SelectListItem()
            {
                Text = user.User_name,
                Value = user.User_name
            }).ToList();

            //foreach (var user in users)
            //{
            //    SelectListItem item = new SelectListItem()
            //    {
            //        Text = user.User_name,
            //        Value = user.User_name
            //    };

            //    oVM.user.Add(item);
            //}

          

            userManager.Dispose();
            carsManager.Dispose();



        }

        public ActionResult CreateOrderByCostumer(DoOrderModel oVM)
        {
            List<DoOrderModel> lovm = new List<DoOrderModel>();


            // 1) check if valid?
            if (ModelState.IsValid)
            {
                oVM = new DoOrderModel();
                Order neworder = new Order
                {
                    OrderID = oVM.OrderID,
                    UserID = oVM.UserID,
                    Taking_Date = oVM.Taking_Date,
                    Return_Date = oVM.Return_Date,
                    License_number = oVM.License_number,
                    Actual_return_Date = oVM.Actual_return_Date,
                    IsActiv=true
                };

                // 2) update the product in database
                orderManager.Insert(neworder);

                return RedirectToAction("TestAll", "Work");
            }
            else
            {
                // get the suppliers & categories lists
                //GetRelatedLists(oVM);

                return View(oVM);
            }
        }
    }
}
