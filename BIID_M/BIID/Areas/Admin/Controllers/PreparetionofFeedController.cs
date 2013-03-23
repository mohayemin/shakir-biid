using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class PreparetionofFeedController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/PreparetionofFeed/

        public ViewResult Index()
        {
            var preparationoffeeds = _db.PreparationOfFeeds.Include(p => p.Item);
            return View(preparationoffeeds.ToList());
        }

        //
        // GET: /Admin/PreparetionofFeed/Details/5

        public ViewResult Details(int id)
        {
            PreparationOfFeed preparationoffeed = _db.PreparationOfFeeds.Find(id);
            return View(preparationoffeed);
        }

        //
        // GET: /Admin/PreparetionofFeed/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/PreparetionofFeed/Create

        [HttpPost]
        public ActionResult Create(PreparationOfFeed preparationoffeed)
        {
            if (ModelState.IsValid)
            {
                _db.PreparationOfFeeds.Add(preparationoffeed);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", preparationoffeed.ItemId);
            return View(preparationoffeed);
        }
        
        //
        // GET: /Admin/PreparetionofFeed/Edit/5
 
        public ActionResult Edit(int id)
        {
            PreparationOfFeed preparationoffeed = _db.PreparationOfFeeds.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", preparationoffeed.ItemId);
            return View(preparationoffeed);
        }

        //
        // POST: /Admin/PreparetionofFeed/Edit/5

        [HttpPost]
        public ActionResult Edit(PreparationOfFeed preparationoffeed)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(preparationoffeed).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", preparationoffeed.ItemId);
            return View(preparationoffeed);
        }

        //
        // GET: /Admin/PreparetionofFeed/Delete/5
 
        public ActionResult Delete(int id)
        {
            PreparationOfFeed preparationoffeed = _db.PreparationOfFeeds.Find(id);
            return View(preparationoffeed);
        }

        //
        // POST: /Admin/PreparetionofFeed/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PreparationOfFeed preparationoffeed = _db.PreparationOfFeeds.Find(id);
            _db.PreparationOfFeeds.Remove(preparationoffeed);
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