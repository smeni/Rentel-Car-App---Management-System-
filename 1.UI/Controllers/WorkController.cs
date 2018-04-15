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
    public class WorkController : Controller
    {
        CarsManager carsmanager;
        OrderManager ordermanager;
        manufacturrerViewModel manufacturrerViewModel;
        ManufacturerManager ManufacturerManager;
        public WorkController()
        {
            carsmanager = new CarsManager();
            ordermanager = new OrderManager();
            manufacturrerViewModel = new manufacturrerViewModel();
            ManufacturerManager = new ManufacturerManager();
        }

        // GET: Work
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        /// <summary>
        ///
        //שאר הפרמטרים לבחירת רכב להשכרה-->להכניס לפונקציה
        /// </summary>
        ///  string manufacturer = "", string model = "", int yearOfManufacturer = 2016, string transmission = "auto"
        ///  , string manufacturer, string model, int yearOfManufacturer, string transmission
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>

        public ActionResult GetCarsByFilter(DateTime start, DateTime end, Branch branch, string manufactur, string model, int year)
        {
            List<Car> availableCars = new List<Car>();
            var allCars = carsmanager.Cars.ToList();


            //1) Get all available Cars in the Date The Costumer nide.
            foreach (var item in allCars)
            {

                //if(item.BranchID==branch.BranchID)
                if (ordermanager.IsAvailableByDatte(start, end, item.C_License_number) == true)
                {
                    //2) Filter Cars by Parameters. 
                    if (item.Cartyp.Manufacturer == manufactur || item.Cartyp.Model == model || item.Cartyp.Year_of_Manufacturer == year)//       <----

                        //if (item.Manufacturer == manufacturer || item.Model == model || item.Year_of_Manufacturer == yearOfManufacturer || item.Transmission == transmission)
                        availableCars.Add(item);//List of all available Cars.
                }
            }

            //3) return PatialView by ajax.
            return View("AllCarsByPV", availableCars);
            //return PartialView("Test", availableCars);
        }

        public ActionResult TestAll(manufacturrerViewModel vm)
        {
            try
            {
                GetRelatedLists(vm);
                return View(vm);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AllCarsByPV()
        {
            var cars = carsmanager.Cars;

            return PartialView(cars);
        }

        public List<manufacturrerViewModel> GetRelatedLists(manufacturrerViewModel vm)
        {
            List<manufacturrerViewModel> manVM = new List<manufacturrerViewModel>();
            var cars = carsmanager.Cars.ToList();
            var typCAr = carsmanager.CarsType.ToList();
            var manuFact = ManufacturerManager.Manufacturer;
            var carMOdel = ManufacturerManager.Manufacturer;
            var yearOfManufact = ManufacturerManager.Manufacturer;

            foreach (var car in manuFact)
            {
                vm.Manufacturer = manuFact.Select(c => new SelectListItem()
                {
                    Text = c.Manufacturer,
                    Value = c.Manufacturer.ToString()

                }).ToList();

                vm.Model = manuFact.Select(m => new SelectListItem()
                {
                    Text = m.Model,
                    Value = m.Model.ToString()

                }).ToList();

                vm.YearOfManufacturer = manuFact.Select(m => new SelectListItem()
                {
                    Text = m.Year_of_Manufacturer.ToString(),
                    Value = m.Year_of_Manufacturer.ToString()

                }).ToList();
            }


            manVM.Add(vm);
            return manVM;
        }

        [Authorize]
        public ActionResult OrderDetails(DoOrderModel vm)
        {
            try
            {

                return View();
            }
            catch
            {
                return View("Error");

            }
        }

        public double DoCalculation1(int id, string manufactur, DateTime start, DateTime end)//חישוב עלות השכרה
        {
            List<DoOrderModel> listVM = new List<DoOrderModel>();
            var allCars = carsmanager.Cars.ToList();
            //var carto = allCars.Where(c => c.Cartyp.Manufacturer == manufactur).Select(x => x.CarID==id).FirstOrDefault();
            var carToCalculate = carsmanager.GetCarTypeByID(id);
            var total = (end - start).TotalDays;
            double CostOfRental = carToCalculate.Daily_cost * total;

            DoOrderModel vm = new DoOrderModel { };//<----

            return CostOfRental;
        }

        [Authorize]
        public ActionResult DoCalculation(int id, string manufactur, DateTime start, DateTime end)//חישוב עלות השכרה
        {
            List<DoOrderModel> listVM = new List<DoOrderModel>();
            var allCars = carsmanager.Cars.ToList();
            var carToCalculate = carsmanager.GetByID(id);
            var carToCalculate1 = carsmanager.GetCarTypeByID(id);
            var total = (end - start).TotalDays;
            double CostOfRental = carToCalculate1.Daily_cost * total;

            DoOrderModel vm = new DoOrderModel {
                carPicture = carToCalculate.Picture,
                carManufacture = carToCalculate1.Manufacturer,
                carModel = carToCalculate1.Model,
                Taking_Date = start,
                Return_Date = end,
                total = CostOfRental,
                Day_late = carToCalculate1.Day_late
            };//<----
            listVM.Add(vm);

            return View(vm);
        }


    }
}