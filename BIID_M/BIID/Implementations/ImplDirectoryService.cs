using System.Collections.Generic;
using System.Linq;
using BIID.Entities;
using BIID.Interfaces;
using BIID.Models;

namespace BIID.Implementations
{
    public class ImplDirectoryService: DbBaseClass, IDirectoryServices
    {
        public List<SupplierCategory> GetSupplierCategoriesBySectorId(int sectorId)
        {
            var suppliercategorys = (from suppliercategory in  SupplierCategories
                                     where suppliercategory.SectorId == sectorId
                                     select suppliercategory).ToList();
            return suppliercategorys;
        }

        public List<DetailsSupplierInfo> GetOrganizationNameBySupplierCategoryId(int suppliercategoryId)
        {
            var detailssupplierinfos = (from detailssupplierinfo in  DetailsSupplierInfoes
                                        where detailssupplierinfo.SupplierCategoryId == suppliercategoryId
                                        select detailssupplierinfo).ToList();
            return detailssupplierinfos;
        }

        public List<SupplierDistrict> GetDistrictNameByDetailsSupplierInfo(int detailssupplierinfoId)
        {
            var supplierdistricts = (from supplierdistrict in  SupplierDistricts
                                     where supplierdistrict.DetailsSupplierInfoId == detailssupplierinfoId
                                     select supplierdistrict).ToList();
            return supplierdistricts;
        }

        public List<SupplierUpozilla> GetUpozillaNameBySupplierDisrtrict(int districtId)
        {
            var supplierupozillas = (from supplierupozilla in  SupplierUpozillas
                                     where supplierupozilla.DistrictId == districtId
                                     select supplierupozilla).ToList();
            return supplierupozillas;
        }





        public List<DetailsSupplierInfo> GetAllOrganizations()
        {
            var model = from m in  DetailsSupplierInfoes
                        select m;

            return model.ToList();
        }

        public List<SupplierAddress> GetSupplierAddressBySupplierId(int supplierId)
        {
            var addresses = (from m in  SupplierAddresses
                             where m.DetailsSupplierId == supplierId
                             select m).ToList();

            return addresses;
        }

        public CustomerDistrict GetDistrict(int districtId)
        {
            var district = (from m in  CustomerDistricts
                           where m.Id == districtId
                           select m).FirstOrDefault();
            return district;
        }

        public CustomerUpozilla GetUpozilla(int upozillaId)
        {
            var upozilla = (from m in  CustomerUpozillas
                            where m.Id == upozillaId
                            select m).FirstOrDefault();
            return upozilla;
        }

        public DetailsSupplierInfo GetDetailsSupplierInfoBySupplierId(int supplierId)
        {
            var supplier = (from m in  DetailsSupplierInfoes
                            where m.Id == supplierId
                            select m).FirstOrDefault();
            return supplier;
        }

        public int GetSupplierIdByName(string supplierName)
        {
            var supplier = (from m in  DetailsSupplierInfoes
                            where m.Name == supplierName
                            select m).FirstOrDefault();
            return supplier.Id;
        }
    }
}