using System.Linq;
using System.Web.Mvc;
using BIID.Areas.DirectoryInfo.Models;
using BIID.Controllers;

namespace BIID.Areas.DirectoryInfo.Controllers
{
    [Authorize]
    public class DirectoryController : BiidFinalBaseController
    //
    // GET: /DirectoryInfo/Directory/
    {
        public ActionResult Index()
        {
            var districts = this.ImplCustomerProfile.GetAllDistrcts();

            ViewData["districtsInCustomerSave"] = districts;
            var sectors = from c in this.AgriculturalService.Sectors
                          select c;

            SelectList sl = new SelectList(sectors);

            ViewBag.names = sl;
            ViewData["sectors"] = sectors;
            return View();
        }

        public ActionResult Categories(int sectorId)
        {
            var categories = this.DirectoryService.GetSupplierCategoriesBySectorId(sectorId);

            return Json(
         categories.Select(x => new { value = x.Id, text = x.Name }),
         JsonRequestBehavior.AllowGet
     );

        }

        public ActionResult Organizations(int supplierCategoryId)
        {
            var organizations = this.DirectoryService.GetOrganizationNameBySupplierCategoryId(supplierCategoryId);

            return Json(
         organizations.Select(x => new { value = x.Id, text = x.Name }),
         JsonRequestBehavior.AllowGet
     );
            
        }

        public  ActionResult Districts (int detailsupplierinfoId)
        {
            var districts = this.DirectoryService.GetDistrictNameByDetailsSupplierInfo(detailsupplierinfoId);

           
                return Json(
                    districts.Select(x => new {value = x.Id, text = x.CustomerDistrict.Name}),
                    JsonRequestBehavior.AllowGet
                    );
        }


        public ActionResult Upozillas (int districtId)
        {

            var upozillas = this.DirectoryService.GetUpozillaNameBySupplierDisrtrict(districtId);

            return Json(
                upozillas.Select(x => new {value = x.Id, text = x.CustomerUpozilla.Name}),
                JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult SearchInDirectories(int sectorId, int categoryId, int organizationId, int districtId, int upozillaId)
        {
            var sectorOrgAndOrgAddresses = new SectorOrgAndOrgAddresses();
            

            var allOrgs = this.DirectoryService.GetAllOrganizations();

            var org = (from m in this.DirectoryService.DetailsSupplierInfoes
                                      where m.Id == organizationId
                                      select m).FirstOrDefault();


              

            var sectorOrgRel = (from m in this.DirectoryService.OrganizationSectorRelations
                               where
                                   m.OrganizationId == organizationId &&
                                   m.SectorId == sectorId
                               select m).ToList();


            var sectorList = sectorOrgRel.Select(x => new { value = x.Sector.Name });

            
            var orgAddresses = (from m in this.DirectoryService.SupplierAddresses
                               where m.DetailsSupplierId == organizationId
                               select m).ToList();
            var addressList = orgAddresses.Select(x => new {district = x.CustomerDistrict.Name, upozilla = x.CustomerUpozilla.Name, address = x.Address, contact = x.Contact, email = x.Email, remarks = x.Remarks});




            return Json(new { sectorList = sectorList, orgCategory = org.SupplierCategory.Name, orgName = org.Name, addressList = addressList}, JsonRequestBehavior.AllowGet);

        }
        
    }
}

