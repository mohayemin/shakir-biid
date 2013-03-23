using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class EquipmentandTechnologyController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/EquipmentandTechnology/

        public ViewResult Index()
        {
            var equipmentandtechnologies = _db.EquipmentAndTechnologies.Include(e => e.Item);
            return View(equipmentandtechnologies.ToList());
        }

        //
        // GET: /Admin/EquipmentandTechnology/Details/5

        public ViewResult Details(int id)
        {
            EquipmentAndTechnology equipmentandtechnology = _db.EquipmentAndTechnologies.Find(id);
            return View(equipmentandtechnology);
        }

        //
        // GET: /Admin/EquipmentandTechnology/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name");
            return View();
        } 

        //
        // POST: /Admin/EquipmentandTechnology/Create

        [HttpPost]
        public ActionResult Create(EquipmentAndTechnology equipmentandtechnology)
        {
            if (ModelState.IsValid)
            {
                _db.EquipmentAndTechnologies.Add(equipmentandtechnology);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", equipmentandtechnology.ItemId);
            return View(equipmentandtechnology);
        }
        
        //
        // GET: /Admin/EquipmentandTechnology/Edit/5
 
        public ActionResult Edit(int id)
        {
            EquipmentAndTechnology equipmentandtechnology = _db.EquipmentAndTechnologies.Find(id);
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", equipmentandtechnology.ItemId);
            return View(equipmentandtechnology);
        }

        //
        // POST: /Admin/EquipmentandTechnology/Edit/5

        [HttpPost]
        public ActionResult Edit(EquipmentAndTechnology equipmentandtechnology)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(equipmentandtechnology).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(_db.Items, "Id", "Name", equipmentandtechnology.ItemId);
            return View(equipmentandtechnology);
        }

        //
        // GET: /Admin/EquipmentandTechnology/Delete/5
 
        public ActionResult Delete(int id)
        {
            EquipmentAndTechnology equipmentandtechnology = _db.EquipmentAndTechnologies.Find(id);
            return View(equipmentandtechnology);
        }

        //
        // POST: /Admin/EquipmentandTechnology/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EquipmentAndTechnology equipmentandtechnology = _db.EquipmentAndTechnologies.Find(id);
            _db.EquipmentAndTechnologies.Remove(equipmentandtechnology);
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