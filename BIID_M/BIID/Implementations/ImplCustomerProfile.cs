using System.Collections.Generic;
using System.Linq;
using BIID.Entities;
using BIID.Interfaces;
using BIID.Models;

namespace BIID.Implementations
{
    public class ImplCustomerProfile:DbBaseClass,ICustomerServices
    {

    public int  SaveCustomerData(CustmerProfile customer)
    {

        CustmerProfiles.Add(customer);
        SaveChanges();
        return 0;
    }

        public List<CustomerDistrict> GetAllDistrcts()
        {
            var model = (from m in CustomerDistricts
                        select m).ToList();

            return model;
        }

        public List<CustomerUpozilla> GetUpazillaByDistrictId(int districtId)
        {
            var model = from m in CustomerUpozillas
                        where m.DistrictId == districtId
                        select m;

            return model.ToList();
        }

        public bool IsExistingCustomer(string customerId)
        {
            var customer = (from m in CustmerProfiles
                                       where m.CustomerId == customerId
                                       select m).FirstOrDefault();

            return customer != null;
        }

        public CustmerProfile GetCustomerByCustomerId(string customerId)
        {
            var customer = (from m in CustmerProfiles
                                       where m.CustomerId == customerId
                                       select m).FirstOrDefault();

            return customer;
        }
    }
}