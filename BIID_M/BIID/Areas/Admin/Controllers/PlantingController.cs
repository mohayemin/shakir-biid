using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class PlantingController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

       
        //
        // GET: /Admin/Planting/

        public ViewResult Index()
        {
            var plantings = _db.Plantings.Include(p => p.Item);
            return View(plantings.ToList());
        }

        //
        // GET: /Admin/Planting/Details/5

        public ViewResult Details(int id)
        {
            Planting planting = _db.Plantings.Find(id);
            return View(planting);
        }

        //
        // GET: /Admin/Planting/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Planting/Create

        [HttpPost]
        public ActionResult Create(Planting planting)
        {
            if (ModelState.IsValid)
            {
                _db.Plantings.Add(planting);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", planting.ItemId);
            return View(planting);
        }
        
        //
        // GET: /Admin/Planting/Edit/5
 
        public ActionResult Edit(int id)
        {
            Planting planting = _db.Plantings.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", planting.ItemId);
            return View(planting);
        }

        //
        // POST: /Admin/Planting/Edit/5

        [HttpPost]
        public ActionResult Edit(Planting planting)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(planting).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", planting.ItemId);
            return View(planting);
        }

        //
        // GET: /Admin/Planting/Delete/5
 
        public ActionResult Delete(int id)
        {
            Planting planting = _db.Plantings.Find(id);
            return View(planting);
        }

        //
        // POST: /Admin/Planting/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Planting planting = _db.Plantings.Find(id);
            _db.Plantings.Remove(planting);
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