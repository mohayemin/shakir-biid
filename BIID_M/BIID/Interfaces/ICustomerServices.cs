using System.Collections.Generic;
using BIID.Entities;

namespace BIID.Interfaces
{
    interface ICustomerServices
    {
        int SaveCustomerData(CustmerProfile customer);

        List<CustomerDistrict> GetAllDistrcts();
        List<CustomerUpozilla> GetUpazillaByDistrictId(int districtId);
        //CustomerDistrict GetDistrictById(int districtId);

        
        bool IsExistingCustomer(string customerId);

        CustmerProfile GetCustomerByCustomerId(string customerId);
    }
}