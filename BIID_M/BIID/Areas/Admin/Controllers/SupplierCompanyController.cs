using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class SupplierCompanyController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/SupplierCompany/

        public ViewResult Index()
        {
            var suppliercategories = _db.SupplierCategories.Include(s => s.Sector);
            return View(suppliercategories.ToList());
        }

        //
        // GET: /Admin/SupplierCompany/Details/5

        public ViewResult Details(int id)
        {
            SupplierCategory suppliercategory = _db.SupplierCategories.Find(id);
            return View(suppliercategory);
        }

        //
        // GET: /Admin/SupplierCompany/Create

        public ActionResult Create()
        {
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/SupplierCompany/Create

        [HttpPost]
        public ActionResult Create(SupplierCategory suppliercategory)
        {
            if (ModelState.IsValid)
            {
                _db.SupplierCategories.Add(suppliercategory);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", suppliercategory.SectorId);
            return View(suppliercategory);
        }
        
        //
        // GET: /Admin/SupplierCompany/Edit/5
 
        public ActionResult Edit(int id)
        {
            SupplierCategory suppliercategory = _db.SupplierCategories.Find(id);
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", suppliercategory.SectorId);
            return View(suppliercategory);
        }

        //
        // POST: /Admin/SupplierCompany/Edit/5

        [HttpPost]
        public ActionResult Edit(SupplierCategory suppliercategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(suppliercategory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", suppliercategory.SectorId);
            return View(suppliercategory);
        }

        //
        // GET: /Admin/SupplierCompany/Delete/5
 
        public ActionResult Delete(int id)
        {
            SupplierCategory suppliercategory = _db.SupplierCategories.Find(id);
            return View(suppliercategory);
        }

        //
        // POST: /Admin/SupplierCompany/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SupplierCategory suppliercategory = _db.SupplierCategories.Find(id);
            _db.SupplierCategories.Remove(suppliercategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}