using _2.BL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace _1.UI.Code
{
    public class MLRoleProvider : RoleProvider
    {
        UserManager userManager;
        private string _appName;
        public MLRoleProvider()
        {
            userManager = new UserManager();
        }
        public override string ApplicationName { get { return _appName; } set { _appName = value; } }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string usermaile)
        {
            var user = userManager.Users.Where(u => u.E_mail == usermaile).FirstOrDefault();
            return user.RolesTypes.Select(r => r.RoleName).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string usermaile, string roleName)
        {
            string[] x = GetRolesForUser(usermaile);
            return x.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}