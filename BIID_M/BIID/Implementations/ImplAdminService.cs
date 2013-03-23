using System.Collections.Generic;
using System.Linq;
using BIID.Entities;
using BIID.Interfaces;
using BIID.Models;

namespace BIID.Implementations
{
    public class ImplAdminService : DbBaseClass, IAdminService
    {
        #region Implementation of IAdminService

        public User AddUser(User user)
        {
             Users.Add(user);
             SaveChanges();
            return user;
        }


        public Sector AddSector(Sector sector)
        {
             Sectors.Add(sector);
             SaveChanges();
            return sector;
        }

        public Category AddCategory(Category category)
        {
             Categories.Add(category);
             SaveChanges();
            return category;
        }

        public Item AddItem(Item item)
        {
             Items.Add(item);
             SaveChanges();
            return item;
        }

        public SupplierCategory AddSupplierCategory(SupplierCategory supplierCategory)
        {
             SupplierCategories.Add(supplierCategory);
             SaveChanges();
            return supplierCategory;
        }

        public DetailsSupplierInfo AddOrganization(DetailsSupplierInfo detailsSupplierInfo)
        {
             DetailsSupplierInfoes.Add(detailsSupplierInfo);
             SaveChanges();
            return detailsSupplierInfo;
        }

        public User GetUserByUserId(int userId)
        {
            var model =  Users.Find(userId);
            return model;
        }

        public User GetUserByUserName(string userName)
        {
            var user = (from m in  Users
                       where m.UserName == userName
                       select m).FirstOrDefault();

            return user;
        }

        public User EditUser(User user)
        {
            var oldUser =  Users.Find(user.Id);

            oldUser.Email = user.Email;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.UserName = user.UserName;
            oldUser.Password = user.Password;
            oldUser.Address = user.Address;
            
            
             SaveChanges();
            return user;
        }

        public string AuthorizationLevelByUserId(int userId)
        {
            var authLevel = from m in Users
                            where m.Id == userId
                            select m.UserRole.RoleName;
            return authLevel.First();
        }

        public List<UserLog> GetUserLogByUserId(int userId)
        {
            var userLogs = from ul in UserLogs
                           where ul.UserId == userId
                           select ul;
            return userLogs.ToList();
        }

        public void AddUserLog(UserLog log)
        {
            UserLogs.Add(log);
            SaveChanges();
        }

        #endregion
    }
}