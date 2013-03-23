using System.Collections.Generic;
using BIID.Entities;

namespace BIID.Interfaces
{
    interface IDirectoryServices

    {

        List<SupplierCategory> GetSupplierCategoriesBySectorId(int sectorId);
        List<DetailsSupplierInfo> GetOrganizationNameBySupplierCategoryId(int suppliercategoryId);
        List<SupplierDistrict> GetDistrictNameByDetailsSupplierInfo(int detailssupplierinfoId);
        List<SupplierUpozilla> GetUpozillaNameBySupplierDisrtrict(int districtId);

        List<DetailsSupplierInfo> GetAllOrganizations();

        List<SupplierAddress> GetSupplierAddressBySupplierId(int supplierId);

        CustomerDistrict GetDistrict(int districtId);
        CustomerUpozilla GetUpozilla(int upozillaId);

        DetailsSupplierInfo GetDetailsSupplierInfoBySupplierId(int supplierId);

        int GetSupplierIdByName(string supplierName);


    }
}
