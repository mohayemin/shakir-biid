using System.Data;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class SectorsController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Sectors/

        public ViewResult Index()
        {
            var model = _db.Sectors.ToList();
            return View(model);
        }

        //
        // GET: /Admin/Sectors/Details/5

        public ViewResult Details(int id)
        {
            Sector sector = _db.Sectors.Find(id);
            return View(sector);
        }

        //
        // GET: /Admin/Sectors/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Sectors/Create

        [HttpPost]
        public ActionResult Create(Sector sector)
        {
            if (ModelState.IsValid)
            {
                _db.Sectors.Add(sector);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(sector);
        }
        
        //
        // GET: /Admin/Sectors/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sector sector = _db.Sectors.Find(id);
            return View(sector);
        }

        //
        // POST: /Admin/Sectors/Edit/5

        [HttpPost]
        public ActionResult Edit(Sector sector)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sector).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        //
        // GET: /Admin/Sectors/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sector sector = _db.Sectors.Find(id);
            return View(sector);
        }

        //
        // POST: /Admin/Sectors/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Sector sector = _db.Sectors.Find(id);
            _db.Sectors.Remove(sector);
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