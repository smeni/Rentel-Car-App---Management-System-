using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.DAL;
using _4.Entities;

namespace _2.BL
{
    public class UserManager : IDisposable
    {
        DB_Car_RentalEntities ctx;
        public UserManager()
        {
            ctx = new DB_Car_RentalEntities();
        }

        public List<User> Users
        {
            get
            {
                return ctx.Users.Where(u => u.IsActiv == true).ToList();
            }
        }

        public User GetByID(int userID)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                return ctx.Users.Where(u => u.UserID == userID).FirstOrDefault();
            }
        }

        public bool Insert(User newUser)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                ctx.Users.Add(newUser);
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public bool Update(User userToUpdate)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // 1) attach the employee to the context (in the memory)
                ctx.Users.Attach(userToUpdate);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(userToUpdate).State = System.Data.EntityState.Modified;

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public bool Delete(User userToDelete)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
                // 1) attach the employee to the context (in the memory)
                ctx.Users.Attach(userToDelete);

                // 2) mark the employee as "need to be updated"
                ctx.Entry(userToDelete).State = System.Data.EntityState.Modified;
                if (userToDelete.IsActiv == true)
                    userToDelete.IsActiv = false;

                // 3) save the changes in the database
                int count = ctx.SaveChanges();

                return count > 0;
            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}


