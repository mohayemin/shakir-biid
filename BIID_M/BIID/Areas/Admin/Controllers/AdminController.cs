using System.Collections.Generic;
using System.Web.Mvc;
using BIID.Controllers;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BiidFinalBaseController
    {
        //
        // GET: /Admin/Admin/
        
        public ActionResult Index()
        {

            return View();
        }
        
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if(ModelState.IsValid)
            {
                AdminService.AddUser(user);
            }
            else
            {
                ModelState.AddModelError("", "Please fill up all the fields correctly!");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult EditUser(int userId)
        {
            var model = AdminService.GetUserByUserId(userId);
            return View(model);
        }
        [HttpPost]
    public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                AdminService.EditUser(user);
            }
            else
            {
                ModelState.AddModelError("", "Please fill up all the fields correctly!");
            }
            return View(user);
            
        }

        public ActionResult ViewSectors()
        {
            var allSectors = AgriculturalService.GetAllSectors();
            return View(allSectors);
        }
        [HttpGet]
        public ActionResult AddSector()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult AddSector(Sector sector)
        {
            if (ModelState.IsValid)
            {
                AdminService.AddSector(sector);
            }
            else
            {
                ModelState.AddModelError("","Add sector");
            }
            var allSectors = AgriculturalService.GetAllSectors();

            return RedirectToAction("ViewSectors");
        }

        public ActionResult ViewItems()
        {
            var items = AgriculturalService.GetAllItems();

            return View((IEnumerable<Category>) items);
        }
        public ActionResult ViewCategories()
        {
            var categories = AgriculturalService.GetAllCategories();

            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            ViewData["sectors"] = AgriculturalService.GetAllSectors();
            
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                AdminService.AddCategory(category);
            }
            else
            {
                ModelState.AddModelError("", "Add Category");
            }
            return RedirectToAction("ViewCategories");
        }

        [HttpGet]
        public ActionResult Additem()
        {


            ViewData["sectors"] = AgriculturalService.GetAllSectors();
            ViewData["categories"] = AgriculturalService.GetAllCategories();

            return View();
        }
        [HttpPost]
        public ActionResult AddItem (Item item)
        {
            if(ModelState.IsValid)
            {

                AdminService.AddItem(item);


            }
            else
            {
                ModelState.AddModelError("","Add item");
            }
            return RedirectToAction("ViewItems");
        }
        [HttpGet]
        public ActionResult AddSupplierCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplierCategory(SupplierCategory supplierCategory)
        {
            if(ModelState.IsValid)
            {
                AdminService.AddSupplierCategory(supplierCategory);
            }
            else
            {
                ModelState.AddModelError("","Add Supplier Category");
            }
            return View(supplierCategory);
        }

        [HttpGet]
        public ActionResult AddOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrganization(DetailsSupplierInfo detailsSupplierInfo)
        {
            if(ModelState.IsValid)
            {
                AdminService.AddOrganization(detailsSupplierInfo);
            }
            else
            {
                ModelState.AddModelError("","Add Organization");
            }
            return View(detailsSupplierInfo);
        }

    }
}
