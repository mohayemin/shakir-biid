using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class VarietyController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/variety/

        public ViewResult Index()
        {
            var varieties = _db.Varieties.Include(v => v.DetailsSupplierInfo).Include(v => v.Item);
            return View(varieties.ToList());
        }

        //
        // GET: /Admin/variety/Details/5

        public ViewResult Details(int id)
        {
            Variety variety = _db.Varieties.Find(id);
            return View(variety);
        }

        //
        // GET: /Admin/variety/Create

        public ActionResult Create()
        {
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name");
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/variety/Create

        [HttpPost]
        public ActionResult Create(Variety variety)
        {
            if (ModelState.IsValid)
            {
                _db.Varieties.Add(variety);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", variety.DetailsSupplierId);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", variety.ItemId);
            return View(variety);
        }
        
        //
        // GET: /Admin/variety/Edit/5
 
        public ActionResult Edit(int id)
        {
            Variety variety = _db.Varieties.Find(id);
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", variety.DetailsSupplierId);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", variety.ItemId);
            return View(variety);
        }

        //
        // POST: /Admin/variety/Edit/5

        [HttpPost]
        public ActionResult Edit(Variety variety)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(variety).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DetailsSupplierId = new SelectList(_db.DetailsSupplierInfoes, "Id", "Name", variety.DetailsSupplierId);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", variety.ItemId);
            return View(variety);
        }

        //
        // GET: /Admin/variety/Delete/5
 
        public ActionResult Delete(int id)
        {
            Variety variety = _db.Varieties.Find(id);
            return View(variety);
        }

        //
        // POST: /Admin/variety/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Variety variety = _db.Varieties.Find(id);
            _db.Varieties.Remove(variety);
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