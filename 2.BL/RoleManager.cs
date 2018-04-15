using _3.DAL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL
{
    public class RoleManager
    {
        public List<RolesType> GetRoleForuser(string email)
        {
            using (DB_Car_RentalEntities ctx = new DB_Car_RentalEntities())
            {
               return ctx.RolesTypes.ToList();
            }
        }
    }
}
