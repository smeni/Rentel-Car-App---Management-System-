using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.DAL;
using _4.Entities;

namespace _2.BL
{
    public class OrderManager : IDisposable
    {
        DB_Car_RentalEntities ctx;
        public OrderManager()
        {
            ctx = new DB_Car_RentalEntities();
        }

        public List<Order> Orders
        {
            get
            {
                return ctx.Orders.Include("User").Where(o => o.UserID == o.User.UserID && o.IsActiv == true).ToList();
                //return ctx.Orders.ToList();
            }
        }

        public Order GetByID(int orderID)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                return ctx.Orders.Where(o => o.OrderID == orderID).FirstOrDefault();
            }
        }

        public bool Insert(Order neworder)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                ctx.Orders.Add(neworder);

                int count = ctx.SaveChanges();
                return count > 0;
            }
        }

        public bool Update(Order orderToUpdate)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // 1) attach the employee to the context (in the memory)
                ctx.Orders.Attach(orderToUpdate);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(orderToUpdate).State = System.Data.EntityState.Modified;

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public bool Delete(Order orderToDelete)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // 1) attach the employee to the context (in the memory)
                ctx.Orders.Attach(orderToDelete);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(orderToDelete).State = System.Data.EntityState.Modified;
                if (orderToDelete.IsActiv == true)
                    orderToDelete.IsActiv = false;

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;

            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public bool IsAvailableByDatte(DateTime start, DateTime end, int licenseNumber)
        {
            //Get all orders and chack if the date in olredy exsist.
            var notAvailableCar = ctx.Orders.Where(o => o.License_number == licenseNumber)
                .Where(o => start > o.Taking_Date && start < o.Return_Date
                || end > o.Taking_Date && end < o.Return_Date
                || start < o.Taking_Date && end > o.Return_Date).Any();

            if (notAvailableCar)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}




