using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class TipsController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/Tips/

        public ViewResult Index()
        {
            var tips = _db.Tips.Include(t => t.Item);
            return View(tips.ToList());
        }

        //
        // GET: /Admin/Tips/Details/5

        public ViewResult Details(int id)
        {
            Tip tip = _db.Tips.Find(id);
            return View(tip);
        }

        //
        // GET: /Admin/Tips/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Tips/Create

        [HttpPost]
        public ActionResult Create(Tip tip)
        {
            if (ModelState.IsValid)
            {
                _db.Tips.Add(tip);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", tip.ItemId);
            return View(tip);
        }
        
        //
        // GET: /Admin/Tips/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tip tip = _db.Tips.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", tip.ItemId);
            return View(tip);
        }

        //
        // POST: /Admin/Tips/Edit/5

        [HttpPost]
        public ActionResult Edit(Tip tip)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tip).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", tip.ItemId);
            return View(tip);
        }

        //
        // GET: /Admin/Tips/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tip tip = _db.Tips.Find(id);
            return View(tip);
        }

        //
        // POST: /Admin/Tips/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tip tip = _db.Tips.Find(id);
            _db.Tips.Remove(tip);
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