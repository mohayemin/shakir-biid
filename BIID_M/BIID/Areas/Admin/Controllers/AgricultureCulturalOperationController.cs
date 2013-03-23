using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class AgricultureCulturalOperationController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/AgricultureCulturalOperation/

        public ViewResult Index()
        {
            var agriculturalculturaloperations = _db.AgriculturalCulturalOperations.Include(a => a.Item);
            return View(agriculturalculturaloperations.ToList());
        }

        //
        // GET: /Admin/AgricultureCulturalOperation/Details/5

        public ViewResult Details(int id)
        {
            AgriculturalCulturalOperation agriculturalculturaloperation = _db.AgriculturalCulturalOperations.Find(id);
            return View(agriculturalculturaloperation);
        }

        //
        // GET: /Admin/AgricultureCulturalOperation/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/AgricultureCulturalOperation/Create

        [HttpPost]
        public ActionResult Create(AgriculturalCulturalOperation agriculturalculturaloperation)
        {
            if (ModelState.IsValid)
            {
                _db.AgriculturalCulturalOperations.Add(agriculturalculturaloperation);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", agriculturalculturaloperation.ItemId);
            return View(agriculturalculturaloperation);
        }
        
        //
        // GET: /Admin/AgricultureCulturalOperation/Edit/5
 
        public ActionResult Edit(int id)
        {
            AgriculturalCulturalOperation agriculturalculturaloperation = _db.AgriculturalCulturalOperations.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", agriculturalculturaloperation.ItemId);
            return View(agriculturalculturaloperation);
        }

        //
        // POST: /Admin/AgricultureCulturalOperation/Edit/5

        [HttpPost]
        public ActionResult Edit(AgriculturalCulturalOperation agriculturalculturaloperation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(agriculturalculturaloperation).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", agriculturalculturaloperation.ItemId);
            return View(agriculturalculturaloperation);
        }

        //
        // GET: /Admin/AgricultureCulturalOperation/Delete/5
 
        public ActionResult Delete(int id)
        {
            AgriculturalCulturalOperation agriculturalculturaloperation = _db.AgriculturalCulturalOperations.Find(id);
            return View(agriculturalculturaloperation);
        }

        //
        // POST: /Admin/AgricultureCulturalOperation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AgriculturalCulturalOperation agriculturalculturaloperation = _db.AgriculturalCulturalOperations.Find(id);
            _db.AgriculturalCulturalOperations.Remove(agriculturalculturaloperation);
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