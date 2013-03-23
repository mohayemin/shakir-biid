using System;
using System.Web.Security;
using BIID.Entities;
using System.Linq;

namespace BIID.Provider
{
    public class ApplicationRoleProvider : RoleProvider
    {
        readonly BIIDFinalEntities _entities = new BIIDFinalEntities();
        public override bool IsUserInRole(string username, string roleName)
        {
            var user = GetUser(username);

            if (user != null)
            {
                return user.UserRole.RoleName == roleName;
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = _entities.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null)
            {
                return new[] { user.UserRole.RoleName };    
            }else
            {
                return new string[] {};
            }

            
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var users = _entities.Users.Where(user => user.UserRole.RoleName == roleName);
            return users.Select(user => user.UserName).ToArray();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private User GetUser(string username)
        {
            var user = _entities.Users.FirstOrDefault(u => u.UserName == username);

            return user;
        }
    }
}