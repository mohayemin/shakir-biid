using System.Data;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class ContentController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Content/

        public ViewResult Index()
        {

            //var categories = db.Categories.Include(c => c.Sector);
            //return View(categories.ToList());
            //var contents = db.Contents.Include(c => c.Sector);
            return View(_db.Contents.ToList());
        }

        //
        // GET: /Admin/Content/Details/5

        public ViewResult Details(int id)
        {
            Content content = _db.Contents.Find(id);
            return View(content);
        }

        //
        // GET: /Admin/Content/Create

        public ActionResult Create()
        {
            ViewBag.SectorId = new SelectList(_db.Sectors, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Content/Create

        [HttpPost]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                _db.Contents.Add(content);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(content);
        }
        
        //
        // GET: /Admin/Content/Edit/5
 
        public ActionResult Edit(int id)
        {
            //Content content = db.Contents.Find(id);
            //return View(content);
           // Category category = db.Categories.Find(id);
           // ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", category.SectorId);
           // return View(category);
            Content content = _db.Contents.Find(id);
            ViewBag.Sectorid = new SelectList(_db.Sectors,"Id","Name",content.SectorId);
            return View(content);

        }

        //
        // POST: /Admin/Content/Edit/5

        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(content).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        //
        // GET: /Admin/Content/Delete/5
 
        public ActionResult Delete(int id)
        {
            Content content = _db.Contents.Find(id);
            return View(content);
        }

        //
        // POST: /Admin/Content/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Content content = _db.Contents.Find(id);
            _db.Contents.Remove(content);
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