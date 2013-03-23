using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class FertilizerController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/fertilizer/

        public ViewResult Index()
        {
            var fertilizers = _db.Fertilizers.Include(f => f.Item);
            return View(fertilizers.ToList());
        }

        //
        // GET: /Admin/fertilizer/Details/5

        public ViewResult Details(int id)
        {
            Fertilizer fertilizer = _db.Fertilizers.Find(id);
            return View(fertilizer);
        }

        //
        // GET: /Admin/fertilizer/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/fertilizer/Create

        [HttpPost]
        public ActionResult Create(Fertilizer fertilizer)
        {
            if (ModelState.IsValid)
            {
                _db.Fertilizers.Add(fertilizer);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", fertilizer.ItemId);
            return View(fertilizer);
        }
        
        //
        // GET: /Admin/fertilizer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Fertilizer fertilizer = _db.Fertilizers.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", fertilizer.ItemId);
            return View(fertilizer);
        }

        //
        // POST: /Admin/fertilizer/Edit/5

        [HttpPost]
        public ActionResult Edit(Fertilizer fertilizer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(fertilizer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", fertilizer.ItemId);
            return View(fertilizer);
        }

        //
        // GET: /Admin/fertilizer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Fertilizer fertilizer = _db.Fertilizers.Find(id);
            return View(fertilizer);
        }

        //
        // POST: /Admin/fertilizer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Fertilizer fertilizer = _db.Fertilizers.Find(id);
            _db.Fertilizers.Remove(fertilizer);
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