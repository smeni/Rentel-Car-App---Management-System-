using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.DAL;
using _4.Entities;

namespace _2.BL
{
    public class CarsManager : IDisposable
    {
        DB_Car_RentalEntities ctx;
        public CarsManager()
        {
            ctx = new DB_Car_RentalEntities();
        }
        public List<Car> GetAll()
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                return ctx.Cars.Include("Cartyp").Where(c => c.CarID == c.Cartyp.TypeID && c.IsActiv == true || c.Cartyp.IsActiv == true).ToList();
            }
        }

        public List<Cartyp> CarsType
        {
            get
            {
                return ctx.Cartyps.ToList();
            }
        }

        public List<Car> Cars
        {
            get
            {
                return ctx.Cars.Include("Cartyp").Where(c => c.CarID == c.Cartyp.TypeID && c.IsActiv == true || c.Cartyp.IsActiv == true).ToList();
                //return ctx.Cars.ToList();
            }
        }

        public bool deleteTest(Car carToDelete)
        {
            var c = ctx.Cars.Include("Cartyp").Where(ca => ca.CarID == ca.Cartyp.TypeID);
            int count = ctx.SaveChanges();
            return count > 0;
        }

        public Car GetByID(int CarID)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                return ctx.Cars.Where(c => c.CarID == CarID && CarID == c.Cartyp.TypeID).FirstOrDefault();
            }
        }

        public Cartyp GetCarTypeByID(int CarID)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                return ctx.Cartyps.Where(c => c.TypeID == CarID).FirstOrDefault();
            }
        }

        public bool Insert(Car newCar, Cartyp newcartype)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                ctx.Cars.Add(newCar);

                ctx.Cartyps.Add(newcartype);

                int count = ctx.SaveChanges();


                return count > 0;
            }
        }

        public bool Update(Car carToUpdate)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // option 1: find the employee, update the properties, save cahnges
                //var e = ctx.Employees.Find(employeeToUpdate.EmployeeID);
                //e.FirstName = employeeToUpdate.FirstName;
                //e = employeeToUpdate;

                // option 2: -- need to make the ctx as data member
                //var e = GetByID(employeeToUpdate.EmployeeID);
                //e.FirstName = employeeToUpdate.FirstName;
                //e = employeeToUpdate;

                // option 3: add the employee to the context

                // 1) attach the employee to the context (in the memory)
                ctx.Cars.Attach(carToUpdate);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(carToUpdate).State = System.Data.EntityState.Modified;

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public bool Delete(Car carToDelete)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // 1) attach the employee to the context (in the memory)
                ctx.Cars.Attach(carToDelete);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(carToDelete).State = System.Data.EntityState.Modified;
                if (carToDelete.IsActiv == true)
                {
                    carToDelete.IsActiv = false;
                    carToDelete.Cartyp.IsActiv = false;
                }

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public void Dispose()
        {

        }
    }

    public class BranchManager : IDisposable
    {
        DB_Car_RentalEntities ctx;
        public BranchManager()
        {
            ctx = new DB_Car_RentalEntities();
        }

        public List<Branch> Branches
        {
            get
            {
                return ctx.Branches.ToList();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class ManufacturerManager : IDisposable
    {
        DB_Car_RentalEntities ctx;
        public ManufacturerManager()
        {
            ctx = new DB_Car_RentalEntities();
        }

        public List<Cartyp> Manufacturer
        {
            get
            {
                return ctx.Cartyps.ToList();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
