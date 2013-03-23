using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class SeedProductionController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/SeedProduction/

        public ViewResult Index()
        {
            var seedproductions = _db.SeedProductions.Include(s => s.Item);
            return View(seedproductions.ToList());
        }

        //
        // GET: /Admin/SeedProduction/Details/5

        public ViewResult Details(int id)
        {
            SeedProduction seedproduction = _db.SeedProductions.Find(id);
            return View(seedproduction);
        }

        //
        // GET: /Admin/SeedProduction/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/SeedProduction/Create

        [HttpPost]
        public ActionResult Create(SeedProduction seedproduction)
        {
            if (ModelState.IsValid)
            {
                _db.SeedProductions.Add(seedproduction);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", seedproduction.ItemId);
            return View(seedproduction);
        }
        
        //
        // GET: /Admin/SeedProduction/Edit/5
 
        public ActionResult Edit(int id)
        {
            SeedProduction seedproduction = _db.SeedProductions.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", seedproduction.ItemId);
            return View(seedproduction);
        }

        //
        // POST: /Admin/SeedProduction/Edit/5

        [HttpPost]
        public ActionResult Edit(SeedProduction seedproduction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(seedproduction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", seedproduction.ItemId);
            return View(seedproduction);
        }

        //
        // GET: /Admin/SeedProduction/Delete/5
 
        public ActionResult Delete(int id)
        {
            SeedProduction seedproduction = _db.SeedProductions.Find(id);
            return View(seedproduction);
        }

        //
        // POST: /Admin/SeedProduction/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SeedProduction seedproduction = _db.SeedProductions.Find(id);
            _db.SeedProductions.Remove(seedproduction);
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