using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class ItemsController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Items/

        public ViewResult Index()
        {
            var items = _db.Items.Include(i => i.Category);
            return View(items.ToList());
        }

        //
        // GET: /Admin/Items/Details/5

        public ViewResult Details(int id)
        {
            Item item = _db.Items.Find(id);
            return View(item);
        }

        //
        // GET: /Admin/Items/Create

        public ActionResult Create()
        {
            ViewBag.sectorId = new SelectList(_db.Sectors, "Id", "Name");
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Items/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", item.CategoryId);
            return View(item);
        }
        
        //
        // GET: /Admin/Items/Edit/5
 
        public ActionResult Edit(int id)
        {
            Item item = _db.Items.Find(id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", item.CategoryId);
            return View(item);
        }

        //
        // POST: /Admin/Items/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", item.CategoryId);
            return View(item);
        }

        //
        // GET: /Admin/Items/Delete/5
 
        public ActionResult Delete(int id)
        {
            Item item = _db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Admin/Items/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Item item = _db.Items.Find(id);
            _db.Items.Remove(item);
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