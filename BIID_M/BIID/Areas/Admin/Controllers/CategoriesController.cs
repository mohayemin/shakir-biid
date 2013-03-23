using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class CategoriesController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Categories/

        public ViewResult Index()
        {
            var categories = _db.Categories.Include(c => c.Sector);
            return View(categories.ToList());
        }

        //
        // GET: /Admin/Categories/Details/5

        public ViewResult Details(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        //
        // GET: /Admin/Categories/Create

        public ActionResult Create()
        {
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Categories/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", category.SectorId);
            return View(category);
        }
        
        //
        // GET: /Admin/Categories/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category category = _db.Categories.Find(id);
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", category.SectorId);
            return View(category);
        }

        //
        // POST: /Admin/Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(category).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name", category.SectorId);
            return View(category);
        }

        //
        // GET: /Admin/Categories/Delete/5
 
        public ActionResult Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        //
        // POST: /Admin/Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Category category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
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