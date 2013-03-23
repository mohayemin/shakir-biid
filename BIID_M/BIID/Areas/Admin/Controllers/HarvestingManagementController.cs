using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class HarvestingManagementController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/HarvestingManagement/

        public ViewResult Index()
        {
            var harvestingmanagements = _db.HarvestingManagements.Include(h => h.Item);
            return View(harvestingmanagements.ToList());
        }

        //
        // GET: /Admin/HarvestingManagement/Details/5

        public ViewResult Details(int id)
        {
            HarvestingManagement harvestingmanagement = _db.HarvestingManagements.Find(id);
            return View(harvestingmanagement);
        }

        //
        // GET: /Admin/HarvestingManagement/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/HarvestingManagement/Create

        [HttpPost]
        public ActionResult Create(HarvestingManagement harvestingmanagement)
        {
            if (ModelState.IsValid)
            {
                _db.HarvestingManagements.Add(harvestingmanagement);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", harvestingmanagement.ItemId);
            return View(harvestingmanagement);
        }
        
        //
        // GET: /Admin/HarvestingManagement/Edit/5
 
        public ActionResult Edit(int id)
        {
            HarvestingManagement harvestingmanagement = _db.HarvestingManagements.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", harvestingmanagement.ItemId);
            return View(harvestingmanagement);
        }

        //
        // POST: /Admin/HarvestingManagement/Edit/5

        [HttpPost]
        public ActionResult Edit(HarvestingManagement harvestingmanagement)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(harvestingmanagement).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", harvestingmanagement.ItemId);
            return View(harvestingmanagement);
        }

        //
        // GET: /Admin/HarvestingManagement/Delete/5
 
        public ActionResult Delete(int id)
        {
            HarvestingManagement harvestingmanagement = _db.HarvestingManagements.Find(id);
            return View(harvestingmanagement);
        }

        //
        // POST: /Admin/HarvestingManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            HarvestingManagement harvestingmanagement = _db.HarvestingManagements.Find(id);
            _db.HarvestingManagements.Remove(harvestingmanagement);
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