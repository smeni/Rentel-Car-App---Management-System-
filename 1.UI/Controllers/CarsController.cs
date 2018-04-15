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
    public class CarsController : Controller
    {
        CarsManager carsmanager;
        public CarsController()
        {
            carsmanager = new CarsManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Cars
        [Authorize]
        public ActionResult CartypsAndCar()//מציג את שתי טבלאות הרכבים
        {
            List<CarsViewModel> listcvm = new List<CarsViewModel>();
            var carsfromDB = carsmanager.Cars;

            foreach (var item in carsfromDB)
            {
                CarsViewModel vm = new CarsViewModel();

                vm.TypeID = item.Cartyp.TypeID;
                vm.Manufacturer = item.Cartyp.Manufacturer;
                vm.Model = item.Cartyp.Model;
                vm.Year_of_Manufacturer = item.Cartyp.Year_of_Manufacturer;
                vm.Transmission = item.Cartyp.Transmission;
                vm.Daily_cost = item.Cartyp.Daily_cost;
                vm.Day_late = item.Cartyp.Day_late;

                vm.CarID = item.CarID;
                vm.Mileage = item.Mileage;
                vm.Picture = item.Picture;
                vm.IsRepaired = item.IsRepaired;
                vm.IsAvailable = item.IsAvailable;
                vm.C_License_number = item.C_License_number;
                vm.BranchID = item.BranchID;

                listcvm.Add(vm);
            }
            return View(listcvm);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create(CarsViewModel cVM)
        {
            // 1) validate the user details
            if (ModelState.IsValid)
            {
                Cartyp newctp = new Cartyp
                {
                    TypeID = cVM.TypeID,
                    Manufacturer = cVM.Manufacturer,
                    Model = cVM.Model,
                    Year_of_Manufacturer = cVM.Year_of_Manufacturer,
                    Transmission = cVM.Transmission,
                    Daily_cost = cVM.Daily_cost,
                    Day_late = cVM.Daily_cost,
                    IsActiv = true
                };

                Car newc = new Car
                {
                    CarID = cVM.CarID,
                    Mileage = cVM.Mileage,
                    Picture = cVM.Picture,
                    IsRepaired = cVM.IsRepaired,
                    IsAvailable = cVM.IsAvailable,
                    C_License_number = cVM.C_License_number,
                    BranchID = cVM.BranchID,
                    IsActiv = true
                };

                // 2) update the student in db
                carsmanager.Insert(newc, newctp);
                //db.SaveChanges();

                // 3) return to list of all student
                return RedirectToAction("CartypsAndCar");
            }
            else
            {
                //  חוזרים לאותו הוויו עם אותו המודל
                // ולא העתק שלו!!!!
                return View("Index");
            }
        }

        // POST: Cars/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                // 1) get the cars details
                var carToUpdate = carsmanager.GetByID(id);


                return View(carToUpdate);
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult UpdateCar(Car carToUpdate)
        {
            carsmanager.Update(carToUpdate);
            return RedirectToAction("CartypsAndCar");
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult DeleteCar(int id)
        {
            var carToDelete = carsmanager.GetByID(id);
            if (carsmanager.Delete(carToDelete))
            {
                return RedirectToAction("CartypsAndCar");
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Cars/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
