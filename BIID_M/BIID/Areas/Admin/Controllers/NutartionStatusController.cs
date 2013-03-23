using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class NutartionStatusController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/NutartionStatus/

        public ViewResult Index()
        {
            var nutritionalstatus = _db.NutritionalStatus.Include(n => n.Item);
            return View(nutritionalstatus.ToList());
        }

        //
        // GET: /Admin/NutartionStatus/Details/5

        public ViewResult Details(int id)
        {
            NutritionalStatu nutritionalstatu = _db.NutritionalStatus.Find(id);
            return View(nutritionalstatu);
        }

        //
        // GET: /Admin/NutartionStatus/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/NutartionStatus/Create

        [HttpPost]
        public ActionResult Create(NutritionalStatu nutritionalstatu)
        {
            if (ModelState.IsValid)
            {
                _db.NutritionalStatus.Add(nutritionalstatu);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", nutritionalstatu.ItemId);
            return View(nutritionalstatu);
        }
        
        //
        // GET: /Admin/NutartionStatus/Edit/5
 
        public ActionResult Edit(int id)
        {
            NutritionalStatu nutritionalstatu = _db.NutritionalStatus.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", nutritionalstatu.ItemId);
            return View(nutritionalstatu);
        }

        //
        // POST: /Admin/NutartionStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(NutritionalStatu nutritionalstatu)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(nutritionalstatu).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", nutritionalstatu.ItemId);
            return View(nutritionalstatu);
        }

        //
        // GET: /Admin/NutartionStatus/Delete/5
 
        public ActionResult Delete(int id)
        {
            NutritionalStatu nutritionalstatu = _db.NutritionalStatus.Find(id);
            return View(nutritionalstatu);
        }

        //
        // POST: /Admin/NutartionStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            NutritionalStatu nutritionalstatu = _db.NutritionalStatus.Find(id);
            _db.NutritionalStatus.Remove(nutritionalstatu);
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