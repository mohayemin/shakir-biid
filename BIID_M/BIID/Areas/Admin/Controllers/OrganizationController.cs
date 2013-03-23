using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class OrganizationController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Organization/

        public ViewResult Index()
        {
            var supplieraddresses = _db.SupplierAddresses.Include(s => s.CustomerDistrict).Include(s => s.CustomerUpozilla).Include(s => s.DetailsSupplierInfo);
            return View(supplieraddresses.ToList());
        }

        //
        // GET: /Admin/Organization/Details/5

        public ViewResult Details(int id)
        {
            SupplierAddress supplieraddress = _db.SupplierAddresses.Find(id);
            return View(supplieraddress);
        }

        //
        // GET: /Admin/Organization/Create

        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(_db.CustomerDistricts, "Id", "Name");
            ViewBag.UpozillaId = new SelectList(_db.CustomerUpozillas, "Id", "Name");
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Organization/Create

        [HttpPost]
        public ActionResult Create(SupplierAddress supplieraddress)
        {
            if (ModelState.IsValid)
            {
                _db.SupplierAddresses.Add(supplieraddress);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DistrictId = new SelectList(_db.CustomerDistricts, "Id", "Name", supplieraddress.DistrictId);
            ViewBag.UpozillaId = new SelectList(_db.CustomerUpozillas, "Id", "Name", supplieraddress.UpozillaId);
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", supplieraddress.DetailsSupplierId);
            return View(supplieraddress);
        }
        
        //
        // GET: /Admin/Organization/Edit/5
 
        public ActionResult Edit(int id)
        {
            SupplierAddress supplieraddress = _db.SupplierAddresses.Find(id);
            ViewBag.DistrictId = new SelectList(_db.CustomerDistricts, "Id", "Name", supplieraddress.DistrictId);
            ViewBag.UpozillaId = new SelectList(_db.CustomerUpozillas, "Id", "Name", supplieraddress.UpozillaId);
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", supplieraddress.DetailsSupplierId);
            return View(supplieraddress);
        }

        //
        // POST: /Admin/Organization/Edit/5

        [HttpPost]
        public ActionResult Edit(SupplierAddress supplieraddress)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(supplieraddress).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(_db.CustomerDistricts, "Id", "Name", supplieraddress.DistrictId);
            ViewBag.UpozillaId = new SelectList(_db.CustomerUpozillas, "Id", "Name", supplieraddress.UpozillaId);
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", supplieraddress.DetailsSupplierId);
            return View(supplieraddress);
        }

        //
        // GET: /Admin/Organization/Delete/5
 
        public ActionResult Delete(int id)
        {
            SupplierAddress supplieraddress = _db.SupplierAddresses.Find(id);
            return View(supplieraddress);
        }

        //
        // POST: /Admin/Organization/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SupplierAddress supplieraddress = _db.SupplierAddresses.Find(id);
            _db.SupplierAddresses.Remove(supplieraddress);
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