using System;
using System.Collections.Generic;
using BIID.Entities;

namespace BIID.Interfaces
{
    interface IAdminService
    {
        #region AllAdminService
        #region userss
        User AddUser(User user);
#endregion
        

        #region Agri
        Sector AddSector(Sector sector);
        Category AddCategory(Category category);
        Item AddItem(Item item);
        #endregion

        #region Directory

        SupplierCategory AddSupplierCategory(SupplierCategory supplierCategory);
        DetailsSupplierInfo AddOrganization(DetailsSupplierInfo detailsSupplierInfo);
       

        #endregion
#endregion

        #region

        User GetUserByUserId(int userId);
        User GetUserByUserName(string userName);
        User EditUser(User user);

        String AuthorizationLevelByUserId(int userId);

        #endregion


        #region User Log

        List<UserLog> GetUserLogByUserId(int userId);
        void AddUserLog(UserLog log);

        #endregion


    }
}
